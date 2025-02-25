namespace VehicleModel;

public class TransportVehicle : MotorizedVehicle
{
    public TransportVehicle(string brand, string model) : base(brand, model)
    {
    }
    public override double Drive(double distance, RoadCondition condition)
    {
        throw new NotImplementedException();
    }
}