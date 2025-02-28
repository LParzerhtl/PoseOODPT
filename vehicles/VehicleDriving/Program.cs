using VehicleModel;
using System;

namespace VehicleDriving
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Multi-Modal Transport Simulation ===");
            Console.ResetColor();

          
            Bicycle bicycle = new Bicycle("CityBike", "Mountain Bike", 20); 

            
            PassengerVehicles electricCar = new PassengerVehicles("Tesla", "Model 3", 50, 100, EnergySource.Electricity, 120, 15); // 120 km/h average speed, 15 kWh/100km

            
            TransportVehicle offroadVehicle = new TransportVehicle("Jeep", "Wrangler", 60, 80, EnergySource.Gasoline, 80, 10); // 80 km/h average speed, 10 l/100km

            
            TransportVehicle transportTruck = new TransportVehicle("Volvo", "FH16", 200, 300, EnergySource.Diesel, 90, 25); // 90 km/h average speed, 25 l/100km

           
            GasStation gasStation = new GasStation(
                new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel, EnergySource.Electricity },
                1.5, 
                1.3, 
                0.3, 
                new List<MotorizedVehicle>(),
                10 
            );

           
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Leg 1: Bicycle Ride ===");
            Console.ResetColor();
            Console.WriteLine("Bicycle Info:");
            Console.WriteLine($"- Brand: {bicycle.Brand}, Model: {bicycle.Model}");
            Console.WriteLine($"- Average Speed: {bicycle.AverageSpeed} km/h");
            Console.WriteLine($"- Total Distance Travelled: {bicycle.TravelledDistance} km");
            double bicycleTime = bicycle.Drive(3, RoadCondition.City);
            Console.WriteLine($"Bicycle: Travelled 3 km in {bicycleTime:F2} hours.");
            Console.WriteLine($"Total distance travelled: {bicycle.TravelledDistance:F2} km.");
            Console.WriteLine();

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Leg 2: Electric Car Rental ===");
            Console.ResetColor();
            Console.WriteLine("Electric Car Info:");
            Console.WriteLine($"- Brand: {electricCar.Brand}, Model: {electricCar.Model}");
            Console.WriteLine($"- Average Speed: {electricCar.AverageSpeed} km/h");
            Console.WriteLine($"- Fuel Capacity: {electricCar.FuelCapacity} kWh {electricCar.Source}");
            Console.WriteLine($"- Current Fuel Level: {electricCar.CurrentFuelState} kWh {electricCar.Source}");
            Console.WriteLine($"- Base Consumption: {electricCar.BaseConsumption} kWh/100km");
            Console.WriteLine($"- Total Distance Travelled: {electricCar.TravelledDistance} km");

            double initialFuelElectricCar = electricCar.CurrentFuelState;
            double electricCarTime1 = electricCar.Drive(10, RoadCondition.City);
            double electricCarFuel1 = initialFuelElectricCar - electricCar.CurrentFuelState;
            Console.WriteLine($"Electric Car: Travelled 10 km in the city in {electricCarTime1:F2} hours and consumed {electricCarFuel1:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Current fuel state: {electricCar.CurrentFuelState:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Total distance travelled: {electricCar.TravelledDistance:F2} km.");

            initialFuelElectricCar = electricCar.CurrentFuelState;
            double electricCarTime2 = electricCar.Drive(250, RoadCondition.Highway);
            double electricCarFuel2 = initialFuelElectricCar - electricCar.CurrentFuelState;
            Console.WriteLine($"Electric Car: Travelled 250 km on the highway in {electricCarTime2:F2} hours and consumed {electricCarFuel2:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Current fuel state: {electricCar.CurrentFuelState:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Total distance travelled: {electricCar.TravelledDistance:F2} km.");

            initialFuelElectricCar = electricCar.CurrentFuelState;
            double electricCarTime3 = electricCar.Drive(5, RoadCondition.Backroad);
            double electricCarFuel3 = initialFuelElectricCar - electricCar.CurrentFuelState;
            Console.WriteLine($"Electric Car: Travelled 5 km on backroads in {electricCarTime3:F2} hours and consumed {electricCarFuel3:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Current fuel state: {electricCar.CurrentFuelState:F2} kWh {electricCar.Source}.");
            Console.WriteLine($"Total distance travelled: {electricCar.TravelledDistance:F2} km.");
            Console.WriteLine();

           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Refueling Electric Car ===");
            Console.ResetColor();
            double refuelCost = gasStation.Refuel(electricCar);
            Console.WriteLine($"Refueled electric car. Cost: {refuelCost:F2} euros.");
            Console.WriteLine($"Current fuel state: {electricCar.CurrentFuelState:F2} kWh {electricCar.Source}.");
            Console.WriteLine();

           
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Leg 3: Offroad 4x4 Tour ===");
            Console.ResetColor();
            Console.WriteLine("Offroad 4x4 Info:");
            Console.WriteLine($"- Brand: {offroadVehicle.Brand}, Model: {offroadVehicle.Model}");
            Console.WriteLine($"- Average Speed: {offroadVehicle.AverageSpeed} km/h");
            Console.WriteLine($"- Fuel Capacity: {offroadVehicle.FuelCapacity} liters {offroadVehicle.Source}");
            Console.WriteLine($"- Current Fuel Level: {offroadVehicle.CurrentFuelState} liters {offroadVehicle.Source}");
            Console.WriteLine($"- Base Consumption: {offroadVehicle.BaseConsumption} liters/100km");
            Console.WriteLine($"- Total Distance Travelled: {offroadVehicle.TravelledDistance} km");

            double initialFuelOffroad = offroadVehicle.CurrentFuelState;
            double offroadTime1 = offroadVehicle.Drive(5, RoadCondition.Backroad);
            double offroadFuel1 = initialFuelOffroad - offroadVehicle.CurrentFuelState;
            Console.WriteLine($"Offroad 4x4: Travelled 5 km on backroads in {offroadTime1:F2} hours and consumed {offroadFuel1:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Current fuel state: {offroadVehicle.CurrentFuelState:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Total distance travelled: {offroadVehicle.TravelledDistance:F2} km.");

            initialFuelOffroad = offroadVehicle.CurrentFuelState;
            double offroadTime2 = offroadVehicle.Drive(35, RoadCondition.Offroad);
            double offroadFuel2 = initialFuelOffroad - offroadVehicle.CurrentFuelState;
            Console.WriteLine($"Offroad 4x4: Travelled 35 km offroad in {offroadTime2:F2} hours and consumed {offroadFuel2:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Current fuel state: {offroadVehicle.CurrentFuelState:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Total distance travelled: {offroadVehicle.TravelledDistance:F2} km.");

            initialFuelOffroad = offroadVehicle.CurrentFuelState;
            double offroadTime3 = offroadVehicle.Drive(10, RoadCondition.Backroad);
            double offroadFuel3 = initialFuelOffroad - offroadVehicle.CurrentFuelState;
            Console.WriteLine($"Offroad 4x4: Travelled 10 km on backroads in {offroadTime3:F2} hours and consumed {offroadFuel3:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Current fuel state: {offroadVehicle.CurrentFuelState:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Total distance travelled: {offroadVehicle.TravelledDistance:F2} km.");

            
            initialFuelOffroad = offroadVehicle.CurrentFuelState;
            double offroadTime4 = offroadVehicle.Drive(20, RoadCondition.Highway);
            double offroadFuel4 = initialFuelOffroad - offroadVehicle.CurrentFuelState;
            Console.WriteLine($"Offroad 4x4: Travelled 20 km on the highway in {offroadTime4:F2} hours and consumed {offroadFuel4:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Current fuel state: {offroadVehicle.CurrentFuelState:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine($"Total distance travelled: {offroadVehicle.TravelledDistance:F2} km.");
            Console.WriteLine();

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Refueling Offroad 4x4 ===");
            Console.ResetColor();
            refuelCost = gasStation.Refuel(offroadVehicle);
            Console.WriteLine($"Refueled offroad 4x4. Cost: {refuelCost:F2} euros.");
            Console.WriteLine($"Current fuel state: {offroadVehicle.CurrentFuelState:F2} liters {offroadVehicle.Source}.");
            Console.WriteLine();

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Leg 4: Transport Truck ===");
            Console.ResetColor();
            Console.WriteLine("Transport Truck Info:");
            Console.WriteLine($"- Brand: {transportTruck.Brand}, Model: {transportTruck.Model}");
            Console.WriteLine($"- Average Speed: {transportTruck.AverageSpeed} km/h");
            Console.WriteLine($"- Fuel Capacity: {transportTruck.FuelCapacity} liters {transportTruck.Source}");
            Console.WriteLine($"- Current Fuel Level: {transportTruck.CurrentFuelState} liters {transportTruck.Source}");
            Console.WriteLine($"- Base Consumption: {transportTruck.BaseConsumption} liters/100km");
            Console.WriteLine($"- Total Distance Travelled: {transportTruck.TravelledDistance} km");

            double initialFuelTruck = transportTruck.CurrentFuelState;
            double truckTime = transportTruck.Drive(40, RoadCondition.Highway);
            double truckFuel = initialFuelTruck - transportTruck.CurrentFuelState;
            Console.WriteLine($"Transport Truck: Travelled 40 km on the highway in {truckTime:F2} hours and consumed {truckFuel:F2} liters {transportTruck.Source}.");
            Console.WriteLine($"Current fuel state: {transportTruck.CurrentFuelState:F2} liters {transportTruck.Source}.");
            Console.WriteLine($"Total distance travelled: {transportTruck.TravelledDistance:F2} km.");
            Console.WriteLine();

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Journey Summary ===");
            Console.ResetColor();
            Console.WriteLine($"Total time: {bicycleTime + electricCarTime1 + electricCarTime2 + electricCarTime3 + offroadTime1 + offroadTime2 + offroadTime3 + offroadTime4 + truckTime:F2} hours.");
            Console.WriteLine($"Total fuel cost: {electricCar.FuelCost + offroadVehicle.FuelCost + transportTruck.FuelCost:F2} euros.");
            Console.ReadKey();
        }
    }
}