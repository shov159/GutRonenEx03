using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// מכונית חשמלית.
    /// </summary>
    public class ElectricCar : Car
    {
        public ElectricCar()
            : base(new ElectricEnergySystem(i_MaxBatteryTime: 5.4f, i_InitialBatteryTime: 0f))
        {
            // אם צריך הגדרות נוספות ייחודיות למכונית חשמלית, אפשר להוסיף כאן.
        }
        public override string ToString()
        {
            return string.Format("Electric Car: {0}", base.ToString());
        }
    }
}
