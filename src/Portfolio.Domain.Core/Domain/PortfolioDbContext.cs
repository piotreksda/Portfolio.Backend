using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Core.Domain.Auth.Entities;

namespace Portfolio.Domain.Core.Domain;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<ApplicationUser> AspNetUsers { get; set; }
    public DbSet<ApplicationRole> AspNetRoles { get; set; }
}
