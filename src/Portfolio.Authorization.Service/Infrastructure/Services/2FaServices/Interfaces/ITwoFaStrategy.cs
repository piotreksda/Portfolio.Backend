namespace Portfolio.Authorization.Service.Infrastructure.Services._2FaServices.Interfaces;

public interface ITwoFaStrategy
{
    Task SendCodeAsync(int userId);
    Task<bool> ValidateCode(int userId, string code);
}