using Portfolio.Domain.Core.Infrastructure.Contatints;
using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Core.Domain.Models;

public record ExceptionModel
{
    public int Status { get; set; }
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public ForceFrontExceptionAction ForceAction { get; init; }
}
