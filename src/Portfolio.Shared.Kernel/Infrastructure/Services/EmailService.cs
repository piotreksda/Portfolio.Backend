using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Exceptions.InternalServerErrorExceptions;
using RazorTemplateEngine.Abstractions;
using RazorTemplateEngine.Services;

namespace Portfolio.Shared.Kernel.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly ISmtpConfigurationService _smtpConfigurationService;
    private readonly IRazorViewToStringRenderer _razorRenderer;
    private readonly ILogger<IEmailService> _logger;

    public EmailService(SmtpClient smtpClient, IRazorViewToStringRenderer razorRenderer, ISmtpConfigurationService smtpConfigurationService, ILogger<IEmailService> logger)
    {
        _smtpClient = smtpClient;
        _razorRenderer = razorRenderer;
        _smtpConfigurationService = smtpConfigurationService;
        _logger = logger;
    }

    public async Task SendEmailAsync<TModel>(string to, MailTemplates template, TModel model) where TModel : EmailViewModel
    {
        string templatePath = GetTemplatePath(template);
        
        string emailBody = await RenderTemplateAsync(templatePath, model);

        await SendEmailInternalAsync(to, model.Subject, emailBody);
    }

    private string GetTemplatePath(MailTemplates template)
    {
        return template switch
        {   MailTemplates.RegistrationConfirmation => "RegistrationConfirmation/RegistrationConfirmation",
            _ => throw new NotImplementedException()
        };
    }
    
    private async Task SendEmailInternalAsync(string to, string subject, string body)
    {
        SmtpConfiguration smtpConfiguration = await _smtpConfigurationService.GetSmtpConfigurationAsync();
        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpConfiguration.SendFrom),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        
        mailMessage.To.Add(to);

        try
        {
            await _smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new UnableToSendEmailException();
        }
    }
    
    private async Task<string> RenderTemplateAsync<TModel>(string templatePath, TModel model)
    {
        return await _razorRenderer.RenderViewToStringAsync(templatePath, model);
    }
}