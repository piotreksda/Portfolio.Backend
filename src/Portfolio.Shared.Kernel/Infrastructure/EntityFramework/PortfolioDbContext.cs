using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Application.Abstractions;
using Portfolio.Shared.Kernel.Domain.Auth.Entities;
using Portfolio.Shared.Kernel.Domain.Auth.Entities.Configurations;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Domain.Core.Entities.Configurations;
using Portfolio.Shared.Kernel.Domain.Dictionary.Entities;
using Portfolio.Shared.Kernel.Domain.Dictionary.Entities.Configurations;

namespace Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

public class PortfolioDbContext : DbContext
{
    private readonly IIdentityContext _identityContext;
    public PortfolioDbContext(DbContextOptions options, IIdentityContext identityContext) : base(options)
    {
        _identityContext = identityContext;
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<LoginHistory> LoginHistories { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<PermissionPermissionSet> PermissionsPermissionSets { get; set; }
    public DbSet<PermissionSet> PermissionSets { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<RolePermissionSet> RolesPermissionSets { get; set; }
    public DbSet<UserRole> UsersRoles { get; set; }
    public DbSet<ActionToken> ActionTokens { get; set; }
    
    public DbSet<SmtpConfiguration> SmtpConfigurations { get; set; }
    
    public DbSet<Translation> Translations { get; set; }
    public DbSet<Language> Languages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.AddInterceptors(new UpdateAuditableEntitiesInterceptor(_identityContext));

        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
        modelBuilder.ApplyConfiguration(new LoginHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionPermissionSetConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionSetConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionSetConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new TranslationConfiguration());
        modelBuilder.ApplyConfiguration(new TranslationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ActionTokenConfiguration());


        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<ApplicationRole>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<LoginHistory>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Permission>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<PermissionPermissionSet>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<PermissionSet>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<RefreshToken>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<RolePermissionSet>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<UserRole>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<SmtpConfiguration>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Translation>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Language>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<ActionToken>().HasQueryFilter(x => !x.Deleted);
    }
}