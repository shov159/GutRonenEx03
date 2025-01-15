using System;

namespace Ex03.GarageLogic
{

    /// <summary>
    /// מחלקה העוטפת רכב הנמצא במוסך, יחד עם פרטי הבעלים וסטטוס הרכב.
    /// </summary>
    public class VehicleInGarage
    {
        public Vehicle CurrentVehicle { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public eStatusOfVehicleInGarage Status { get; set; }

        /// <summary>
        /// בנאי ברירת מחדל (לא חובה, אפשר גם לבנות בנאי מלא).
        /// </summary>
        public VehicleInGarage()
        {
        }

        /// <summary>
        /// לשימוש נוח יותר, אפשר בנאי מלא (לא חובה).
        /// </summary>
        public VehicleInGarage(
            Vehicle i_Vehicle,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            eStatusOfVehicleInGarage i_InitialStatus)
        {
            CurrentVehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
            Status = i_InitialStatus;
        }
    }
}
