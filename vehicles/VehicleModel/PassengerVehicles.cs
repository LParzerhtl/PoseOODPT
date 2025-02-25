namespace VehicleModel;

public class PassengerVehicles : MotorizedVehicle
{
    public PassengerVehicles(string name, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption) : base(name, model, currentFuelState, fuelCapacity, source, averageSpeed, baseConsumption)
    {
    }
    
    public override double Drive(double distance, RoadCondition condition)
    {
        double speed = CalculateSpeed(condition);
        if(condition == RoadCondition.Highway && speed > 130)
        {
            speed = 130;
        } 
        else if(condition == RoadCondition.City && speed > 50)
        {
            speed = 50;
        }

        double time = 0;
        if (CheckFuelBeforeDrive(distance, condition))
        {
            CurrentFuelState -= (distance / 100 * CalculateConsumption(condition));
            time = distance / speed;
            TravelledDistance += distance;
        }

        return time;
    }

    
}