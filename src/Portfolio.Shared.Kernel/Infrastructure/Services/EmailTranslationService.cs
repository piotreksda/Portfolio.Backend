using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Domain.Dictionary.Entities;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;
using Portfolio.Shared.Kernel.Infrastructure.Utils;
using RazorTemplateEngine.Abstractions;
using RazorTemplateEngine.Templates.Shared;
using RazorTemplateEngine.Views.RegistrationConfirmation;

namespace Portfolio.Shared.Kernel.Infrastructure.Services;

public class EmailTranslationService : IEmailTranslationService
{
    private readonly PortfolioDbContext _context;

    public EmailTranslationService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<LayoutTranslation> GetLayoutTranslation(int langId)
    {
        List<string> translationKeys = TranslationsKeysTools.GetListOfKeys(typeof(EmailTranslationsKeys.LayoutTranslationsKeys));

        var translations = await GetAllTranslationsByKeys(translationKeys, langId);

        var result = new LayoutTranslation()
        {
            Header = GetTranslationFromDictionary(translations, EmailTranslationsKeys.LayoutTranslationsKeys.Header),
            Footer = GetTranslationFromDictionary(translations, EmailTranslationsKeys.LayoutTranslationsKeys.Footer)
        };
        
        return result;
    }

    public async Task<RegistrationConfirmationTranslationModel> GetRegistrationConfirmationTranslation(int langId)
    {
        List<string> translationKeys = TranslationsKeysTools.GetListOfKeys(typeof(EmailTranslationsKeys.EmailConfirmationKeys));

        var translations = await GetAllTranslationsByKeys(translationKeys, langId);

        var result = new RegistrationConfirmationTranslationModel()
        {
            ConfirmEmail = GetTranslationFromDictionary(translations, EmailTranslationsKeys.EmailConfirmationKeys.ConfirmEmail),
            MainBody = GetTranslationFromDictionary(translations, EmailTranslationsKeys.EmailConfirmationKeys.MainBody),
            ConfirmEmailButton = GetTranslationFromDictionary(translations, EmailTranslationsKeys.EmailConfirmationKeys.ConfirmEmailButton)
        };
        
        return result;
    }

    private async Task<Dictionary<string, string>> GetAllTranslationsByKeys(List<string> keys, int langId)
    {
        return await _context.Translations
            .Where(x => x.LangId == langId && keys.Contains(x.TranslationKey))
            .ToDictionaryAsync(x => x.TranslationKey, x=> x.TranslationContent);
    }

    private string GetTranslationFromDictionary(Dictionary<string, string> dict, string key)
    {
        return dict[key] ?? key;
    }
}