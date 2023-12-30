namespace Utilities.LocalizationService;

public interface ILocalizationService
{
    public string Translate(string key, params object[] parameters);
}