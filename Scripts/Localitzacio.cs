using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

[CreateAssetMenu]
public class Localitzacio : ScriptableObject
{
    const string IDIOMA_ACTUAL_GUARDAT_KEY = "IdiomaActual";

    public string IdiomaActualKey => IDIOMA_ACTUAL_GUARDAT_KEY;

    public Guardat guardat;
    public Locale perDefecte;

    [ContextMenu("RecuperarIdiomaGuardat")]
    public void RecuperarIdiomaGuardat()
    {
        //CARREGAR el guardat abans de fer aixo, si no, no rebras res.
        Debug.Log((int)guardat.Get(IdiomaActualKey, -1));
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
        if(_locale > LocalizationSettings.AvailableLocales.Locales.Count)
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
}
