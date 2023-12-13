using Portfolio.Shared.Kernel.Domain.Constants;
using Portfolio.Shared.Kernel.Domain.Core.Entities;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IActionTokenService
{
    public Task<string> GenerateActionToken(ActionTokenTypes type, int userId);
    public Task<int> ValidateActionToken(ActionTokenTypes type, string jwtToken, bool markUsed);
}