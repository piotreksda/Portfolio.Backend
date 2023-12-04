using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTemplateEngine.Abstractions;

namespace RazorTemplateEngine.Views.RegistrationConfirmation;

public class RegistrationConfirmationModel(string Test) : PageModel, IEmailViewModel
{
    public string Subject { get; init; } = "string";
    public string Test { get; init; } = Test;

    public void Deconstruct(out string Test)
    {
        Test = this.Test;
    }
}