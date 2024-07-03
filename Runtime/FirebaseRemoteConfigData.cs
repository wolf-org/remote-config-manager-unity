using System;

#if VIRTUESKY_FIREBASE_REMOTECONFIG
using Firebase.RemoteConfig;
#endif

using UnityEngine;
using VirtueSky.Inspector;


namespace VirtueSky.RemoteConfigs
{
    [Serializable]
    public class FirebaseRemoteConfigData
    {
        public string key;
        public TypeRemoteConfigData typeRemoteConfigData;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.StringData)]
        public string defaultValueString;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.StringData)] [SerializeField, ReadOnly]
        private string resultValueString;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.BooleanData)]
        public bool defaultValueBool;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.BooleanData)] [SerializeField, ReadOnly]
        private bool resultValueBool;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.IntData)]
        public int defaultValueInt;

        [ShowIf(nameof(typeRemoteConfigData), TypeRemoteConfigData.IntData)] [SerializeField, ReadOnly]
        private int resultValueInt;


        public void SetupDataDefault()
        {
            switch (typeRemoteConfigData)
            {
                case TypeRemoteConfigData.StringData:
#if VIRTUESKY_DATA
                    VirtueSky.DataStorage.GameData.Set(key, defaultValueString);
#else
                    PlayerPrefs.SetString(key, defaultValueString);
#endif
                    break;
                case TypeRemoteConfigData.BooleanData:
#if VIRTUESKY_DATA
                    VirtueSky.DataStorage.GameData.Set(key, defaultValueBool);
#else
                    SetBool(key, defaultValueBool);
#endif
                    break;

                case TypeRemoteConfigData.IntData:
#if VIRTUESKY_DATA
                    VirtueSky.DataStorage.GameData.Set(key, defaultValueInt);
#else
                    PlayerPrefs.SetInt(key, defaultValueInt);
#endif
                    break;
            }
        }
#if VIRTUESKY_FIREBASE_REMOTECONFIG
        public void SetupData(ConfigValue result)
        {
            switch (typeRemoteConfigData)
            {
                case TypeRemoteConfigData.StringData:
                    if (result.Source == ValueSource.RemoteValue)
                    {
#if VIRTUESKY_DATA
                        VirtueSky.DataStorage.GameData.Set(key, result.StringValue);
#else
                        PlayerPrefs.SetString(key, result.StringValue);
#endif
                    }
#if VIRTUESKY_DATA
                    resultValueString = VirtueSky.DataStorage.GameData.Get<string>(key);
#else
                    resultValueString = PlayerPrefs.GetString(key);
#endif
                    Debug.Log($"<color=Green>{key}: {resultValueString}</color>");
                    break;
                case TypeRemoteConfigData.BooleanData:
                    if (result.Source == ValueSource.RemoteValue)
                    {
#if VIRTUESKY_DATA
                        VirtueSky.DataStorage.GameData.Set(key, result.BooleanValue);
#else
                        SetBool(key, result.BooleanValue);
#endif
                    }
#if VIRTUESKY_DATA
                    resultValueBool = VirtueSky.DataStorage.GameData.Get<bool>(key);
#else
                    resultValueBool = GetBool(key);
#endif
                    Debug.Log($"<color=Green>{key}: {resultValueBool}</color>");
                    break;
                case TypeRemoteConfigData.IntData:
                    if (result.Source == ValueSource.RemoteValue)
                    {
#if VIRTUESKY_DATA
                        VirtueSky.DataStorage.GameData.Set(key, int.Parse(result.StringValue));
#else
                        PlayerPrefs.SetInt(key, int.Parse(result.StringValue));
#endif
                    }
#if VIRTUESKY_DATA
                    resultValueInt = VirtueSky.DataStorage.GameData.Get<int>(key);
#else
                    resultValueInt = PlayerPrefs.GetInt(key);
#endif
                    Debug.Log($"<color=Green>{key}: {resultValueInt}</color>");
                    break;
            }
        }
#endif

        private bool GetBool(string key, bool defaultValue = false) =>
            PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;

        private void SetBool(string key, bool value) => PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public enum TypeRemoteConfigData
    {
        StringData,
        BooleanData,
        IntData
    }
}