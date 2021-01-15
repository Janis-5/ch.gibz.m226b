using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Vehicle> _vehicles = new List<Vehicle>()
            {
                new Vehicle(VehicleTypes.Auto, "Audi", "model1", 22),
                new Vehicle(VehicleTypes.Motorrad, "Harley", "model1", 22)
            };

            string jsonString = JsonConvert.SerializeObject(_vehicles);
            File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json", jsonString);*/

             /*List<Staff> _staffs = new List<Staff>()
             {
                 new Staff("Luca", "Daniel"),
                 new Staff("Laurin", "Bassler")
             };

             string jsonString = JsonConvert.SerializeObject(_staffs);
             File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json", jsonString);*/

            string readstring;

            readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json");
            var _staffs = JsonConvert.DeserializeObject<List<Staff>>(readstring);

            readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json");
            var _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readstring);

            Console.WriteLine("Guten Tag");

            //Wähle den Mitarbeiter
            Console.WriteLine("Alle verfügbaren Mitarbeiter: ");
            foreach (var item in _staffs)
            {
                if (item.IsFree)
                {
                    Console.WriteLine($"[{_staffs.IndexOf(item)}] {item.GetInfo()}");
                }
            }
            while (ChooseStaff(_staffs));

            //Wähle den Fahrzeugtypen
            Console.WriteLine("Alle Fahrzeug Typen:");
            for (int i = 0; i < Enum.GetNames(typeof(VehicleTypes)).Length; i++)
            {
                Console.WriteLine($"[{i}] {(VehicleTypes)i}");
            }
            while (ChooseVehicleType());

            //Wähle das Fahrzeug
            Console.WriteLine("Alle verfügbaren Fahrzeuge:");
            foreach (var item in _vehicles)
            {
                if (item.IsFree)
                {
                    Console.WriteLine($"[{_vehicles.IndexOf(item)}] {item.GetInfo()}");
                }
            }
            while (ChooseVehicle(_vehicles));


            /*
            string jsonString = JsonConvert.SerializeObject(_staffs);
            File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json", jsonString);

            string jsonString = JsonConvert.SerializeObject(_vehicles);
            File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json", jsonString);
            */


            bool ChooseStaff(List<Staff> _staffs)
            {
                try
                {
                    Console.Write("Wählen Sie einen Mitarbeiter anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    _staffs[Convert.ToInt32(input)].IsFree = false;
                    return false;
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return true;
                }
            }

            bool ChooseVehicleType()
            {
                try
                {
                    Console.Write("Wählen Sie den Fahrzeugstyp anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    return false;
                }
                catch { return true; }
            }

            bool ChooseVehicle(List<Vehicle> _vehicles)
            {
                try
                {
                    Console.Write("Wählen Sie das Fahrzeug anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    _vehicles[Convert.ToInt32(input)].IsFree = false;
                    return false;
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return true;
                }
            }
        }
    }
}