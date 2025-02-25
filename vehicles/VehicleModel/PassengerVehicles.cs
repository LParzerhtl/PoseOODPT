namespace VehicleModel;

public class PassengerVehicles
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public PassengerVehicles(string name, string model, int year)
    {
        Make = name;
        Model = model;
        Year = year;
    }
    
    public double Drive(double distance, DrivingCondition condition)
    {
        return 42.4;
    }
}