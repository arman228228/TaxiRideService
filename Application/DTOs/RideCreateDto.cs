using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class RideCreateDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int DriverId { get; init; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int PassengerId { get; init; }
    
    [Range(0.01, double.MaxValue)]
    public decimal Cost { get; init; }
    
    [Required]
    [StringLength(64)]
    public string PickupLocation { get; init; }
    
    [Required]
    [StringLength(64)]
    public string DropOffLocation { get; init; }
}