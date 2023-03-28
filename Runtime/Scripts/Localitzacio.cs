using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using XS_Utils;

[CreateAssetMenu(menuName = "Xido Studio/Localitzacio/Localitzacio")]
public class Localitzacio : ScriptableObject
{
    const string KEY_IDIOMA_ACTUAL = "IdiomaActual";

    [SerializeField] SavableVariable<int> idiomaSeleccionat;
    public Locale perDefecte;


    private void OnEnable()
    {
        idiomaSeleccionat = new SavableVariable<int>(KEY_IDIOMA_ACTUAL, Guardat.Direccio.Cloud, IdiomaDelSistema());
        IdiomaActual(idiomaSeleccionat.Valor);
        if (LocalizationSettings.HasSettings)
            LocalizationSettings.Instance.ResetState();
    }


    
    public void IdiomaActual(int idioma)
    {
        //LocalizationSettings.InitializationOperation.Completed += 
        if (idioma == -1 || idioma > LocalizationSettings.AvailableLocales.Locales.Count)
        {
            PerDefecte();
            return;
        }

        SetIdioma(idioma);
    }

    public void PerDefecte() => SetIdioma(-1);
    public void PerDevice() => SetIdioma(IdiomaDelSistema());



    void SetIdioma(int idioma)
    {
        Debug.Log($"SetIdoma = {idioma}");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[idioma];
        idiomaSeleccionat.Valor = idioma;
    }
    int IdiomaDelSistema()
    {
        return Application.systemLanguage switch
        {
            SystemLanguage.Afrikaans or 
            SystemLanguage.Arabic or 
            SystemLanguage.Basque or 
            SystemLanguage.Belarusian or 
            SystemLanguage.Bulgarian 
            => -1,
            SystemLanguage.Catalan 
            => 7,
            SystemLanguage.Chinese 
            => 1,
            SystemLanguage.Czech or 
            SystemLanguage.Danish or 
            SystemLanguage.Dutch 
            => -1,
            SystemLanguage.English 
            => 0,
            SystemLanguage.Estonian or 
            SystemLanguage.Faroese or 
            SystemLanguage.Finnish or 
            SystemLanguage.French 
            => 6,
            SystemLanguage.German 
            => 4,
            SystemLanguage.Greek or 
            SystemLanguage.Hebrew or 
            SystemLanguage.Hungarian or 
            SystemLanguage.Icelandic or 
            SystemLanguage.Indonesian or 
            SystemLanguage.Italian or 
            SystemLanguage.Japanese or 
            SystemLanguage.Korean or 
            SystemLanguage.Latvian or 
            SystemLanguage.Lithuanian or 
            SystemLanguage.Norwegian 
            => -1,
            SystemLanguage.Polish 
            => 8,
            SystemLanguage.Portuguese 
            => 5,
            SystemLanguage.Romanian 
            => -1,
            SystemLanguage.Russian 
            => 2,
            SystemLanguage.SerboCroatian or 
            SystemLanguage.Slovak or 
            SystemLanguage.Slovenian 
            => -1,
            SystemLanguage.Spanish 
            => 3,
            SystemLanguage.Swedish or 
            SystemLanguage.Thai or 
            SystemLanguage.Turkish or 
            SystemLanguage.Ukrainian or 
            SystemLanguage.Vietnamese or 
            SystemLanguage.ChineseSimplified or 
            SystemLanguage.ChineseTraditional or 
            SystemLanguage.Unknown 
            => -1,
            _ => -1,
        };
    }



    private void OnValidate()
    {
        idiomaSeleccionat = new SavableVariable<int>(KEY_IDIOMA_ACTUAL, Guardat.Direccio.Cloud, IdiomaDelSistema());
    }
}
