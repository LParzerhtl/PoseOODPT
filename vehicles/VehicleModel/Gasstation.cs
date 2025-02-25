namespace VehicleModel;

public class Gasstation
{
    public List<EnergySource> AvailableEnergySources { get; set; }
    public double GasolinePrice { get; set; }
    public double DieselPrice { get; set; }
    public double ElectricityPrice { get; set; }

    public Gasstation(List<EnergySource> availableEnergySources, double gasolinePrice, double dieselPrice,
        double electricityPrice)
    {
        AvailableEnergySources = availableEnergySources;
        GasolinePrice = gasolinePrice;
        DieselPrice = dieselPrice;
        ElectricityPrice = electricityPrice;
    }

    public double Refuel(MotorizedVehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public bool AddNewEnergySource(EnergySource source)
    {
        throw new NotImplementedException();
    }

    public bool RemoveEnergySource(EnergySource source)
    {
        throw new NotImplementedException();
    }
}