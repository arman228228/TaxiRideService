using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RideController : ControllerBase
{
    private readonly IRideService _rideService;
    
    public RideController(IRideService rideService)
    {
        _rideService = rideService;
    }

    [HttpPost]
    public async Task<ActionResult<Ride>> CreateAsync(RideCreateDto rideDto)
    {
        var createdRide = await _rideService.CreateAsync(rideDto);
        return Ok(createdRide);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RideDto>> GetByIdAsync(int id)
    {
        var ride = await _rideService.GetByIdAsync(id);
        if(ride == null) return NotFound($"Ride with id: {id} not found");
        return Ok(ride);
    }
    
    [HttpGet]
    public async Task<ActionResult<RideDto>> GetAllAsync()
    {
        var rides = await _rideService.GetAllAsync();
        return Ok(rides);
    }

    [HttpPut("start")]
    public async Task<ActionResult> StartRideAsync(int id)
    {
        await _rideService.StartRideAsync(id);
        return Ok();
    }
    
    [HttpPut("cancel")]
    public async Task<ActionResult> CancelRideAsync(int id)
    {
        await _rideService.CancelRideAsync(id);
        return Ok();
    }
    
    [HttpPut("complete")]
    public async Task<ActionResult> CompleteRideAsync(int id)
    {
        await _rideService.CompleteRideAsync(id);
        return Ok();
    }
}