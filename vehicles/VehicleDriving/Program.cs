using VehicleModel;

namespace Program;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Erstelle eine Tankstelle");
        var gasStation = new GasStation(new List<EnergySource>(), 1.8, 1.9, 1.3, new List<MotorizedVehicle>(), 4);
        Console.WriteLine("Füge Energiequellen hinzu: Diesel, Benzin, Ladestation");
        gasStation.AddNewEnergySource(EnergySource.Diesel);
        gasStation.AddNewEnergySource(EnergySource.Gasoline);
        gasStation.AddNewEnergySource(EnergySource.Electricity);
        
        Console.WriteLine("Erstelle ein Fahrrad");
        var bike = new Bicycle("KTM", "Mountainbike", 20);
        
        Console.WriteLine("Fahre 10km in der Stadt");
        double time = bike.Drive(10, RoadCondition.City);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        
        Console.WriteLine("Fahre 10km auf der Autobahn");
        time = bike.Drive(10, RoadCondition.Highway);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Fahrrad ist insgesamt {bike.TravelledDistance}km gefahren");

        Console.WriteLine();
        
        Console.WriteLine("Erstelle ein Auto");
        var car = new TransportVehicle("BMW", "X5", 10, 120, EnergySource.Gasoline, 120, 8);
        Console.WriteLine("Daten des Fahrzeuges:");
        car.PrintData();

        Console.WriteLine();
        
        Console.WriteLine("Fahre 100km auf der Autobahn");
        time = car.Drive(100, RoadCondition.Highway);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Auto ist bis jetzt {car.TravelledDistance}km gefahren");
        
        Console.WriteLine("Fahre 50km in der Stadt");
        time = car.Drive(50, RoadCondition.City);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Auto ist insgesamt {car.TravelledDistance}km gefahren");
        
        Console.WriteLine("Das Auto wird betankt");
        gasStation.Refuel(car);
        Console.WriteLine($"Derzeitiger Füllstand: {car.CurrentFuelState}");
        
        
        Console.WriteLine("Fahre 20km auf der Landstraße");
        time = car.Drive(20, RoadCondition.Backroad);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Auto ist insgesamt {car.TravelledDistance}km gefahren");
        
        Console.WriteLine("Fahre 10km auf der Autobahn");
        time = car.Drive(10, RoadCondition.Highway);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Auto ist insgesamt {car.TravelledDistance}km gefahren");
        
        Console.WriteLine("Fahre 20km auf der Geländestrecke");
        time = car.Drive(20, RoadCondition.Offroad);
        Console.WriteLine($"Die Fahrt dauert {Math.Round(time, 2)} Stunden");
        Console.WriteLine($"Das Auto ist insgesamt {car.TravelledDistance}km gefahren");
        
    }
}

