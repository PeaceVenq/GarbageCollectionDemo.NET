using System;

namespace Garbage_Collection_Demo
{
    public class DisposableCar :  IDisposable
    {
        private bool disposedValue;

        public string Name { get; set; }
        public string Description { get; set; }

        private string[] ElgibleLicenses { get; set; }
        public DisposableCar() { }
        public DisposableCar(string name, string description)
        {
            Name = name;
            Description = description;
            ElgibleLicenses = GetElgibleLicenses();

        }

        private string[] GetElgibleLicenses()
        {
            var cars = new string[1000];
            for (int i = 0; i < cars.Length; i++)
            {
                var num = RandomNumGenerator.GenerateRandomFourDigitNum();
                cars[i] = $"TS 17 FX {num}";
            }
            return cars;
        }

        ~DisposableCar()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    ElgibleLicenses = null;
                    Name = null;
                    Description = null;
                    
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DisposableCar()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}


//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals


