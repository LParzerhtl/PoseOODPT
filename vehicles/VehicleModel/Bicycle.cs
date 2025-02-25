namespace VehicleModel;

public class Bicycle : Vehicle
{
    public Bicycle(string brand, string model) : base(brand, model)
    {
        
    }
    
    public override double Drive(double distance, RoadCondition condition)
    {
        return distance * 0.1;
    }
}