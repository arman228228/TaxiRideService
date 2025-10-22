namespace Domain.Entities;

public enum RideStatus
{
    Started,
    Canceled,
    Finished
}

public class Ride
{
    public int Id { get; private set; }

    public int DriverId { get; private set; }
    public int PassengerId { get; private set; }
    
    public int Cost { get; private set; }
    
    public string PickupLocation { get; private set; }
    public string DropOffLocation { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public RideStatus Status { get; private set; }

    public void SetStatus(RideStatus status) => Status = status;
}