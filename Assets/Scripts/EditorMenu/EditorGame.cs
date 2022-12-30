using Assets.Scripts.Builder;
using Assets.Scripts.Common;
using Assets.Scripts.EditorMenu;
using Assets.Scripts.Loading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;

public class EditorGame : MonoBehaviour, ICleanUp
{
    [Header("Board")]
    [SerializeField]
    private Vector2Int _boardSize;
    [SerializeField]
    private GameBoard _board;
    [SerializeField]
    private Camera _camera;

    [Header("UI")]
    [SerializeField]
    private TilesBuilder _tilesBuilder;
    [SerializeField]
    private EditorHud _hud;

    [Header("Factory")]
    [SerializeField]
    private GameTileContentFactory _contentFactory;

    private readonly BoardSerializer _serializer = new BoardSerializer();

    public IEnumerable<GameObjectFactory> Factories => new GameObjectFactory[] { _contentFactory };
    public string SceneName => Constants.Scenes.EDITOR_GAME;
    private string _fileName;

    public void Init(string fileName)
    {
        _fileName = fileName;
        _hud.QuitGame += GoToMainMenu;
        _hud.SaveClicked += OnSaveClicked;
        var initialData = GenerateInitialData();
        _board.Initialize(initialData, _contentFactory);
        _tilesBuilder.Initialize(_contentFactory, _camera, _board, true);
    }

    private BoardData GenerateInitialData()
    {
        var result = _serializer.Load(_fileName);
        if(result == null)
        {
            result = new BoardData
            {
                X = (byte)_boardSize.x,
                Y = (byte)_boardSize.y,
                Content = new GameTileContentType[_boardSize.x * _boardSize.y]
            };
            result.Content[0] = GameTileContentType.SpawnPoint;
            result.Content[result.Content.Length - 1] = GameTileContentType.Destination;
        }
        return result;
    }

    public void BeginNewGame()
    {
        Cleanup();
        _tilesBuilder.Enable();
    }

    public void Cleanup()
    {
        _tilesBuilder.Disable();
        _board.Clear();
    }

    private async void GoToMainMenu()
    {
        var operations = new Queue<ILoadingOperation>();
        operations.Enqueue(new ClearGameOperation(this));
        await ProjectContext.Instance.LoadingScreenProvider.LoadAndDestroy(operations);
    }

    private void OnSaveClicked()
    {
        var data = new BoardData()
        {
            Version = Serialization.VERSION,
            AccountId = 1145,
            X = (byte)_boardSize.x,
            Y = (byte)_boardSize.y,
            Content = _board.GetAllContent
        };
        _serializer.Save(data, _fileName);
    }
}
