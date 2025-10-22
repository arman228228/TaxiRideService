using Domain.Entities;

namespace Application.Interfaces;

public interface IRideRepository
{
    public Task<Ride> CreateAsync(Ride rideDto);
    public Task<Ride?> GetByIdAsync(int id);
    public Task<IEnumerable<Ride>> GetAllAsync();
    public Task UpdateAsync(Ride ride);
}