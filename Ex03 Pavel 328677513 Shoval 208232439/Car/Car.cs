using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfDoorsInCar = 5;
        private const float k_MaxAirPreassureForWheel = 34f;
        public eCarColor CarColor { get; set; }
        public eCarNumberOfDoors NumberOfDoors { get; set; }

        protected Car(EnergySystem i_EnergySystem) : base(k_NumberOfDoorsInCar, k_MaxAirPreassureForWheel, i_EnergySystem)
        {

        }

        /*public override List<(string PropertyName, string Prompt, string DataType)> GetPropertyDefinitions()
        {
            List<(string PropertyName, string Prompt, string DataType)> properties = base.GetPropertyDefinitions();
            properties.Add(("CarColor", "Enter car color (Blue/Black/White/Gray):", "eCarColor"));
            properties.Add(("NumberOfDoors", "Enter number of doors (2/3/4/5):", "eCarNumberOfDoors"));
            return properties;
        }*/

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
