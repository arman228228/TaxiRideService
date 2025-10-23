using Application.DTOs;
using Domain.Entities;
using Application.Interfaces;
using AutoMapper;

namespace Application.Services;

public class RideService : IRideService
{
     private readonly IRideRepository _rideRepository;
     private readonly IUserApiClientService _userApiClient;
     private readonly IMapper _mapper;

     public RideService(IRideRepository rideRepository, IUserApiClientService userApiClient, IMapper mapper)
     {
          _rideRepository = rideRepository;
          _userApiClient = userApiClient;
          _mapper = mapper;
     }
     
     public async Task<int> CreateAsync(RideCreateDto rideDto)
     {
          if (rideDto.DriverId == rideDto.PassengerId) 
               throw new InvalidOperationException($"Passenger id and driver id cannot be the same");
          if (await _userApiClient.UserExistsAsync(rideDto.PassengerId) == false) 
               throw new InvalidOperationException($"Passenger with id: {rideDto.PassengerId} does not exist");
          if (await _userApiClient.DriverExistsAsync(rideDto.DriverId) == false) 
               throw new InvalidOperationException($"Driver with id: {rideDto.DriverId} does not exist");
               
          var ride = _mapper.Map<Ride>(rideDto);
          var created  = await _rideRepository.CreateAsync(ride);
          return created.Id;
     }

     public async Task<RideDto?> GetByIdAsync(int id)
     {
          var ride = await _rideRepository.GetByIdAsync(id);
          if (ride == null) return null;

          return _mapper.Map<RideDto>(ride);
     }
     
     public async Task<IEnumerable<RideDto>> GetAllAsync()
     {
          var rides = await _rideRepository.GetAllAsync();
          if (!rides.Any()) return Enumerable.Empty<RideDto>();

          return _mapper.Map<IEnumerable<RideDto>>(rides);
     }

     public async Task StartRideAsync(int id)
     { 
          var ride = await _rideRepository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Started);
          
          await _rideRepository.UpdateAsync(ride);
     }
     
     public async Task CancelRideAsync(int id)
     { 
          var ride = await _rideRepository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Canceled);
          
          await _rideRepository.UpdateAsync(ride);
     }
     
     public async Task CompleteRideAsync(int id)
     { 
          var ride = await _rideRepository.GetByIdAsync(id);
          if (ride == null) throw new KeyNotFoundException($"Ride with id: {id} not found");

          ride.SetStatus(RideStatus.Finished);
          
          await _rideRepository.UpdateAsync(ride);
     }
}