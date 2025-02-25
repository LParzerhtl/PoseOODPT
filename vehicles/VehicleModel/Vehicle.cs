namespace VehicleModel;

public abstract class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string name, string model, int year)
    {
        
    }

    public abstract double Drive(double distance, DrivingCondition condition);
}