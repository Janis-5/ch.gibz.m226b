using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Vehicle
    {
        private VehicleTypes VehicleType { get; }   
        private string Brand { get; }
        private string Model { get; }
        private float Price { get; }

        public Vehicle(VehicleTypes VehicleType, string Brand, string Model, float Price)
        {
            this.VehicleType = VehicleType;
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
        }
    }
    public enum VehicleTypes
    {
        Auto,
        Motorrad,
        Lastwagen,
    }
}
