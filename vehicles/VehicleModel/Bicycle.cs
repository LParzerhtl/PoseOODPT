namespace VehicleModel;

public class Bicycle : Vehicle
{
    public Bicycle(string brand, string model, double averageSpeed) : base(brand, model, averageSpeed)
    {
        
    }
    
    public override double Drive(double distance, RoadCondition condition)
    {
        double speed = condition switch
        {
            RoadCondition.Highway => 0,
            RoadCondition.City => 0.6,
            RoadCondition.Offroad => 0.5,
            _ => 0.9
        };
        speed = AverageSpeed * speed;
        double time = distance / speed;
        TravelledDistance += time * speed;
        return time;
    }
    
    
}