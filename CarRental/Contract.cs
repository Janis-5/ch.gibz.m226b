namespace CarRental
{
    class Contract
    {
        private string ContractID { get; }
        public Staff Staff { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public Vehicle Vehicle { get; set; }
        private int RentalDays { get; set; }
    }
}
