using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// אופנוע מונע דלק.
    /// </summary>
    public class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle()
            : base(new FuelEnergySystem(eFuelType.Octan98, 0f, 6.2f))
        {
            // כאן אפשר לשנות LicenseType או EngineVolume ברירת מחדל אם רוצים.
        }
        public override string ToString()
        {
            return string.Format("Fuel Motorcycle: {0}", base.ToString());
        }
    }
}
