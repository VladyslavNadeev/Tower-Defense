using UnityEngine;

namespace Assets.Scripts.DeviceInfo
{
    public static class DeviceInfoProvider
    {
        public static string GetDeviceId()
        {
            return SystemInfo.deviceUniqueIdentifier;
        }
    }
}    


