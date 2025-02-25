namespace VehicleModel;

public abstract class MotorizedVehicle : Vehicle
{
    public double FuelCapacity { get; }
    public double AverageSpeed { get; }
    public double BaseConsumption { get; }
    public double CurrentFuelState { get; set; }
    public double FuelCost { get; set; }
    public EnergySource Source { get; set; }
    
    public MotorizedVehicle(string name, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption): base(name, model)
    {
        FuelCapacity = fuelCapacity;
        AverageSpeed = averageSpeed;
        BaseConsumption = baseConsumption;
        CurrentFuelState = currentFuelState;
        Source = source;
    }

    public bool CheckForRefuel()
    {
        throw new NotImplementedException();
    }

    
}