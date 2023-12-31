namespace Utilities.LocalizationService;

public interface ILocalizationService<T> where T : class
{
    public string Translate(string key, params object[] parameters);
}