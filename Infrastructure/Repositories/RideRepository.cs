using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RideRepository : IRideRepository
{
    private readonly AppDbContext _context;

    public RideRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Ride> CreateAsync(Ride ride)
    {
        _context.Add(ride);
        await _context.SaveChangesAsync();
        return ride;
    }

    public async Task<Ride?> GetByIdAsync(int id)
    {
        return await _context.Rides.FirstOrDefaultAsync(r => r.Id == id);
    }
    
    public async Task<IEnumerable<Ride>> GetAllAsync()
    {
        return await _context.Rides.ToListAsync();
    }
    
    public async Task UpdateAsync(Ride ride)
    {
        _context.Rides.Update(ride);
        await _context.SaveChangesAsync();
    }
}