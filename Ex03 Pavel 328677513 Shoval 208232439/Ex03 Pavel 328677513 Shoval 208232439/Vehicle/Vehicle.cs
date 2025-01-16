using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlateNumber;
        private List<Wheel> r_Wheels;
        private EnergySystem m_EnergySystem;
        public Dictionary<string, string> UniquePropertiesOfThisVehicle = new Dictionary<string, string>();

        protected Vehicle(int i_NumOfWheels, float i_MaxAirPressureForWheel, EnergySystem i_EnergySystem)
        {
            UniquePropertiesOfThisVehicle.Add("ModelName", "Enter the name of the model: ");

            r_Wheels = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_MaxAirPressureForWheel);
                r_Wheels.Add(newWheel);
            }

            m_EnergySystem = i_EnergySystem; 
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicensePlateNumber
        {
            get { return m_LicensePlateNumber; }
            set { m_LicensePlateNumber = value; }
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
            set { r_Wheels = value; }
        }

        public EnergySystem EnergySystem
        {
            get { return m_EnergySystem; }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in r_Wheels)
            {
                float airToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.InflateSingleWheel(airToAdd);
            }
        }

        public void InitializeAirInAllWheels(float i_AirToInflate)
        {
            foreach (Wheel wheel in r_Wheels)
            {
                wheel.InflateSingleWheel(i_AirToInflate);
            }
        }

        public void InitializeManufacturerNameInAllWheels()
        {
            string manufacturerName = r_Wheels[0].ManufacturerName;

            foreach (Wheel wheel in r_Wheels)
            {
                wheel.ManufacturerName = manufacturerName;
            }
        }

        public override string ToString()
        {
            return $"Vehicle Model: {m_ModelName}, License Plate: {m_LicensePlateNumber}";
        }
    }
}
