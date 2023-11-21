using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Core.Domain.Auth.Entities;
using Portfolio.Domain.Core.Domain.Auth.Entities.Configurations;

namespace Portfolio.Domain.Core.Domain;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions options) : base(options)
    {

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
    }
}