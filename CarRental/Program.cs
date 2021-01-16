using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {

            bool run = true;


            Console.WriteLine("--Autovermietung---");

            while (run)
            {
                Console.WriteLine("[0] Fahrzeug mieten");
                Console.WriteLine("[1] Fahrzeug zurückgeben");
                Console.WriteLine("[2] Statistiken");
                Console.WriteLine("[3] Beenden");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        RentCar();
                        break;
                    case "1":
                        //ReturnCar();
                        break;
                    case "2":
                        //Stats();
                        break;
                    case "3":
                        run = false;
                        break;
                    default:
                        break;
                }
            }      

            void RentCar()
            {

                string readstring;

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json");
                var _staffs = JsonConvert.DeserializeObject<List<Staff>>(readstring);

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json");
                var _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readstring, new VehicleConverter());

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json");
                var _contracts = JsonConvert.DeserializeObject<List<Contract>>(readstring);

                Contract tmpContract = new Contract();

                Console.WriteLine("Guten Tag");

                //Wähle den Mitarbeiter
                Console.WriteLine("Alle verfügbaren Mitarbeiter: ");
                foreach (var item in _staffs)
                {
                    if (item.IsFree)
                    {
                        Console.WriteLine($"[{_staffs.IndexOf(item)}] {item.GetInfos()}");
                    }
                }

                do
                {
                    tmpContract.Staff = ChooseStaff(_staffs);
                } while (tmpContract.Staff == null);

                //Wähle den Fahrzeugtypen
                Console.WriteLine("Alle Fahrzeug Typen:");
                for (int i = 0; i < Enum.GetNames(typeof(VehicleTypes)).Length - 1; i++)
                {
                    Console.WriteLine($"[{i}] {(VehicleTypes)i}");
                }

                do
                {
                    tmpContract.VehicleType = ChooseVehicleType();
                } while (tmpContract.VehicleType == VehicleTypes.None);

                //Wähle das Fahrzeug
                Console.WriteLine("Alle verfügbaren Fahrzeuge:");
                foreach (var item in _vehicles)
                {
                    if (item.IsFree && item.VehicleType == tmpContract.VehicleType)
                    {
                        Console.WriteLine($"[{_vehicles.IndexOf(item)}] {item.GetInfos()}");
                    }
                }

                do
                {
                    tmpContract.Vehicle = ChooseVehicle(_vehicles);
                } while (tmpContract.Vehicle == null);


                do
                {
                    tmpContract.RentalDays = SetRentalDays();
                } while (tmpContract.RentalDays == 0);

                tmpContract.DisplayContract();

                tmpContract.SetSum();

                Console.WriteLine($"Zu Bezahlen: {tmpContract.Sum}");

                for (int i = 0; i < Enum.GetNames(typeof(PayMethod)).Length - 1; i++)
                {
                    Console.WriteLine($"[{i}] {(PayMethod)i}");
                }

                do
                {
                    tmpContract.PayMethod = ChoosePayMethod();
                } while (tmpContract.PayMethod == PayMethod.None);


                if (tmpContract.PayMethod == PayMethod.Bar)
                {
                    while (Pay(Convert.ToDecimal(tmpContract.Sum)));
                }
                else
                {
                    Console.WriteLine("Kreditkarte bla bla");
                }

                


            }




            /*
            string jsonString = JsonConvert.SerializeObject(_staffs);
            File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json", jsonString);

            string jsonString = JsonConvert.SerializeObject(_vehicles);
            File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json", jsonString);
            */


            Staff ChooseStaff(List<Staff> _staffs)
            {
                try
                {
                    Console.Write("Wählen Sie einen Mitarbeiter anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    _staffs[Convert.ToInt32(input)].IsFree = false;
                    return _staffs[Convert.ToInt32(input)];
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return null;
                }
            }

            VehicleTypes ChooseVehicleType()
            {
                try
                {
                    Console.Write("Wählen Sie den Fahrzeugstyp anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    return (VehicleTypes)Convert.ToInt32(input);
                }
                catch {
                    Console.WriteLine("Fehler!!!");
                    return VehicleTypes.None; 
                }
            }

            Vehicle ChooseVehicle(List<Vehicle> _vehicles)
            {
                try
                {
                    Console.Write("Wählen Sie das Fahrzeug anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    _vehicles[Convert.ToInt32(input)].IsFree = false;
                    return _vehicles[Convert.ToInt32(input)];
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return null;
                }
            }

            int SetRentalDays()
            {
                try
                {
                    Console.WriteLine("Für wie viele Tage möchten Sie das Fahrzeug mieten?");
                    string input = Console.ReadLine();
                    return Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return 0;
                }
            }

            PayMethod ChoosePayMethod()
            {
                try
                {
                    Console.Write("Wählen Sie die Zahlungsart anhand von der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    return (PayMethod)Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return PayMethod.None;
                }
            }

            bool Pay(decimal betrag)
            {
                decimal uinput;
                try
                {
                    Console.Write("Geben Sie den Betrag ein:");
                    string input = Console.ReadLine();
                    uinput = Convert.ToDecimal(input);
                }
                catch
                {
                    Console.WriteLine("Fehler!!!");
                    return true;
                }

                if (uinput >= betrag)
                {
                    Console.WriteLine($"Rückgeld: {uinput - betrag}");
                    return false;
                }
                else
                {
                    Console.WriteLine("Fehler");
                    return true;
                }
            }
        }
    }
}