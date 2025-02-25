
using VehicleModel;

namespace VehicleModelsTests;

public class PassengerVehiclesTest
{

    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var vehicle = new PassengerVehicles("BMW", "X5", 60.0, 100.0, EnergySource.Gasoline, 120.0, 8.0);

        // Assert
        Assert.Equal("BMW", vehicle.Brand);
        Assert.Equal("X5", vehicle.Model);
        Assert.Equal(60.0, vehicle.CurrentFuelState);
        Assert.Equal(100.0, vehicle.FuelCapacity);
        Assert.Equal(EnergySource.Gasoline, vehicle.Source);
        Assert.Equal(120.0, vehicle.AverageSpeed);
        Assert.Equal(8.0, vehicle.BaseConsumption);
    }

    [Fact]
    public void Drive_ShouldReduceFuelAndReturnTravelTime()
    {
        // Arrange
        var vehicle = new PassengerVehicles("BMW", "X5", 50.0, 100.0, EnergySource.Gasoline, 120.0, 8.0);
        double distance = 200.0;
        RoadCondition condition = RoadCondition.Highway; // Verbrauch * 0.8, Geschwindigkeit * 1.2

        double expectedFuelConsumption = (8.0 * 0.8) * (distance / 100); // Verbrauch basierend auf Highway
        double expectedTravelTime = (distance / (120.0 * 1.2)); // Geschwindigkeit basierend auf Highway

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
        var vehicle = new PassengerVehicles("BMW", "X5", 5.0, 100.0, EnergySource.Gasoline, 120.0, 8.0);
        double distance = 200.0;
        RoadCondition condition = RoadCondition.Offroad; // Verbrauch * 1.5

        // Act
        double travelTime = vehicle.Drive(distance, condition);

        // Assert
        Assert.Equal(5.0, vehicle.CurrentFuelState); // Kein Kraftstoffverbrauch
        Assert.Equal(0.0, travelTime); // Keine Bewegung möglich
    }
}