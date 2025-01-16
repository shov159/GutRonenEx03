using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool IsCarryingCooledContent { get; set; }
        public float CargoVolume { get; set; }

        public Truck()
            : base(14, 29f, new FuelEnergySystem(eFuelType.Soler, 0f, 125f))
        {
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, Carrying Cooled Content: {1}, Cargo Volume: {2} liters",
                base.ToString(),
                IsCarryingCooledContent,
                CargoVolume);
        }
    }
}
