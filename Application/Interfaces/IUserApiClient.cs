namespace Application.Interfaces;

public interface IUserApiClientService
{
    Task<bool> DriverExistsAsync(int driverId);
    Task<bool> UserExistsAsync(int userId);
}