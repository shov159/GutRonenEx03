using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }

        public void InflateSingleWheel(float i_AirToInflate)
        {
            if (i_AirToInflate < 0)
            {
                throw new ArgumentException(
                    "Cannot inflate the wheel with a negative amount of air.",
                    nameof(i_AirToInflate));
            }

            float newAirPressure = CurrentAirPressure + i_AirToInflate;

            if (newAirPressure > MaxAirPressure)
            {
                float maxPossibleToAdd = MaxAirPressure - CurrentAirPressure;

                // זורקים ValueOutOfRangeException (יש לממש במחלקה נפרדת).
                throw new ValueOutOfRangeException(
                    0f,
                    maxPossibleToAdd,
                    string.Format(
                        "Cannot inflate wheel beyond its max air pressure. You tried to add {0}, but you can only add up to {1}.",
                        i_AirToInflate,
                        maxPossibleToAdd));
            }

            CurrentAirPressure = newAirPressure;
        }

         public override string ToString()
        {
            return string.Format(
                "Wheel Manufacturer: {0}, Current Air Pressure: {1}, Max Air Pressure: {2}",
                ManufacturerName,
                CurrentAirPressure,
                MaxAirPressure);
        }
    }
}
