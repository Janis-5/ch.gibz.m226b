using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Stats
    {
        public float Money { get; set; }
        public int VehicleAmount { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine($"Umsatz: {Money}");
            Console.WriteLine($"Verkaufte Fahrzeuge: {VehicleAmount}");
        }
    }
}
