namespace VehicleModel;

public abstract class Vehicle
{
    public string Brand { get; }
    public string Model { get;}
    public double TravelledDistance { get; set; }
    public double AverageSpeed { get; }

    public Vehicle(string name, string model, double averageSpeed)
    {
        Brand = name;
        Model = model;
        AverageSpeed = averageSpeed;
    }

    public abstract double Drive(double distance, RoadCondition condition);
}