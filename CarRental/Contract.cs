namespace CarRental
{
    class Contract
    {
        private string ContractID { get; }
        private Staff Mitarbeiter { get; set; }
        private Vehicle Vehicle { get; set; }
        private int RentalDays { get; set; }
    }
}
