using System.Threading.Tasks;
using RazorTemplateEngine.Templates.Shared;
using RazorTemplateEngine.Views.RegistrationConfirmation;

namespace RazorTemplateEngine.Abstractions;

public interface IEmailTranslationService
{
    Task<LayoutTranslation> GetLayoutTranslation(int langId);

    Task<RegistrationConfirmationTranslationModel> GetRegistrationConfirmationTranslation(int langId);
}