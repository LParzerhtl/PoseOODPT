namespace VehicleModel;

public abstract class Vehicle
{
    public string Brand { get; }
    public string Model { get;}
    public double TravelledDistance { get; set; }

    public Vehicle(string name, string model)
    {
        Brand = name;
        Model = model;
    }

    public abstract double Drive(double distance, RoadCondition condition);
}