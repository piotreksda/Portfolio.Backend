using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Shared.Kernel.Domain.Core.Models;

public record ExceptionModel
{
    public int Status { get; set; }
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public ForceFrontExceptionAction ForceAction { get; init; }
}
