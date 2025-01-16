using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public Vehicle CurrentVehicle { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public eStatusOfVehicleInGarage Status { get; set; }
        public Dictionary<string, string> UniquePropertiesOfThisVehicle = new Dictionary<string, string>();

        public VehicleInGarage(Vehicle i_Vehicle, eStatusOfVehicleInGarage i_InitialStatus)
        {
            UniquePropertiesOfThisVehicle.Add("OwnerName", "Enter the name of the owner: ");
            UniquePropertiesOfThisVehicle.Add("OwnerPhoneNumber", "Enter the phone number of the owner: ");
            CurrentVehicle = i_Vehicle;
            Status = i_InitialStatus;
        }
    }
}
