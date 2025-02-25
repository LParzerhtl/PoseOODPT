using VehicleModel;
namespace VehicleModelsTests;
using Xunit;



public class GasstationTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange
        var availableSources = new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel };
        double gasolinePrice = 1.5;
        double dieselPrice = 1.3;
        double electricityPrice = 0.4;

        // Act
        var gasstation = new Gasstation(availableSources, gasolinePrice, dieselPrice, electricityPrice, new List<MotorizedVehicle>(), 5);

        // Assert
        Assert.Equal(availableSources, gasstation.AvailableEnergySources);
        Assert.Equal(1.5, gasstation.GasolinePrice);
        Assert.Equal(1.3, gasstation.DieselPrice);
        Assert.Equal(0.4, gasstation.ElectricityPrice);
    }

    [Fact]
    public void Refuel_ShouldIncreaseFuelAndReturnCost()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Gasoline }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);
        var vehicle = new PassengerVehicles("BMW", "X5", 20.0, 100.0, EnergySource.Gasoline, 120.0, 8.0);

        double expectedCost = (100.0 - 20.0) * 1.5; // 80L * 1.5€

        // Act
        double actualCost = gasstation.Refuel(vehicle);

        // Assert
        Assert.Equal(100.0, vehicle.CurrentFuelState);
        Assert.Equal(expectedCost, actualCost);
    }

    [Fact]
    public void Refuel_ShouldNotRefuelIfEnergySourceNotAvailable()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Diesel }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);
        var vehicle = new PassengerVehicles("BMW", "X5", 20.0, 100.0, EnergySource.Gasoline, 120.0, 8.0);

        // Act
        double cost = gasstation.Refuel(vehicle);

        // Assert
        Assert.Equal(20.0, vehicle.CurrentFuelState); // Kein Betanken
        Assert.Equal(0.0, cost); // Keine Kosten
    }

    [Fact]
    public void AddNewEnergySource_ShouldAddSourceIfNotExists()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Gasoline }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);

        // Act
        bool added = gasstation.AddNewEnergySource(EnergySource.Diesel);

        // Assert
        Assert.True(added);
        Assert.Contains(EnergySource.Diesel, gasstation.AvailableEnergySources);
    }

    [Fact]
    public void AddNewEnergySource_ShouldNotAddDuplicateSource()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Gasoline }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);

        // Act
        bool added = gasstation.AddNewEnergySource(EnergySource.Gasoline);

        // Assert
        Assert.False(added);
    }

    [Fact]
    public void RemoveEnergySource_ShouldRemoveSourceIfExists()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);

        // Act
        bool removed = gasstation.RemoveEnergySource(EnergySource.Diesel);

        // Assert
        Assert.True(removed);
        Assert.DoesNotContain(EnergySource.Diesel, gasstation.AvailableEnergySources);
    }

    [Fact]
    public void RemoveEnergySource_ShouldNotRemoveIfSourceNotExists()
    {
        // Arrange
        var gasstation = new Gasstation(new List<EnergySource> { EnergySource.Gasoline }, 1.5, 1.3, 0.4, new List<MotorizedVehicle>(), 5);

        // Act
        bool removed = gasstation.RemoveEnergySource(EnergySource.Diesel);

        // Assert
        Assert.False(removed);
    }
}
