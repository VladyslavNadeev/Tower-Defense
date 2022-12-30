using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.AppInfo;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Loading
{
    public class ConfigOperation : ILoadingOperation
    {
        public string Description => "Configuration loading...";

        public ConfigOperation(AppInfoContainer appInfoContainer)
        {

        }

        public async Task Load(Action<float> onProgress)
        {
            var loadingTime = Random.Range(1.5f, 2.5f);
            const int steps = 4;

            for(var i = 1; i <= steps; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(loadingTime/steps));
                onProgress?.Invoke(i / loadingTime);
            }

            onProgress?.Invoke(1f);
        }
    }
}
