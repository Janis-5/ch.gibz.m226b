using System;
using System.Collections.Generic;

namespace CarRental
{
    class Staff
    {
        private string FirstName { get; }
        private string LastName { get; }
        public bool IsFree { get; set; }

        public Staff(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            IsFree = true;
        }

        public string GetInfo()
        {
            string info = $"{FirstName} {LastName}";
            return info;
        }
    }
}
