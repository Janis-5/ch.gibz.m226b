using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ch.gibz.m226b.Autovermietung1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Brand = "Mercedes";
            car1.Model = "GLE";
            car1.ConstructionYear = 2019;
            car1.Mileage = 0;

            Car car2 = new Car();
            car2.Brand = "Mercedes";
            car2.Model = "GLC";
            car2.ConstructionYear = 2016;
            car2.Mileage = 10;

            BusinessCustomer businessCustomer1 = new BusinessCustomer();
            businessCustomer1.CompanyName = "WebTech";
            businessCustomer1.Lastname = "Selisberger";
            businessCustomer1.Firstname = "Arnold";
            businessCustomer1.DateOfBirth = DateTime.Parse("22.04.2003");

            PrivateCustomer privateCustomer1 = new PrivateCustomer();
            privateCustomer1.Firstname = "Laurin";
            privateCustomer1.Lastname = "Lanzelot";
            privateCustomer1.DateOfBirth = DateTime.Parse("01.01.1869");
            privateCustomer1.HomeBase = "Acapulco";

            string fileName = "Cars.txt";

            #region Stream
            //StreamWriter sw = new StreamWriter(fileName);
            //sw.WriteLine($"Brand: {car1.Brand}; Model: {car1.Model}; Construction Year: {car1.ConstructionYear}; Mileage: {car1.Mileage}");

            //sw.WriteLine($"Brand: {car2.Brand}; Model: {car2.Model}; Construction Year: {car2.ConstructionYear}; Mileage: {car2.Mileage}");

            //sw.Close();

            //StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), Encoding.Default);
            //Console.WriteLine("Content of File: \"{0}\":", ((FileStream)sr.BaseStream).Name);


            //for (int count = 0; sr.Peek() >= 0; count++) 
            //{
            //Console.WriteLine("Car {0}:\t{1}", count, sr.ReadLine()); 
            //}
            //sr.Close();

            #endregion
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);

            List<Customer> customers = new List<Customer>();
            customers.Add(privateCustomer1);
            customers.Add(businessCustomer1);


            #region json
            /*
            string jsonString = JsonSerializer.Serialize(customers);

            File.WriteAllText(fileName, jsonString);

            var fileContent = File.ReadAllText(fileName);


            PrivateCustomer privateCustomer2 = JsonSerializer.Deserialize<PrivateCustomer>(fileContent);
            BusinessCustomer businesscustomer2 = JsonSerializer.Deserialize<BusinessCustomer>(fileContent);

            Console.WriteLine($"Firstname: {businesscustomer2.Firstname} Lastname: {businesscustomer2.Lastname} DateOfBirth: {businesscustomer2.DateOfBirth} Company: {businesscustomer2.CompanyName}");
            Console.WriteLine($"Firstname: {privateCustomer2.Firstname} Lastname: {privateCustomer2.Lastname} DateOfBirth: {privateCustomer2.DateOfBirth}");
            */
            #endregion

            #region Newton json
            //string json = JsonConvert.SerializeObject(cars, Formatting.Indented) + JsonConvert.SerializeObject(customers, Formatting.Indented);

            string newtonjson = JsonConvert.SerializeObject(customers, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            Console.WriteLine(newtonjson);

            //var jsondata = JsonConvert.SerializeObject(customers, Formatting.Indented);
            //Console.WriteLine(jsondata);

            #endregion

            //var jsonDataNewtonsoft = Newtonsoft.Json.JsonConvert.SerializeObject(jsondata, Formatting.Indented);
            //Console.WriteLine(jsonDataNewtonsoft);
        }
    }
}

