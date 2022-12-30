using Assets.Scripts.Common;
using Assets.Scripts.Extensions;
using System;
using Assets.Scripts.EditorMenu;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Loading
{
    public class QuickGameLoadingOperation : ILoadingOperation
    {
        public string Description => "Game loading...";

        public async Task Load(Action<float> onProgress)
        {
            onProgress?.Invoke(0.5f);
            var loadOperation = SceneManager.LoadSceneAsync(Constants.Scenes.QUICK_GAME, LoadSceneMode.Single);
            while(loadOperation.isDone == false)
            {
                await Task.Delay(1);
            }
            onProgress?.Invoke(0.7f);

            var scene = SceneManager.GetSceneByName(Constants.Scenes.QUICK_GAME);
            var editorGame = scene.GetRoot<QuickGame>();
            var environment = await ProjectContext.Instance.AssetProvider.LoadSceneAdditive("Sand");
            onProgress?.Invoke(0.85f);
            editorGame.Init(environment);
            editorGame.BeginNewGame();
            onProgress?.Invoke(1.0f);
        }
    }
}
