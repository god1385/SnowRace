using Lean.Localization;
using UnityEngine;

public class LocalizationInitialize : MonoBehaviour
{
    [SerializeField] private ImageTranslator _imageTranslator;
    [SerializeField] private InterstitialAdOnstart _interstitialAdOnstart;

    private string _language;
    private LeanLocalization _lean;

    public string Language => _language;

    private void Start()
    {  
        LocalizationStringsConstants.SetLaunge("en");
         _imageTranslator.TranslateText(_language);
         PlayerPrefs.SetString(Constants.LangKey, _language);
        
        _lean = GetComponent<LeanLocalization>();
        switch (_language)
        {
            case "ru":
                _lean.SetCurrentLanguage("Russian");
                break;
            case "en":
                _lean.SetCurrentLanguage("English");
                break;
            case "tr":
                _lean.SetCurrentLanguage("Turkish");
                break;
        }
        _interstitialAdOnstart?.ShowInterstitialAd();
    }
}
