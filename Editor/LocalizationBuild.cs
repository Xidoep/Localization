using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using XS_Utils;

[InitializeOnLoad]
class LocalizationBuild
{
    static LocalizationBuild()
    {
        BuildingExtraCheckings.checkings -= BuildAdessables;
        BuildingExtraCheckings.checkings += BuildAdessables;
    }

    static void BuildAdessables()
    {
        Debugar.Log("...start checking [LOCALIZATION]");

        Debugar.Log("Cleaning...");
        AddressableAssetSettings.CleanPlayerContent();
        Debugar.Log("...cleaned!!!");

        Debugar.Log("Building...");
        AddressableAssetSettings.BuildPlayerContent();
        Debugar.Log("...builded!!!");

        Debugar.Log("...end checking [LOCALIZATION]");
        Debugar.Log("-----------------------------------------------");
    }
}
