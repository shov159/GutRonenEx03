using System;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        /// <summary>
        /// יוצרת אובייקט רכב חדש לפי הסוג המבוקש.
        /// </summary>
        /// <param name="i_VehicleTypeFromUI">סוג הרכב המבוקש</param>
        /// <returns>אובייקט Vehicle מתאים</returns>
        public Vehicle CreateNewVehicle(eVehicleTypes i_VehicleTypeFromUI)
        {
            Vehicle newVehicle;

            switch (i_VehicleTypeFromUI)
            {
                case eVehicleTypes.FuelCar:
                    newVehicle = new FuelCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.Truck:
                    newVehicle = new Truck();
                    break;
                default:
                    // אם מוסיפים סוג רכב חדש ל־enum, יתכן שנצטרך להוסיף case חדש כאן:
                    throw new ArgumentException(
                        $"Unknown vehicle type: {i_VehicleTypeFromUI}");
            }

            return newVehicle;
        }
    }
}
