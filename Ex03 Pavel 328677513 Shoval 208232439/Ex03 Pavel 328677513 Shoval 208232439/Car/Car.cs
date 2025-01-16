using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfDoorsInCar = 5;
        private const float k_MaxAirPreassureForWheel = 34f;
        private eCarColor m_CarColor;
        public eCarNumberOfDoors NumberOfDoors { get; set; }

        protected Car(EnergySystem i_EnergySystem) : base(k_NumberOfDoorsInCar, k_MaxAirPreassureForWheel, i_EnergySystem)
        {
            UniquePropertiesOfThisVehicle.Add("CarColor", "Enter the color of your car: ");
            UniquePropertiesOfThisVehicle.Add("NumberOfDoors", "Enter the number of doors your car has: ");
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set
            {
                m_CarColor = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, Car Color: {1}, Number of Doors: {2}",
                base.ToString(),
                CarColor,
                NumberOfDoors);
        }
    }
}
