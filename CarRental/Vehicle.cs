using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Vehicle
    {
        public VehicleTypes VehicleType { get; }   
        private string Brand { get; }
        private string Model { get; }
        private float Price { get; }
        public bool IsFree { get; set; }

        public Vehicle(VehicleTypes VehicleType, string Brand, string Model, float Price)
        {
            this.VehicleType = VehicleType;
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
            IsFree = true;
        }

        public string GetInfo()
        {
            string info = $"{Brand} {Model} | CHF {Price}.-";
            return info;
        }
    }
}
