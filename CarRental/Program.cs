using System;
using System.Collections.Generic;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> _staffs = new List<Staff>()
            {
                new Staff("Luca", "Daniel"),
                new Staff("Laurin", "Bassler")
            };

            Console.WriteLine("Guten Tag");
            Console.WriteLine("Alle verfügbaren Mitarbeiter: ");
            foreach (var item in _staffs)
            {
                if (item.IsFree)
                {
                    Console.WriteLine($"[{_staffs.IndexOf(item)}] {item.FirstName} {item.LastName}");
                }
            }
            while (ChooseStaff(_staffs));

            Console.WriteLine("Alle Fahrzeug Typen");
            for (int i = 0; i < Enum.GetNames(typeof(VehicleTypes)).Length; i++)
            {
                Console.WriteLine($"[{i}] {(VehicleTypes)i}");
            }
            while (ChooseVehicleType());

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
        }
    }
}