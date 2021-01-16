using ch.gibz.m226b.CarRental.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    public class Vehicle : IGetInfos
    {
        public VehicleTypes VehicleType { get; set; }   
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public bool IsFree { get; set; }

        public Vehicle(VehicleTypes VehicleType, string Brand, string Model, float Price)
        {
            this.VehicleType = VehicleType;
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
            IsFree = true;
        }

        public Vehicle(string Brand, string Model, float Price)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Price = Price;
        }

        public Vehicle()
        {}

        public virtual string GetInfos()
        {
            return $"{Brand} {Model} | CHF {Price}.-";
        }
    }
}
