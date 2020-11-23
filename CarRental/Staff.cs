using System;
using System.Collections.Generic;

namespace CarRental
{
    class Staff
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFree { get; set; }

        public Staff(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            IsFree = true;
        }
    }
}
