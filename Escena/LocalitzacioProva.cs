using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocalitzacioProva : MonoBehaviour
{
    public float canvi = 0;
    public int idioma;

    void Update()
    {
        canvi += Time.deltaTime;
        if(canvi > 1)
        {
            canvi = 0;

            idioma ++;
            if(idioma > LocalizationSettings.AvailableLocales.Locales.Count - 1)
            {
                idioma = 0;
            }

            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[idioma];
        }
    }

}
