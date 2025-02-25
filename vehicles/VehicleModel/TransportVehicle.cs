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
    
    public double CalculateSpeed(RoadCondition condition)
    {
        double speed = condition switch
        {
            RoadCondition.Highway => 1.2,
            RoadCondition.City => 0.6,
            RoadCondition.Offroad => 0.5,
            _ => 0.9
        };
        speed = speed * AverageSpeed;
        if(condition == RoadCondition.Highway && speed > 80)
        {
            speed = 80;
        } 
        else if(condition == RoadCondition.City && speed > 50)
        {
            speed = 50;
        }
        
        
        return speed;
    }
}