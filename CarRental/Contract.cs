using System;

namespace CarRental
{
    class Contract
    {
        private string ContractID { get; }
        public string CustomerName { get; set; }
        public Staff Staff { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public int RentalDays { get; set; }
        public float Sum { get; set; }
        public PayMethod PayMethod { get; set; }
        public bool GotReturned { get; set; }

        public Contract()
        {
            this.RentalDays = 0;
            this.GotReturned = false;
        }

        public void DisplayContract()
        {
            Console.WriteLine("--Ausgewähltes Fahrzeug--");
            Console.WriteLine($"Mitarbeiter: {Staff.GetInfos()}");
            Console.WriteLine($"Fahrzeugart: {VehicleType}");
            Console.WriteLine($"Fahrzeug: {Vehicle.GetInfos()}");
            Console.WriteLine($"Start Datum: {StartDate}");
            Console.WriteLine($"Anzahl miettage: {RentalDays}");
        }

        public void SetSum()
        {
            Sum = Vehicle.Price * RentalDays;
        }

    }
}
