using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class RideProfile : Profile
{
    public RideProfile()
    {
        CreateMap<RideCreateDto, Ride>();
        CreateMap<Ride, RideCreateDto>();
    }
}