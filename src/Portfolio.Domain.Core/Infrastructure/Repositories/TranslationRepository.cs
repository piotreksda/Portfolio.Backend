using Portfolio.Domain.Core.Application.Abstractions;
using Portfolio.Domain.Core.Domain;
using Portfolio.Domain.Core.Domain.Dictionary.Entities;
using Portfolio.Domain.Core.Infrastructure.EntityFramework;

namespace Portfolio.Domain.Core.Infrastructure.Repositories;

public class TranslationRepository : RootRepository<Translation, Guid>, ITranslationRepository<Translation, Guid>
{
    public TranslationRepository(PortfolioDbContext dbContext) : base(dbContext)
    {
    }
}