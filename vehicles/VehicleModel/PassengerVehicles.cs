namespace VehicleModel;

public class PassengerVehicles : MotorizedVehicle
{
    public PassengerVehicles(string name, string model) : base(name, model)
    {
    }
    
    public override double Drive(double distance, RoadCondition condition)
    {
        return 42.4;
    }
}