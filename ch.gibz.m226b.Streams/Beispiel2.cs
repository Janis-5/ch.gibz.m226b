using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using Objekte_in_File_speichern_V1_WOd;

namespace Objekte_in_File_speichern_V3_WOd
{
    class Program
    {
        static string fileName = "clientfile.bin";
        static void Main(string[] args)
        {
            ObservableCollection<Client> oclist1 = new ObservableCollection<Client>();
            oclist1.Add(new Client(1, "Joe", "Hanson", 1.234, 6300));
            oclist1.Add(new Client(2, "Tina", "Turner", 4.5, 8300));
            Console.WriteLine("Safed Client;\n");
            foreach (Client count in oclist1)
            {
                count.printClient();
                Console.WriteLine();
            }
            FileStream fs = new FileStream(fileName, FileMode.Create);
            IFormatter bf = new BinaryFormatter();
            // Writes an ObservableCollection of objects to a binary file
            bf.Serialize(fs, oclist1);
            fs.Position = 0;
            Console.WriteLine("\n\nReconstructed Clients:\n");
            // Reads an ObservableCollection of objects from a binary file
            ObservableCollection<Client> recOcList =
            (ObservableCollection<Client>)bf.Deserialize(fs);
            foreach (Client count in recOcList)
            {
                count.printClient();
                Console.WriteLine();
            }
            fs.Close();
        }
    }
}
