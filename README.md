<p align="left">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
    <img alt="License" src="https://img.shields.io/github/license/wolf-package/remote-config-manager-unity?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/wolf-package/remote-config-manager-unity?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/wolf-package/remote-config-manager-unity?logo=VirtualBox">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/wolf-package/remote-config-manager-unity?include_prereleases&logo=Dropbox&color=yellow">
  </a>
</p>

## What
- Tool support use firebase remote config for game unity
## How To Install

### Add the line below to `Packages/manifest.json`

for version `1.0.2`
```csharp
"com.wolf-org.remote-config":"https://github.com/wolf-org/remote-config-manager-unity.git#1.0.2",
```
dependency `extensions-unity-1.0.5`
```csharp
"com.wolf-org.extensions":"https://github.com/wolf-org/extensions-unity.git#1.0.5",
```
If you use [game-data-unity](https://github.com/wolf-package/game-data-unity), add the library below and define symbol `VIRTUESKY_DATA`
```csharp
"com.wolf-org.game-data":"https://github.com/wolf-org/game-data-unity.git#1.0.2",
```

## Use

- Add `Define symbol` to use remote config  (`VIRTUESKY_FIREBASE`, `VIRTUESKY_FIREBASE_REMOTECONFIG`)

- Attach `FirebaseRemoteConfigManager` to scene (don't destroy). Please add a `Remote Config Data` to the list, then enter the key, select the corresponding data type (int, bool, string), enter the default value. Finally, click `Generate Remote Data` when you have finished setup.

![Screenshot 2024-05-17 112334](https://github.com/wolf-package/unity-common/assets/102142404/728f0c8e-f604-4153-acea-63feac00ab52)

- After clicking `Generate Remote Data`, the `RemoteData.cs` script will be automatically generated and formatted as below.

```csharp

namespace VirtueSky.RemoteConfigs
{
	public struct RemoteData
	{
		public const string KEY_RMC_LEVEL_TURN_ON_INTER_ADS = "RMC_LEVEL_TURN_ON_INTER_ADS";
		public const int DEFAULT_RMC_LEVEL_TURN_ON_INTER_ADS = 5;
		public static int RMC_LEVEL_TURN_ON_INTER_ADS => VirtueSky.DataStorage.GameData.Get(KEY_RMC_LEVEL_TURN_ON_INTER_ADS, DEFAULT_RMC_LEVEL_TURN_ON_INTER_ADS);
		public const string KEY_RMC_INTER_CAPPING_LEVEL = "RMC_INTER_CAPPING_LEVEL";
		public const int DEFAULT_RMC_INTER_CAPPING_LEVEL = 2;
		public static int RMC_INTER_CAPPING_LEVEL => VirtueSky.DataStorage.GameData.Get(KEY_RMC_INTER_CAPPING_LEVEL, DEFAULT_RMC_INTER_CAPPING_LEVEL);
		public const string KEY_RMC_INTER_CAPPING_TIME = "RMC_INTER_CAPPING_TIME";
		public const int DEFAULT_RMC_INTER_CAPPING_TIME = 8;
		public static int RMC_INTER_CAPPING_TIME => VirtueSky.DataStorage.GameData.Get(KEY_RMC_INTER_CAPPING_TIME, DEFAULT_RMC_INTER_CAPPING_TIME);
		public const string KEY_RMC_ON_OFF_INTER = "RMC_ON_OFF_INTER";
		public const bool DEFAULT_RMC_ON_OFF_INTER = true;
		public static bool RMC_ON_OFF_INTER => VirtueSky.DataStorage.GameData.Get(KEY_RMC_ON_OFF_INTER, DEFAULT_RMC_ON_OFF_INTER);
		public const string KEY_RMC_ON_OFF_BANNER = "RMC_ON_OFF_BANNER";
		public const bool DEFAULT_RMC_ON_OFF_BANNER = true;
		public static bool RMC_ON_OFF_BANNER => VirtueSky.DataStorage.GameData.Get(KEY_RMC_ON_OFF_BANNER, DEFAULT_RMC_ON_OFF_BANNER);
		public const string KEY_RMC_LEVEL_SHOW_RATE_AND_REVIEW = "RMC_LEVEL_SHOW_RATE_AND_REVIEW";
		public const int DEFAULT_RMC_LEVEL_SHOW_RATE_AND_REVIEW = 3;
		public static int RMC_LEVEL_SHOW_RATE_AND_REVIEW => VirtueSky.DataStorage.GameData.Get(KEY_RMC_LEVEL_SHOW_RATE_AND_REVIEW, DEFAULT_RMC_LEVEL_SHOW_RATE_AND_REVIEW);
		public const string KEY_RMC_ON_OFF_RATE_AND_REVIEW = "RMC_ON_OFF_RATE_AND_REVIEW";
		public const bool DEFAULT_RMC_ON_OFF_RATE_AND_REVIEW = true;
		public static bool RMC_ON_OFF_RATE_AND_REVIEW => VirtueSky.DataStorage.GameData.Get(KEY_RMC_ON_OFF_RATE_AND_REVIEW, DEFAULT_RMC_ON_OFF_RATE_AND_REVIEW);
		public const string KEY_RMC_VERSION_UPDATE = "RMC_VERSION_UPDATE";
		public const string DEFAULT_RMC_VERSION_UPDATE = "1.0";
		public static string RMC_VERSION_UPDATE => VirtueSky.DataStorage.GameData.Get(KEY_RMC_VERSION_UPDATE, DEFAULT_RMC_VERSION_UPDATE);
		public const string KEY_RMC_CONTENT_UPDATE = "RMC_CONTENT_UPDATE";
		public const string DEFAULT_RMC_CONTENT_UPDATE = "Update Content";
		public static string RMC_CONTENT_UPDATE => VirtueSky.DataStorage.GameData.Get(KEY_RMC_CONTENT_UPDATE, DEFAULT_RMC_CONTENT_UPDATE);
	}
}

```

- Handle

From the `RemoteData` script, you can retrieve `key data`, `default values`, and `data` fetched from firebase remote configuration.

Example

```csharp

    void HandleBannerAds()
    {
        if (RemoteData.RMC_ON_OFF_BANNER)
        {
            // show banner ads
        }
    }

```