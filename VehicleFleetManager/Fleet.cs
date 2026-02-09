using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleFleetManager
{
    internal class Fleet
    {
        //Create a list to hold vehicles
        private readonly List<Vehicle> _vehicles = new();

        //Method to add vehicles
        public void AddVehicle(Vehicle v)
        {
            if (v == null) throw new ArgumentNullException(nameof(v));
            _vehicles.Add(v);
        }

        //Void to remove vehicles
        public void RemoveVehicle(string model)
        {
            var toRemove = _vehicles.FirstOrDefault(v =>
            v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (toRemove != null)
            {
                _vehicles.Remove(toRemove);
                Console.WriteLine($"{model} removed from fleet.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        //Double to get average mileage
        public double GetAverageMileage() =>
            _vehicles.Count == 0 ? 0 : _vehicles.Average(v => v.Mileage);

        //Void to display the vehicles
        public void DisplayAllVehicles()
        {
            //Control for an empty list
            if (_vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles in the fleet.");
                return;
            }

            //Foreach through the list of vehicles
            Console.WriteLine("\n--- Fleet Summary ---");
            foreach (var v in _vehicles)
            {
                Console.WriteLine(v.GetSummary());
            }
        }

        //Void to service all vehicles
        public void ServiceAllDue()
        {
            int serviced = 0;
            foreach (var v in _vehicles)
            {
                if (v.NeedsService())
                {
                    serviced++;
                    v.PerformService();
                }
            }
            Console.WriteLine($"{serviced} vehicle(s) serviced.");
        }

    }
}
