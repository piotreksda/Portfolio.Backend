using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTemplateEngine.Templates.Shared;

namespace RazorTemplateEngine.Abstractions;

public class EmailViewModel : PageModel
{
    public string Subject { get; init; }
    public int LangId { get; init; }
}