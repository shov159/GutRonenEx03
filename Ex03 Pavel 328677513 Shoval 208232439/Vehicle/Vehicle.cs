using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlateNumber;
        private readonly List<Wheel> r_Wheels;
        private EnergySystem m_EnergySystem;

        protected Vehicle(int i_NumOfWheels, float i_MaxAirPressureForWheel, EnergySystem i_EnergySystem)
        {
            r_Wheels = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                r_Wheels.Add(new Wheel
                {
                    ManufacturerName = "DefaultManufacturer",
                    MaxAirPressure = i_MaxAirPressureForWheel,
                    CurrentAirPressure = 0f
                });
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

        public IReadOnlyList<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public EnergySystem EnergySystem
        {
            get { return m_EnergySystem; }
        }

        public virtual List<UniqueInfoForEachVehicle> GetPropertyDefinitions()
        {
            List<UniqueInfoForEachVehicle> info = new List<UniqueInfoForEachVehicle>();
            info.Add(new UniqueInfoForEachVehicle("ModelName", "Enter model name:"));
            info.Add(new UniqueInfoForEachVehicle("LicensePlateNumber", "Enter license plate:"));

            return info;
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


        public override string ToString()
        {
            return $"Vehicle Model: {m_ModelName}, License Plate: {m_LicensePlateNumber}";
        }
    }
}
