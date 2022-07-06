﻿using ath_p4_proj2.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using static Bogus.DataSets.Name;

namespace ath_p4_proj2.Database
{


    internal static class SeedDb
    {
        private static Random random = new Random();
        private static Faker faker = new Faker("pl");

        private static string GetDeviceSerialNumber()
        {
            int length = 16;
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray()).ToUpper();
        }

        private static string GetDeviceManufaturer()
        {
            string[] deviceBrands = { "Lenovo", "HP", "Dell", "Apple", "Acer", "LG", "Asus", "MSI", "Toshiba", "Huawei" };
            return deviceBrands[random.Next(deviceBrands.Length)];
        }

        private static string GetDeviceModel()
        {
            string model;
            do
            {
                model = faker.Lorem.Word();
            } while (model.Length < 4);
            return char.ToUpper(model[0]) + model.Substring(1);
        }

        public static void Run()
        {
            // Liczba musi być większa niż ~15
            var baseNumberOfEmployees = 34;

            // Tworzenie losowych pracowników
            var employees = new List<Employee>();
            for (int i = 0; i < baseNumberOfEmployees; i++)
            {
                var gender = faker.PickRandom<Gender>();
                var fn = faker.Name.FirstName(gender);
                var ln = faker.Name.LastName(gender);
                var p = faker.Phone.PhoneNumber("#########");
                var e = faker.Internet.ExampleEmail(fn, ln);
                var em = new Employee(fn, ln, p, e);
                employees.Add(em);
            }

            // Tworzenie losowych urzadzeń i wybieranie ~15% które są wyłączone z użytku
            var devices = new List<Device>();
            var numberOfDevices = Math.Ceiling(employees.Count * 0.8);
            for (int i = 0; i < numberOfDevices; i++)
            {
                var ma = GetDeviceManufaturer();
                var mo = GetDeviceModel();
                var sn = GetDeviceSerialNumber();
                var deol = faker.Date.Past(1, new DateTime(2021, 06, 06));
                var dos = faker.Date.Past(1, deol);
                var d = new Device(ma, mo, sn, dos);
                bool isEOL = random.Next(100) <= 15 ? true : false;
                if (isEOL) d.DateOfEOL = deol;
                devices.Add(d);
            }

            var histories = new List<DeviceHistory>();
            for (int i = 0; i < numberOfDevices - 2; i++)
            {
                var d = devices[i];
                if (d.DateOfEOL is not null) continue;
                var e = employees[i];
                var h = new DeviceHistory();
                h.Device = d;
                h.Employee = e;
                h.DateOfAssignment = faker.Date.Future(1, d.DateOfService);
                histories.Add(h);
            }

            var returnedDevices = faker.Random.ListItems(histories, 3);
            foreach (var device in returnedDevices)
            {
                device.DateOfReturn = faker.Date.Future(1, device.DateOfAssignment);
            }

            // Add devices for first employee for demo purposes
            var demoDevices = new List<Device>();
            for (int i = 0; i < 2; i++)
            {
                var ma = GetDeviceManufaturer();
                var mo = GetDeviceModel();
                var sn = GetDeviceSerialNumber();
                var dos = faker.Date.Past(1, new DateTime(2021, 1, 1));
                var d = new Device(ma, mo, sn, dos);
                demoDevices.Add(d);
            }
            var demoHistories = new List<DeviceHistory>();
            for (int i = 0; i < 2; i++)
            {
                var d = demoDevices[i];
                var e = employees[0];
                var h = new DeviceHistory();
                h.Device = d;
                h.Employee = e;
                h.DateOfAssignment = faker.Date.Future(1, d.DateOfService);
                histories.Add(h);
            }

            devices.AddRange(demoDevices);
            histories.AddRange(demoHistories);

            var db = new InventoryDbContext();
            db.Employees.AddRange(employees);
            db.Devices.AddRange(devices);
            db.DeviceHistories.AddRange(histories);
            db.SaveChanges();
        }


    }
}
