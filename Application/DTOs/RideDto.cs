using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class RideDto
{
    [Range(1, int.MaxValue)]
    public int DriverId { get; init; }
    
    [Range(1, int.MaxValue)]
    public int PassengerId { get; init; }
    
    [Range(0.01, 1_000_000)]
    public decimal Cost { get; init; }
    
    [Required]
    [StringLength(64)]
    public string PickupLocation { get; init; }
    
    [Required]
    [StringLength(64)]
    public string DropOffLocation { get; init; }
}