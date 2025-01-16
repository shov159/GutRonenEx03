using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public Dictionary<string, VehicleInGarage> VehiclesInGarage { get; set; }
        public Garage()
        {
            VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        

        public void InsertVehicle(string i_LicensePlateNumber, Vehicle i_Vehicle)
        {
            if (VehiclesInGarage.ContainsKey(i_LicensePlateNumber))
            {
                VehiclesInGarage[i_LicensePlateNumber].Status = eStatusOfVehicleInGarage.InRepair;
            }
            else
            {
                VehiclesInGarage[i_LicensePlateNumber] = new VehicleInGarage(i_Vehicle, eStatusOfVehicleInGarage.InRepair);
            }
        }

        public List<string> GetLicensePlates(eStatusOfVehicleInGarage? i_FilterStatus = null)
        {
            List<string> result = new List<string>();

            foreach (KeyValuePair<string, VehicleInGarage> kvp in VehiclesInGarage)
            {
                if (!i_FilterStatus.HasValue || kvp.Value.Status == i_FilterStatus.Value)
                {
                    result.Add(kvp.Key);
                }
            }

            return result;
        }

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return VehiclesInGarage.ContainsKey(i_LicensePlate);
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, eStatusOfVehicleInGarage i_NewStatus)
        {
            if (VehiclesInGarage.TryGetValue(i_LicensePlateNumber, out VehicleInGarage vehicleInGarage))
            {
                vehicleInGarage.Status = i_NewStatus;
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicensePlateNumber} not found.");
            }
        }

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {
            if (VehiclesInGarage.TryGetValue(i_LicensePlate, out VehicleInGarage vehicleInGarage))
            {
                vehicleInGarage.CurrentVehicle.InflateAllWheelsToMax();
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicensePlate} not found.");
            }
        }
        public void RefuelVehicle(string i_LicensePlate, eFuelType i_FuelType, float i_Amount)
        {
            if (VehiclesInGarage.TryGetValue(i_LicensePlate, out VehicleInGarage vehicleInGarage))
            {
                FuelEnergySystem fuelSystem = vehicleInGarage.CurrentVehicle.EnergySystem as FuelEnergySystem;

                if (fuelSystem == null)
                {
                    throw new InvalidOperationException("Vehicle is not fuel-based.");
                }

                fuelSystem.AddEnergy(i_Amount);
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicensePlate} not found.");
            }
        }
        public void ChargeBattery(string i_LicensePlate, float i_Minutes)
        {
            if (VehiclesInGarage.TryGetValue(i_LicensePlate, out VehicleInGarage vehicleInGarage))
            {
                ElectricEnergySystem electricSystem = vehicleInGarage.CurrentVehicle.EnergySystem as ElectricEnergySystem;

                if (electricSystem == null)
                {
                    throw new InvalidOperationException("Vehicle is not electric.");
                }

                float hoursToAdd = i_Minutes / 60f;
                electricSystem.AddEnergy(hoursToAdd);
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicensePlate} not found.");
            }
        }
        public string GetVehicleDetails(string i_LicensePlate)
        {
            if (VehiclesInGarage.TryGetValue(i_LicensePlate, out VehicleInGarage vehicleInGarage))
            {
                return vehicleInGarage.CurrentVehicle.ToString();
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicensePlate} not found.");
            }
        }

    }
}
