using Microsoft.Extensions.Localization;

namespace Utilities.LocalizationService;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public class StringLocalizerLocalizationService<T>(IStringLocalizer<T> localizer) : ILocalizationService
{
    public string Translate(string key, params object[] parameters)
    {
        return string.Format(localizer[key].ToString(), parameters);
    }
}