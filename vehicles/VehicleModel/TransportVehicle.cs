namespace VehicleModel;

public class TransportVehicle : MotorizedVehicle
{
    public TransportVehicle(string brand, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption) : base(brand, model, currentFuelState, fuelCapacity, source, averageSpeed, baseConsumption)
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="distance"></param>
    /// <param name="condition"></param>
    /// <returns>Returns time in hours, if the CheckFuelBeforeDrive is true</returns>
    public override double Drive(double distance, RoadCondition condition)
    {
        double speed = CalculateSpeed(condition);
        double consumption = CalculateConsumption(condition);
        
        if (condition == RoadCondition.City && speed > 50)
        {
            speed = 50;
        }
        else if (condition == RoadCondition.Highway && speed > 130)
        {
            speed = 130;
        }

        double time = 0;
        if (CheckFuelBeforeDrive(distance, condition))
        {
            CurrentFuelState -= (distance / 100 * consumption);
            time = (distance / speed);
            TravelledDistance += distance;
        }
        
        return time;
    }
    
    
    
    
    
}