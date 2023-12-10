using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

public interface ITwoFaService
{
    Task Send2FaCode(int userId, TwoFaStrategyTypes strategyType);

    Task<bool> Validate2FaCode(int userId, string code, TwoFaStrategyTypes strategyType);
}