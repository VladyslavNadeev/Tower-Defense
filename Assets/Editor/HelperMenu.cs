using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.DeviceInfo;

public class HelperMenu
{
    [MenuItem("Tools/Progress/Clear login")]
    public static void ClearLoginPrefs()
    {
        PlayerPrefs.DeleteKey(DeviceInfoProvider.GetDeviceId());
    }

    [MenuItem("Tools/Progress/Clear prefs")]
    public static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Tools/Assets/Clear Asset Bundle Cache")]
    public static void DoClearAssetBundleCache()
    {
        AssetBundle.UnloadAllAssetBundles(true);
        Debug.Log($"Clear Asset Bundle Cache result: {Caching.ClearCache()}");
    }
}