using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
using AutoMapper;

namespace Application.Services;

public class RideService : IRideService
{
     private readonly IRideRepository _repository;
     private readonly IMapper _mapper;

     public RideService(IRideRepository repository, IMapper mapper)
     {
          _repository = repository;
          _mapper = mapper;
     }
     
     public async Task<int> CreateAsync(RideCreateDto rideDto)
     {
          var ride = _mapper.Map<Ride>(rideDto);
          var created  = await _repository.CreateAsync(ride);
          return created.Id;
     }

     public async Task<RideDto?> GetByIdAsync(int id)
     {
          var ride = await _repository.GetByIdAsync(id);
          if (ride == null) return null;

          return _mapper.Map<RideDto>(ride);
     }
     
     public async Task<IEnumerable<RideDto>> GetAllAsync()
     {
          var rides = await _repository.GetAllAsync();
          if (!rides.Any()) return Enumerable.Empty<RideDto>();

          return _mapper.Map<IEnumerable<RideDto>>(rides);
     }

     public async Task StartRideAsync(int id)
     { 
          var ride = await _repository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Started);
          
          await _repository.UpdateAsync(ride);
     }
     
     public async Task CancelRideAsync(int id)
     { 
          var ride = await _repository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Canceled);
          
          await _repository.UpdateAsync(ride);
     }
     
     public async Task CompleteRideAsync(int id)
     { 
          var ride = await _repository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Finished);
          
          await _repository.UpdateAsync(ride);
     }
}