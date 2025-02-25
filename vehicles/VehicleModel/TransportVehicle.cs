namespace VehicleModel;

public class TransportVehicle : MotorizedVehicle
{
    public TransportVehicle(string brand, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption) : base(brand, model, currentFuelState, fuelCapacity, source, averageSpeed, baseConsumption)
    {
    }
    public override double Drive(double distance, RoadCondition condition)
    {
        throw new NotImplementedException();
    }
}