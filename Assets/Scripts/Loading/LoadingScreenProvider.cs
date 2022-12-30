using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.Loading
{
    public class LoadingScreenProvider : LocalAssetLoader
    {
        public async Task LoadAndDestroy(Queue<ILoadingOperation> loadingOperations)
        {
            var loadingScreen = await Load();
            await loadingScreen.Load(loadingOperations);
            Unload();
        }

        public Task<LoadingScreen> Load()
        {
            return LoadInternal<LoadingScreen>("LoadingScreen");
        }

        public void Unload()
        {
            UnloadInternal();
        }
    }
}
