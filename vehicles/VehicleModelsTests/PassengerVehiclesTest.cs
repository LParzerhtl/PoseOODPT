
using VehicleModel;

namespace VehicleModelsTests;

public class PassengerVehiclesTest
{

    [Fact]
    public void TestConstructor_IsValid_ReturnsTrue()
    {
        var vehicle = new PassengerVehicles("BMW", "4");
        
        Assert.True(vehicle is PassengerVehicles);
    }
}