using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Core.Primitives;

namespace Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IIdentityContext _identityContext;
    public UpdateAuditableEntitiesInterceptor(IIdentityContext identityContext)
    {
        _identityContext = identityContext;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        int? userId = this._identityContext.UserId;
        UpdateEntities(eventData, userId);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        int? userId = this._identityContext.UserId;
        UpdateEntities(eventData, userId);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContextEventData eventData, int? userId)
    {
        var dbContext = eventData.Context ??
                        throw new UnreachableException("The 'eventData.Context' property is unexpectedly null.");

        var audibleEntities = dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entityEntry in audibleEntities)
        {
            // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
            switch (entityEntry.State)
            {
                case EntityState.Added when entityEntry.Entity.CreatedAt == default:
                    entityEntry.Entity.SetCreatedValues(userId ?? -1, DateTime.UtcNow);
                    break;
                case EntityState.Modified:
                    entityEntry.Entity.UpdateModifiedValues(userId ?? null, DateTime.UtcNow);
                    break;
            }
        }
    }
}