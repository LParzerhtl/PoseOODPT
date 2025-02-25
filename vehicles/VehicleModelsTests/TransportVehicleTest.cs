
using VehicleModel;
namespace VehicleModelsTests;
using Xunit;

public class TransportVehicleTest
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        string brand = "Mercedes";
        string model = "Sprinter";
        double currentFuelState = 50.0;
        double fuelCapacity = 100.0;
        EnergySource source = EnergySource.Diesel;
        double averageSpeed = 80.0;
        double baseConsumption = 10.0;
        
        var transportVehicle = new TransportVehicle(brand, model, currentFuelState, fuelCapacity, source, averageSpeed, baseConsumption);
        
        Assert.Equal(brand, transportVehicle.Brand);
        Assert.Equal(model, transportVehicle.Model);
        Assert.Equal(currentFuelState, transportVehicle.CurrentFuelState);
        Assert.Equal(fuelCapacity, transportVehicle.FuelCapacity);
        Assert.Equal(source, transportVehicle.Source);
        Assert.Equal(averageSpeed, transportVehicle.AverageSpeed);
        Assert.Equal(baseConsumption, transportVehicle.BaseConsumption);
    }
    
    [Fact]
    public void Drive_ShouldReduceFuelAndReturnTravelTime()
    {
        // Arrange
        var vehicle = new TransportVehicle("Mercedes", "Sprinter", 50.0, 100.0, EnergySource.Diesel, 80.0, 10.0);
        double distance = 100.0;
        RoadCondition condition = RoadCondition.City; // Verbrauch * 1.2, Geschwindigkeit * 0.6

        double expectedFuelConsumption = (10.0 * 1.2) * (distance / 100); // Basisverbrauch angepasst an City
        double expectedTravelTime = (distance / (80.0 * 0.6)); // Geschwindigkeit angepasst an City

        // Act
        double actualTravelTime = vehicle.Drive(distance, condition);

        // Assert
        Assert.Equal(50.0 - expectedFuelConsumption, vehicle.CurrentFuelState, 2); // Toleranz von 2 Dezimalstellen
        Assert.Equal(expectedTravelTime, actualTravelTime, 2);
    }

    [Fact]
    public void Drive_ShouldNotDriveIfNotEnoughFuel()
    {
        // Arrange
        var vehicle = new TransportVehicle("Mercedes", "Sprinter", 5.0, 100.0, EnergySource.Diesel, 80.0, 10.0);
        double distance = 100.0;
        RoadCondition condition = RoadCondition.Highway; // Verbrauch * 0.8

        // Act
        double travelTime = vehicle.Drive(distance, condition);

        // Assert
        Assert.Equal(5.0, vehicle.CurrentFuelState); // Kein Kraftstoffverbrauch
        Assert.Equal(0.0, travelTime); 
    }
}