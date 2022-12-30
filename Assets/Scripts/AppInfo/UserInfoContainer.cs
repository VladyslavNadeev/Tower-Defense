using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AppInfo
{
    public class UserInfoContainer
    {
        public string Id { get; set; }
        public string FacebookId { get; set; }
        public string Name { get; set; }
        public string AvatarPath { get; set; }

        public bool IsFacebook => string.IsNullOrWhiteSpace(FacebookId) == false;
    }
}
