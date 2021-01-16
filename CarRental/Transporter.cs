using ch.gibz.m226b.CarRental.Interface;
namespace CarRental
{
    public class Transporter : Vehicle, IGetInfos
    {
        public string Capacity { get; set; }

        public Transporter(string Brand, string Model, float Price, string Capacity) : base(Brand, Model, Price)
        {
            VehicleType = VehicleTypes.Transporter;
            this.Capacity = Capacity;
        }

        public Transporter()
        {
            VehicleType = VehicleTypes.Transporter;
        }

        public override string GetInfos()
        {
            return $"{Brand} {Model} {Capacity} | CHF {Price}.-";
        }







    }
}