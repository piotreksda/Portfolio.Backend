using Portfolio.Shared.Kernel.Domain.Core.Entities;

namespace Portfolio.Shared.Kernel.Application.Abstractions;

public interface IActionTokenRepository : IRootRepository<ActionToken,int>
{
    public Task<ActionToken> GetByUserIdAndValue(int userId, string value);
}