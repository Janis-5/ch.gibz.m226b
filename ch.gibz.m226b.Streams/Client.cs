using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Objekte_in_File_speichern_V1_WOd
{
    [Serializable]
    public class Client
    {
        private int clientNumber;
        private string firstName;
        private string surName;
        private double factor;
        [NonSerialized]
        int regionNumber;
        public Client(int pClientNumber, string pFirstName, string pSurName,
        double pFactor, int pRegionNumber)
        {
            clientNumber = pClientNumber;
            firstName = pFirstName;
            surName = pSurName;
            factor = pFactor;
            regionNumber = pRegionNumber;
        }
        public void printClient()
        {
            Console.WriteLine("Client number: " + clientNumber);
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Surname: " + surName);
            Console.WriteLine("Factor: " + factor);
            Console.WriteLine("Region number: " + regionNumber);
        }
    }
}