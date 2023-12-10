using Portfolio.Shared.Kernel.Domain.Constants;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

public interface ITwoFaFactory
{
    ITwoFaStrategy CreateStrategy(TwoFaStrategyTypes twoFaStrategyType);
}