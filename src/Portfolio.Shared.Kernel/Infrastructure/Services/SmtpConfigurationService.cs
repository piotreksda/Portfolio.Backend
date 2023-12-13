using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Kernel.Domain.Core.Entities;
using Portfolio.Shared.Kernel.Infrastructure.EntityFramework;

namespace Portfolio.Shared.Kernel.Infrastructure.Services;

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