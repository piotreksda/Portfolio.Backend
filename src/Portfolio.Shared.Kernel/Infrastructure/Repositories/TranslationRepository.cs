using Portfolio.Shared.Kernel.Domain;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Dictionary.Entities;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Repositories;

public class TranslationRepository : RootRepository<Translation, int>, ITranslationRepository<Translation, int>
{
    public TranslationRepository(PortfolioDbContext dbContext) : base(dbContext)
    {
    }
}