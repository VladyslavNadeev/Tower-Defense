using Assets.Scripts.AppInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Loading.Login
{
    public class LoginWindowProvider : LocalAssetLoader
    {
        public async Task<UserInfoContainer> ShowAndHide()
        {
            var loginWindow = await Load();
            var result = await loginWindow.ProcessLogin();
            Unload();
            return result;
        }

        public Task<LoginWindow> Load()
        {
            return LoadInternal<LoginWindow>("LoginWindow");
        }

        public void Unload()
        {
            UnloadInternal();
        }
    }
}
