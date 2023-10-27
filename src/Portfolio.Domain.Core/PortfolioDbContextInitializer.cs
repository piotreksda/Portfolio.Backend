using Portfolio.Domain.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Portfolio.Domain.Core.Domain;

public class PortfolioDbContextInitializer
{
    private readonly PortfolioDbContext _context;

    public PortfolioDbContextInitializer(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
                await _context.Database.MigrateAsync();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public string GenerateCreateScript()
    {
        try
        {
            if (_context.Database.IsNpgsql())
                return _context.Database.GenerateCreateScript();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

        return "";
    }
}

