using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// אופנוע חשמלי.
    /// </summary>
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle()
            : base(new ElectricEnergySystem(i_MaxBatteryTime: 2.9f, i_InitialBatteryTime: 0f))
        {
        }
    }
}
