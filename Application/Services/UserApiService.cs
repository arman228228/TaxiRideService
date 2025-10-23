using System.Net;
using Application.Interfaces;

namespace Application.Services;

public class UserApiService : IUserApiClientService
{
    private readonly HttpClient _httpClient;
    
    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> DriverExistsAsync(int driverId)
    {
        var response = await _httpClient.GetAsync($"/api/driver/{driverId}");
        if (response.StatusCode == HttpStatusCode.OK) return true;
        if (response.StatusCode == HttpStatusCode.NotFound) return false;
        
        throw new HttpRequestException($"Failed to check driver existence: {response.StatusCode}");
    }
    
    public async Task<bool> UserExistsAsync(int userId)
    {
        var response = await _httpClient.GetAsync($"/api/user/{userId}");
        if (response.StatusCode == HttpStatusCode.OK) return true;
        if (response.StatusCode == HttpStatusCode.NotFound) return false;
        
        throw new HttpRequestException($"Failed to check user existence: {response.StatusCode}");
    }
}