using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTemplateEngine.Abstractions;
using RazorTemplateEngine.Templates.Shared;

namespace RazorTemplateEngine.Views.RegistrationConfirmation;

public class RegistrationConfirmationModel : EmailViewModel
{
    public string UserName { get; init; }
    public string Url { get; init; }
    public string Token { get; init; }
}