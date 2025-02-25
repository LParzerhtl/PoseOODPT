namespace VehicleModel;

public class Gasstation
{
    public List<EnergySource> AvailableEnergySources { get; set; }
    public List<MotorizedVehicle> CurrentMotorizedVehicles { get; set; }
    public int MaxCars { get; set; }
    public double GasolinePrice { get; set; }
    public double DieselPrice { get; set; }
    public double ElectricityPrice { get; set; }

    public Gasstation(List<EnergySource> availableEnergySources, double gasolinePrice, double dieselPrice,
        double electricityPrice, List<MotorizedVehicle> currentMotorizedVehicles, int maxCars)
    {
        AvailableEnergySources = availableEnergySources;
        GasolinePrice = gasolinePrice;
        DieselPrice = dieselPrice;
        ElectricityPrice = electricityPrice;
        CurrentMotorizedVehicles = currentMotorizedVehicles;
        MaxCars = maxCars;
    }

    public double Refuel(MotorizedVehicle vehicle)
    {
        double cost = 0;
        if (CurrentMotorizedVehicles.Count < MaxCars && AvailableEnergySources.Contains(vehicle.Source))
        {
            double refuel = vehicle.FuelCapacity - vehicle.CurrentFuelState;
            if (vehicle.Source == EnergySource.Diesel)
            {
                vehicle.FuelCost += DieselPrice * refuel;
                cost = DieselPrice * refuel;
            }
            else if (vehicle.Source == EnergySource.Electricity)
            {
                vehicle.FuelCost += ElectricityPrice * refuel;
                cost = ElectricityPrice * refuel;
            }
            else
            {
                vehicle.FuelCost += GasolinePrice * refuel;
                cost = GasolinePrice * refuel;
            }

            vehicle.CurrentFuelState = vehicle.FuelCapacity;
        }
        return cost;
    }

    public bool AddNewEnergySource(EnergySource source)
    {
        if (!AvailableEnergySources.Contains(source))
        {
            AvailableEnergySources.Add(source);
            return true;
        }
        return false;
    }

    public bool RemoveEnergySource(EnergySource source)
    {
        if (AvailableEnergySources.Contains(source))
        {
            AvailableEnergySources.Remove(source);
            return true;
        }
        return false;
    }
}