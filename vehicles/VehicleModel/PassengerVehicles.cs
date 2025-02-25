namespace VehicleModel;

public class PassengerVehicles : MotorizedVehicle
{
    public PassengerVehicles(string name, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption) : base(name, model, currentFuelState, fuelCapacity, source, averageSpeed, baseConsumption)
    {
    }
    
    public override double Drive(double distance, RoadCondition condition)
    {
        return 42.4;
    }
}