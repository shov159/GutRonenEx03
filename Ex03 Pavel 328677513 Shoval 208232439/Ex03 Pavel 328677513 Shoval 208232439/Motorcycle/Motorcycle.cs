using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public eMotorcycleLicenseType LicenseType { get; set; }
        public int EngineVolume { get; set; }

        protected Motorcycle(EnergySystem i_EnergySystem)
            : base(2, 32f, i_EnergySystem)
        {
        }

        /*public override List<(string PropertyName, string Prompt, string DataType)> GetPropertyDefinitions()
        {
            List<(string PropertyName, string Prompt, string DataType)> properties = base.GetPropertyDefinitions();
            properties.Add(("LicenseType", "Enter license type (A1/A2/B1/B2):", "eMotorcycleLicenseType"));
            properties.Add(("EngineVolume", "Enter engine volume (int):", "int"));
            return properties;
        }*/

        public override string ToString()
        {
            return string.Format(
                "{0}, License Type: {1}, Engine Volume: {2}cc",
                base.ToString(),
                LicenseType,
                EngineVolume);
        }
    }
}
