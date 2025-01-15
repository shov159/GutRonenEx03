using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// מערכת אנרגיה מבוססת דלק (ליטרים).
    /// </summary>
    public class FuelEnergySystem : EnergySystem    {
        public eFuelType FuelType { get; set; }

        /// <summary>
        /// בנאי המקבל סוג דלק, כמות התחלתית, וקיבולת מקסימלית.
        /// </summary>
        public FuelEnergySystem(eFuelType i_FuelType, float i_InitialFuelAmount, float i_MaxFuelCapacity)
            : base(i_MaxFuelCapacity, i_InitialFuelAmount)
        {
            FuelType = i_FuelType;
        }

        /// <summary>
        /// מתודה להוספת דלק (בליטרים).
        /// תבצע בדיקות חריגה באמצעות המתודה המשותפת בבסיס, ותעדכן.
        /// </summary>
        public override void AddEnergy(float i_AmountToAdd)
        {
            float newEnergyLevel = ValidateAndCalcNewEnergy(i_AmountToAdd);
            RemainingEnergy = newEnergyLevel;
        }
    }
}
