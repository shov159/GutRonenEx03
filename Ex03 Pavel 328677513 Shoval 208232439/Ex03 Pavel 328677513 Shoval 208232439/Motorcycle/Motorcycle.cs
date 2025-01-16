using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public eMotorcycleLicenseType LicenseType { get; set; }
        public int EngineVolume { get; set; }

        protected Motorcycle(EnergySystem i_EnergySystem) : base(2, 32f, i_EnergySystem)
        {
            UniquePropertiesOfThisVehicle.Add("LicenseType", "Enter the license type: ");
            UniquePropertiesOfThisVehicle.Add("EngineVolume", "Enter the engine volume: ");
        }

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
