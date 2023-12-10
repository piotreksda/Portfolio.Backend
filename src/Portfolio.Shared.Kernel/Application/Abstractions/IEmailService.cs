using Portfolio.Shared.Kernel.Domain.Constants;
using RazorTemplateEngine.Abstractions;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IEmailService
{
    Task SendEmailAsync<TModel>(string to, MailTemplates template, TModel model) where TModel : EmailViewModel;
}