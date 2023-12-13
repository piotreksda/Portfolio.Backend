using Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Strategies;

public class TwoFaFactoryFactory : ITwoFaFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public TwoFaFactoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public ITwoFaStrategy CreateStrategy(TwoFaStrategyTypes twoFaStrategyType) =>
        twoFaStrategyType switch
        {
            TwoFaStrategyTypes.Email2FaStrategy => _serviceProvider.GetService<Email2FaStrategy>() 
                                                 ?? throw new InvalidOperationException(),
            TwoFaStrategyTypes.Sms2FaStrategy => _serviceProvider.GetService<Sms2FaStrategy>() 
                                               ?? throw new InvalidOperationException(),
            TwoFaStrategyTypes.Totp2FaStrategy => _serviceProvider.GetService<Totp2FaStrategy>() 
                                                ?? throw new InvalidOperationException(),
            _ => throw new NotImplementedException()
        };
}