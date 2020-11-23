using System;
using System.Collections.Generic;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            var _staffs = new List<Staff>()
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
            Console.Write("Wählen Sie einen Mitarbeiter anhand von der Zuvorstehender Nummer: ");
            string input = Console.ReadLine();
            Console.WriteLine(input);
        }
    }
}