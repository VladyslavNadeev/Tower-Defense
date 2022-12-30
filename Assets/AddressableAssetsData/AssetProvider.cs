using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Assets.Scripts.Loading
{
    public class AssetProvider : ILoadingOperation
    {
        private bool _isReady;

        private async Task WaitUntilReady()
        {
            while(_isReady == false)
            {
                await Task.Yield();
            }
        }

        public async Task<SceneInstance> LoadSceneAdditive(string sceneId)
        {
            await WaitUntilReady();
            var operation = Addressables.LoadSceneAsync(sceneId, LoadSceneMode.Additive);
            return await operation.Task;
        }

        public async Task UnloadAdditiveScene(SceneInstance scene)
        {
            await WaitUntilReady();
            var operation = Addressables.UnloadSceneAsync(scene);
            await operation.Task;
        }

        public string Description => "Assets Initializon...";

        public async Task Load(Action<float> onProgress)
        {
            var operation = Addressables.InitializeAsync();
            await operation.Task;
            _isReady = true;
        }
    }
}
