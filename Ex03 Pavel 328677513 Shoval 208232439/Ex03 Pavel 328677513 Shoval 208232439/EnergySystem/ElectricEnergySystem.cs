using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// מערכת אנרגיה חשמלית (שעות טעינה).
    /// </summary>
    public class ElectricEnergySystem : EnergySystem
    {
        /// <summary>
        /// בנאי המקבל זמן סוללה מקסימלי וזמן התחלתי.
        /// </summary>
        public ElectricEnergySystem(float i_MaxBatteryTime, float i_InitialBatteryTime)
            : base(i_MaxBatteryTime, i_InitialBatteryTime)
        {
        }

        /// <summary>
        /// מתודה לטעינת סוללה (בשעות טעינה).
        /// </summary>
        public override void AddEnergy(float i_AmountToAdd)
        {
            float newEnergyLevel = ValidateAndCalcNewEnergy(i_AmountToAdd);
            RemainingEnergy = newEnergyLevel;
        }
    }
}