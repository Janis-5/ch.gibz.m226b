using ch.gibz.m226b.CarRental.Interface;
using System;
using System.Collections.Generic;

namespace CarRental
{
    class Staff : IGetInfos
    {
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsFree { get; set; }

        public Staff(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            IsFree = true;
        }

        public string GetInfos()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
