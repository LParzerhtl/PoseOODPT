namespace VehicleModel;

public class PassengerVehicles : MotorizedVehicle
{
    public PassengerVehicles(string name, string model, int year) : base(name, model, year)
    {
    }
    
    public override double Drive(double distance, DrivingCondition condition)
    {
        return 42.4;
    }
}