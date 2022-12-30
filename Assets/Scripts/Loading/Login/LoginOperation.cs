using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DeviceInfo;
using Assets.Scripts.AppInfo;
using Assets.Scripts.Loading.Login;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Loading
{
    public class LoginOperation : ILoadingOperation
    {
        public string Description => "Login to server...";

        private readonly AppInfoContainer _appInfoContainer;

        private Action<float> _onProgress;

        public LoginOperation(AppInfoContainer appInfoContainer)
        {
            _appInfoContainer = appInfoContainer;
        }

        public async Task Load(Action<float> onProgress)
        {
            _onProgress = onProgress;
            _onProgress?.Invoke(0.3f);

            _appInfoContainer.UserInfo = await GetUserInfo(DeviceInfoProvider.GetDeviceId());

            _onProgress?.Invoke(1f);
        }

        private async Task<UserInfoContainer> GetUserInfo(string deviceId)
        {
            UserInfoContainer result = null;

            if (PlayerPrefs.HasKey(deviceId))
            {
                result = JsonUtility.FromJson<UserInfoContainer>(PlayerPrefs.GetString(deviceId));
            }

            await Task.Delay(TimeSpan.FromSeconds(1.5f));
            _onProgress?.Invoke(0.6f);

            if (result == null)
            {
                result = await ProjectContext.Instance.LoginWindowProvider.ShowAndHide();
            }

            PlayerPrefs.SetString(deviceId, JsonUtility.ToJson(result));

            return result;

        }
    }
}
