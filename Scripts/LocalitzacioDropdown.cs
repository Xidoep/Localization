using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class LocalitzacioDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public TMP_Dropdown tmpDropdown;

    public Localitzacio localitzacio;

    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        var options = new List<Dropdown.OptionData>();
        var tmpOptions = new List<TMP_Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[i])
            {
                selected = i;
            }
            options.Add(new Dropdown.OptionData(LocalizationSettings.AvailableLocales.Locales[i].LocaleName));
            tmpOptions.Add(new TMP_Dropdown.OptionData(LocalizationSettings.AvailableLocales.Locales[i].LocaleName));
        }
        if(dropdown != null)
        {
            dropdown.options = options;

            dropdown.value = selected;
            dropdown.onValueChanged.AddListener(localitzacio.IdiomaActual);
        }
        if (tmpDropdown != null)
        {
            tmpDropdown.options = tmpOptions;

            tmpDropdown.value = selected;
            tmpDropdown.onValueChanged.AddListener(localitzacio.IdiomaActual);
        }
    }

    static void LocaleSelected(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
