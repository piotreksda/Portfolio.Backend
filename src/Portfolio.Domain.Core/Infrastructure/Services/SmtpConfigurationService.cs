using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Core.Domain.Core.Entities;
using Portfolio.Domain.Core.Infrastructure.EntityFramework;

namespace Portfolio.Domain.Core.Infrastructure.Services;

public class SmtpConfigurationService : ISmtpConfigurationService
{
    private readonly PortfolioDbContext _context;

    public SmtpConfigurationService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<SmtpConfiguration> GetSmtpConfigurationAsync()
    {
        return await _context.SmtpConfigurations.SingleOrDefaultAsync();
        // Handle the scenario where configuration might not be found
    }
}

public interface ISmtpConfigurationService
{
    Task<SmtpConfiguration> GetSmtpConfigurationAsync();
}