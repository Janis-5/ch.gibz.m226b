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
                        ReturnCar();
                        break;
                    case "2":
                        Stats();
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
                string jsonString;

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\staff.json");
                var _staffs = JsonConvert.DeserializeObject<List<Staff>>(readstring);

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json");
                var _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(readstring, new VehicleConverter());

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json");
                var _contracts = JsonConvert.DeserializeObject<List<Contract>>(readstring);

                Contract tmpContract = new Contract();

                Console.WriteLine("Guten Tag");

                //Eingabe Persöhnliche Daten (Name Vorname)
                Console.WriteLine("Geben Sie ihren Vollständigen Namen ein: ");
                tmpContract.CustomerName = Console.ReadLine();

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
                    tmpContract.StartDate = SetStartDate();
                } while (tmpContract.StartDate == new DateTime(2000, 1, 1));


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

                Console.WriteLine("Gute Fahrt!");

                _contracts.Add(tmpContract);

                jsonString = JsonConvert.SerializeObject(_vehicles);
                File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\vehicle.json", jsonString);

                jsonString = JsonConvert.SerializeObject(_contracts);
                File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json", jsonString);
            }

            void ReturnCar()
            {
                string readstring;
                string jsonString;

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json");
                var _contracts = JsonConvert.DeserializeObject<List<Contract>>(readstring);

                int index;

                Console.WriteLine("Return Car");

                Console.WriteLine("Geben Sie ihren Vollständigen Namen ein: ");
                string input = Console.ReadLine();

                foreach (var item in _contracts)
                {
                    if (item.CustomerName == input && item.GotReturned ==  false)
                    {
                        Console.WriteLine($"[{_contracts.IndexOf(item)}]");
                        item.DisplayContract();
                    }
                }
                do
                {
                    index = ChooseContract(_contracts);
                } while (index == -1);


                Console.WriteLine("Ihr Fehrzeug welches Sie zurückgeben:");
                _contracts[index].DisplayContract();

                //Irgendwelche Funktionen Welche das Fahrzeug säubert und den Wieder zu Verfügung stellt:
                //VehicleCLean();
                //SetVehicleAvailable();

                jsonString = JsonConvert.SerializeObject(_contracts);
                File.WriteAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json", jsonString);


            }

            void Stats()
            {
                string readstring;

                readstring = File.ReadAllText(@"C:\Users\janis\Schule Disk\Daten\M226B\ch.gibz.m226b\CarRental\data\contract.json");
                var _contracts = JsonConvert.DeserializeObject<List<Contract>>(readstring);

                Stats year = new Stats();
                Stats month = new Stats();
                Stats week = new Stats();
                Stats day = new Stats();

                foreach (var item in _contracts)
                {
                    DateTime.Today.AddYears(1);
                    if (item.StartDate < DateTime.Now.AddYears(1).Date)
                    {
                        year.VehicleAmount += 1;
                        year.Money += item.Sum;
                    }
                    if (item.StartDate < DateTime.Now.AddMonths(1).Date)
                    {
                        month.VehicleAmount += 1;
                        month.Money += item.Sum;
                    }
                    if (item.StartDate < DateTime.Now.AddDays(7).Date)
                    {
                        week.VehicleAmount += 1;
                        week.Money += item.Sum;
                    }
                    if (item.StartDate < DateTime.Today.Date)
                    {
                        day.VehicleAmount += 1;
                        day.Money += item.Sum;
                    }
                }

                Console.WriteLine("Stats:");
                Console.WriteLine("Year:");
                year.DisplayStats();
                Console.WriteLine("Month:");
                month.DisplayStats();
                Console.WriteLine("Week:");
                week.DisplayStats();
                Console.WriteLine("Today:");
                day.DisplayStats();
            }

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
                    Console.WriteLine("Ungültige Eingabe");
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
                    Console.WriteLine("Ungültige Eingabe");
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
                    Console.WriteLine("Ungültige Eingabe");
                    return null;
                }
            }

            DateTime SetStartDate()
            {
                try
                {
                    Console.WriteLine("Gen Sie das Startdatum ein (z.B. 10/22/2021)");
                    DateTime input = DateTime.Parse(Console.ReadLine());
                    return input;
                }
                catch
                {
                    Console.WriteLine("Ungültige Eingabe");
                    return new DateTime(2000, 1,1);
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
                    Console.WriteLine("Ungültige Eingabe");
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
                    Console.WriteLine("Ungültige Eingabe");
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
                    Console.WriteLine("Ungültige Eingabe");
                    return true;
                }

                if (uinput >= betrag)
                {
                    Console.WriteLine($"Rückgeld: {uinput - betrag}");
                    return false;
                }
                else
                {
                    Console.WriteLine("Nicht genug Geld");
                    return true;
                }
            }

            int ChooseContract(List<Contract> _contracts)
            {
                try
                {
                    Console.Write("Wählen Sie Ihren Vertrag anhand der Zuvorstehender Nummer: ");
                    string input = Console.ReadLine();
                    _contracts[Convert.ToInt32(input)].GotReturned = true;
                    return Convert.ToInt32(input);
                }
                catch
                {
                    Console.WriteLine("Ungültige Eingabe");
                    return -1;
                }
            }
        }
    }
}