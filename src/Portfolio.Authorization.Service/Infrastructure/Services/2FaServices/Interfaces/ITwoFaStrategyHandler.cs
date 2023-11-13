using Portfolio.Domain.Core.Infrastructure.Contatints;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

public interface ITwoFaStrategyHandler
{
    void SetStrategy(ITwoFaStrategy strategy);
    Task GenerateAndSend2FaCode(int userId);
    Task<bool> Validate2FaCode(int userId, string code);
}