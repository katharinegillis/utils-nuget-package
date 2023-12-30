using Microsoft.Extensions.Localization;
using Moq;
using Utilities.LocalizationService;

namespace Utilities.Tests.LocalizationService;

public class StringLocalizerLocalizationServiceTests
{
    [Test]
    public void StringLocalizerLocalizationService_Is_A_ILocalizationService()
    {
        var localizer = Mock.Of<IStringLocalizer<StringLocalizerLocalizationServiceTests>>();
        
        var service = new StringLocalizerLocalizationService<StringLocalizerLocalizationServiceTests>(localizer);
        
        Assert.That(service, Is.InstanceOf<ILocalizationService>());
    }

    [Test]
    public void StringLocalizerLocalizationService_Translate_Returns_Translated_String()
    {
        var localizerMock = new Mock<IStringLocalizer<StringLocalizerLocalizationServiceTests>>();
        localizerMock.Setup(localizer => localizer["Untranslated string"])
            .Returns(new LocalizedString("Untranslated string", "Translated string"));
        
        var service = new StringLocalizerLocalizationService<StringLocalizerLocalizationServiceTests>(localizerMock.Object);

        var result = service.Translate("Untranslated string");
        
        Assert.That(result, Is.EqualTo("Translated string"));
    }

    [Test]
    public void StringLocalizerLocalizationService_Translate_With_Parameters_Returns_Translated_Formatted_String()
    {
        var localizerMock = new Mock<IStringLocalizer<StringLocalizerLocalizationServiceTests>>();
        localizerMock.Setup(localizer => localizer["Untranslated unformatted string {0}"])
            .Returns(new LocalizedString("Untranslated unformatted string {0}", "Translated string {0}"));

        var service =
            new StringLocalizerLocalizationService<StringLocalizerLocalizationServiceTests>(localizerMock.Object);

        var result = service.Translate("Untranslated unformatted string {0}", "blah");
        
        Assert.That(result, Is.EqualTo("Translated string blah"));
    }
}