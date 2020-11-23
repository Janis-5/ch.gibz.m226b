using ch.gibz.m226b.Autovermietung1.Interface;
using System;

namespace ch.gibz.m226b.Autovermietung1
{
    public class Staff : IDisplayName
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public void DisplayName()
        {
            Console.WriteLine(Firstname, Lastname);
        }
    }
}

