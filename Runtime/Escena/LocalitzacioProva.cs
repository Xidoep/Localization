using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using XS_Utils;

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
            if(idioma > XS_Localization.Languages - 1)
            {
                idioma = 0;
            }
            idioma.SelectLanguage();
        }
    }

}
