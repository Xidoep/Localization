using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;

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
        Debug.Log("...start checking [LOCALIZATION]");

        Debug.Log("Cleaning...");
        AddressableAssetSettings.CleanPlayerContent();
        Debug.Log("...cleaned!!!");

        Debug.Log("Building...");
        AddressableAssetSettings.BuildPlayerContent();
        Debug.Log("...builded!!!");

        Debug.Log("...end checking [LOCALIZATION]");
        Debug.Log("-----------------------------------------------");
    }
}
