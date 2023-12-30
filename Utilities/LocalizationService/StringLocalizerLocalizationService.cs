using Microsoft.Extensions.Localization;

namespace Utilities.LocalizationService;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public class StringLocalizerLocalizationService<T>(IStringLocalizer<T> localizer) : ILocalizationService<T> where T : class
{
    public string Translate(string key, params object[] parameters)
    {
        return string.Format(localizer[key].ToString(), parameters);
    }
}