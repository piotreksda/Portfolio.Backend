using Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;
using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices;

public class TwoFaService : ITwoFaService
{
    private readonly ITwoFaFactory _twoFaFactory;
    private readonly ITwoFaStrategyHandler _2faStrategyHandler;
    
    public TwoFaService(ITwoFaFactory twoFaFactory, ITwoFaStrategyHandler faStrategyHandler)
    {
        _twoFaFactory = twoFaFactory;
        _2faStrategyHandler = faStrategyHandler;
    }

    public async Task Send2FaCode(int userId, TwoFaStrategyTypes strategyType)
    {
        prepareStrategyHandler(strategyType);
        await _2faStrategyHandler.GenerateAndSend2FaCode(userId);
    }

    public async Task<bool> Validate2FaCode(int userId, string code, TwoFaStrategyTypes strategyType)
    {
        prepareStrategyHandler(strategyType);
        return await _2faStrategyHandler.Validate2FaCode(userId, code);
    }

    private void prepareStrategyHandler(TwoFaStrategyTypes strategyType)
    {
        ITwoFaStrategy strategy = _twoFaFactory.CreateStrategy(strategyType);
        _2faStrategyHandler.SetStrategy(strategy);
    }
}