using Assets.Scripts.Loading;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.EditorMenu;

namespace Assets.Scripts.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _quickGameButton;

        [SerializeField]
        private Button _editBoardButton;

        [SerializeField]
        private EditorMenuMain _editorMenu;

        private void Start()
        {
            _quickGameButton.onClick.AddListener(OnQuickGameButtonClicked);
            _editBoardButton.onClick.AddListener(OnEditorButtonClicked);
        }

        private async void OnQuickGameButtonClicked()
        {
            var operations = new Queue<ILoadingOperation>();
            operations.Enqueue(new QuickGameLoadingOperation());
            await ProjectContext.Instance.LoadingScreenProvider.LoadAndDestroy(operations);
        }

        private void OnEditorButtonClicked()
        {
            _editorMenu.Show();
        }
    }
}
