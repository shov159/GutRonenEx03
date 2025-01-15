using System;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// מכונית על דלק (בנזין).
    /// </summary>
    public class FuelCar : Car
    {
        public FuelCar()
            : base(new FuelEnergySystem(eFuelType.Octan95, 0f, 52f))
        {
            //  - קריאה לבנאי הבסיס Car, שמעביר מערכת אנרגיה מסוג FuelEnergySystem
            //  - כאן ניתן להגדיר (אם רוצים) ברירות מחדל נוספות לצבע או דלתות, וכו'.
        }
        public override string ToString()
        {
            return string.Format("Fuel Car: {0}", base.ToString());
        }
    }
}
