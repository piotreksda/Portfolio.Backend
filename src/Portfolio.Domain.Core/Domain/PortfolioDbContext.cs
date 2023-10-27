using Portfolio.Domain.Core.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Domain.Core.Domain;

public class PortfolioDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public PortfolioDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<ApplicationUser> AspNetUsers { get; set; }
    public DbSet<ApplicationRole> AspNetRoles { get; set; }
}
