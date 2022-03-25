using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using XS_Utils;

[CreateAssetMenu(menuName = "Xido Studio/Localitzacio/Localitzacio")]
public class Localitzacio : ScriptableObject
{
    const string IDIOMA_ACTUAL_GUARDAT_KEY = "IdiomaActual";

    public string IdiomaActualKey => IDIOMA_ACTUAL_GUARDAT_KEY;

    public Guardat guardat;
    public Locale perDefecte;



    private void OnEnable()
    {
        Debugar.Log("Localitzacio - OnEnable => Carregar()");
        //Carregar();
        //This can not be loaded on Enable because the locales aren't initialized.
        guardat.onLoad += Carregar;
    }
    private void OnDisable()
    {
        guardat.onLoad -= Carregar;
    }



    [ContextMenu("RecuperarIdiomaGuardat")]
    public void Carregar()
    {
        //CARREGAR el guardat abans de fer aixo, si no, no rebras res.
        Debugar.Log($"Localitzacio - RecuperarIdiomaGuardat { (int)guardat.Get(IdiomaActualKey, -1)}");
        if(guardat != null) IdiomaActual((int)guardat.Get(IdiomaActualKey, -1));
    }

    public void IdiomaActual(int _locale)
    {
        //Si _locale es -1, es que no s'ha guardat cap informació sobre l'idiome escollit, 
        //per tant ho gestiona el Localitzation (que deu agafar l'idioma del dispositiu).
        if (_locale == -1)
        {
            PerDefecte();
            return;
        }

        //Per si de cas es selecciona un index que supera el rang, agafa l'idioma per defecte.
        if (_locale > LocalizationSettings.AvailableLocales.Locales.Count)
        {
            PerDefecte();
            return;
        }

        //Selecciona l'idioma amb l'index passat.
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_locale];

        //Guarda l'index a idiomes. Ja no utilitzarà més l'idioma del dispositiu.
        if (guardat != null) guardat.SetLocal(IdiomaActualKey, _locale);

        //¡¡¡GUARDAR el guardat despres de fer això!!!
    }


    public void PerDefecte()
    {
        LocalizationSettings.SelectedLocale = perDefecte;
        if (guardat != null) guardat.SetLocal(IdiomaActualKey, -1);
    }

    public void PerDevice()
    {
        int language = -1;
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Afrikaans:
            case SystemLanguage.Arabic:
            case SystemLanguage.Basque:
            case SystemLanguage.Belarusian:
            case SystemLanguage.Bulgarian:
                language = -1;
                break;
            case SystemLanguage.Catalan:
                language = 7;
                break;
            case SystemLanguage.Chinese:
                language = 1;
                break;
            case SystemLanguage.Czech:
            case SystemLanguage.Danish:
            case SystemLanguage.Dutch:
                language = -1;
                break;
            case SystemLanguage.English:
                language = 0;
                break;
            case SystemLanguage.Estonian:
            case SystemLanguage.Faroese:
            case SystemLanguage.Finnish:
            case SystemLanguage.French:
                language = 6;
                break;
            case SystemLanguage.German:
                language = 4;
                break;
            case SystemLanguage.Greek:
            case SystemLanguage.Hebrew:
            case SystemLanguage.Hungarian:
            case SystemLanguage.Icelandic:
            case SystemLanguage.Indonesian:
            case SystemLanguage.Italian:
            case SystemLanguage.Japanese:
            case SystemLanguage.Korean:
            case SystemLanguage.Latvian:
            case SystemLanguage.Lithuanian:
            case SystemLanguage.Norwegian:
                language = -1;
                break;
            case SystemLanguage.Polish:
                language = 8;
                break;
            case SystemLanguage.Portuguese:
                language = 5;
                break;
            case SystemLanguage.Romanian:
                language = -1;
                break;
            case SystemLanguage.Russian:
                language = 2;
                break;
            case SystemLanguage.SerboCroatian:
            case SystemLanguage.Slovak:
            case SystemLanguage.Slovenian:
                language = -1;
                break;
            case SystemLanguage.Spanish:
                language = 3;
                break;
            case SystemLanguage.Swedish:
            case SystemLanguage.Thai:
            case SystemLanguage.Turkish:
            case SystemLanguage.Ukrainian:
            case SystemLanguage.Vietnamese:
            case SystemLanguage.ChineseSimplified:
            case SystemLanguage.ChineseTraditional:
            case SystemLanguage.Unknown:
                language = -1;
                break;
            default:
                language = -1;
                break;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
        if (guardat != null) guardat.SetLocal(IdiomaActualKey, language);
    }
}
