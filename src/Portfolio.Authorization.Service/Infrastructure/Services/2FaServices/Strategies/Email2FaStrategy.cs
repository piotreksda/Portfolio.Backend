using Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Strategies;

public class Email2FaStrategy : ITwoFaStrategy
{
    public async Task SendCodeAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ValidateCode(int userId, string code)
    {
        throw new NotImplementedException();
    }
}