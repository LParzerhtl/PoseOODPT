namespace VehicleModel;

public abstract class MotorizedVehicle : Vehicle
{
    public double FuelCapacity { get; }
    
    public double BaseConsumption { get; }
    public double CurrentFuelState { get; set; }
    public double FuelCost { get; set; }
    public EnergySource Source { get; set; }
    
    public MotorizedVehicle(string name, string model, double currentFuelState, double fuelCapacity, EnergySource source, double averageSpeed, double baseConsumption): base(name, model, averageSpeed)
    {
        FuelCapacity = fuelCapacity;
       
        BaseConsumption = baseConsumption;
        CurrentFuelState = currentFuelState;
        Source = source;
    }

    public bool CheckForRefuel()
    {
        if (CurrentFuelState < FuelCapacity)
        {
            return true;
        }
        return false;
    }

    public double CalculateConsumption(RoadCondition condition)
    {
        double mul = condition switch
        {
            RoadCondition.Backroad => 1.1,
            RoadCondition.Highway => 0.8,
            RoadCondition.Offroad => 1.5,
            _ => 1.2
        };
        return BaseConsumption * mul;
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
        
        
        
        return speed;
    }
    
    public bool CheckFuelBeforeDrive(double distance, RoadCondition condition)
    {
        
        double consumption = CalculateConsumption(condition);
        double fuelNeeded = distance / 100 * consumption;

        if (CurrentFuelState >= fuelNeeded)
        {
            return true;
        }

        return false;
    }

    public void PrintData()
    {
        Console.WriteLine($"Marke: {Brand}");
        Console.WriteLine($"Modell: {Model}");
        Console.WriteLine($"Derzeitiger Füllstand: {CurrentFuelState}");
        Console.WriteLine($"Maximaler Füllstand: {FuelCapacity}");
        Console.WriteLine($"Durchschnitliche Geschwindigkeit: {AverageSpeed}");
        Console.WriteLine($"Durchschnittlicher Verbrauch: {BaseConsumption}");
        Console.WriteLine($"Energiequelle: {Source}");
    }
    
}