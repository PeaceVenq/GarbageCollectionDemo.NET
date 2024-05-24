using System;

namespace Garbage_Collection_Demo
{

    public class Car
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }

        private Car[] EligibleLicenseNumbers { get; set; }

        public Car() { }
        public Car(string name, string description)
        {
            Name = name;
            Description = description;
            EligibleLicenseNumbers = GetElgibleLicenses();

        }

        private Car[] GetElgibleLicenses()
        {
            var cars = new Car[1000];
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car();
            }
            return cars;
        }
    }
}


//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals


