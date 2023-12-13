using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Repositories;

public class ActionTokenRepository : RootRepository<ActionToken, int>, IActionTokenRepository
{
    public ActionTokenRepository(PortfolioDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ActionToken> GetByUserIdAndValue(int userId, string value)
    {
        return await _dbContext.ActionTokens
            .SingleOrDefaultAsync(x => x.Token == value && x.UserId == userId);
    }
}