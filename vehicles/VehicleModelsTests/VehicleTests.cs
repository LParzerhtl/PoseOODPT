using VehicleModel;

namespace VehicleModelsTests;
using Xunit;
public class VehicleTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        string brand = "Tesla";
        string model = "Model S";
        
        var vehicle = new Bicycle(brand, model, 6.5);
        
        Assert.Equal(brand, vehicle.Brand);
        Assert.Equal(model, vehicle.Model);
        Assert.Equal(0, vehicle.TravelledDistance);
        Assert.Equal(6.5, vehicle.AverageSpeed);
    }
}