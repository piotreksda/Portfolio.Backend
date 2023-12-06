using Portfolio.Domain.Core.Domain.Constants;
using RazorTemplateEngine.Abstractions;

namespace Portfolio.Domain.Core.Application.Abstractions;

public interface IEmailService
{
    Task SendEmailAsync<TModel>(string to, MailTemplates template, TModel model) where TModel : IEmailViewModel;
}