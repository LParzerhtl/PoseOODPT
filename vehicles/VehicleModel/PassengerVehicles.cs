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
        if(condition == RoadCondition.Highway && speed > 130)
        {
            speed = 130;
        } 
        else if(condition == RoadCondition.City && speed > 50)
        {
            speed = 50;
        }
        
        
        return speed;
    }
}