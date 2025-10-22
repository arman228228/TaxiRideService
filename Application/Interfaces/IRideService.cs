using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IRideService
{
    public Task<int> CreateAsync(RideCreateDto rideDto);
    public Task<RideDto?> GetByIdAsync(int id);
    public Task<IEnumerable<RideDto>> GetAllAsync();
    public Task StartRideAsync(int id);
    public Task CancelRideAsync(int id);
    public Task CompleteRideAsync(int id);
}