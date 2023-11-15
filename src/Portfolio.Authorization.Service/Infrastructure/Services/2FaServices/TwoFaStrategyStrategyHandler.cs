using Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices;

public class TwoFaStrategyStrategyHandler : ITwoFaStrategyHandler
{
    private ITwoFaStrategy? _faStrategy;
    
    public void SetStrategy(ITwoFaStrategy strategy)
    {
        _faStrategy = strategy;
    }

    public async Task GenerateAndSend2FaCode(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Validate2FaCode(int userId, string code)
    {
        throw new NotImplementedException();
    }
    
}