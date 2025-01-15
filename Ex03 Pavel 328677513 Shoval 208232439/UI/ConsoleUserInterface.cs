using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUserInterface
    {
        internal void runMenu(Garage i_Garage, Factory i_Factory)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("==== Welcome to Garage Manage Platform ====");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Please select your wanted function:");
                Console.WriteLine("1) Insert new vehicle");
                Console.WriteLine("2) Display all vehicles license plates in garage");
                Console.WriteLine("3) Update vehicle status");
                Console.WriteLine("4) Inflate wheels to maximum");
                Console.WriteLine("5) Refuel fueled vehicle");
                Console.WriteLine("6) Charge electric vehicle");
                Console.WriteLine("7) Display vehicle details by license plate");
                Console.WriteLine("8) Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        InsertNewVehicle(i_Garage, i_Factory);
                        break;
                    case "2":
                        ShowLicensePlates(i_Garage);
                        break;
                    case "3":
                        ChangeVehicleStatus(i_Garage);
                        break;
                    case "4":
                        InflateWheels(i_Garage);
                        break;
                    case "5":
                        RefuelVehicle(i_Garage);
                        break;
                    case "6":
                        ChargeVehicle(i_Garage);
                        break;
                    case "7":
                        ShowVehicleDetails(i_Garage);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please enter a single 1-8 digit");
                        break;
                }

                if (!exit)
                {
                    Pause();
                }
            }
        }

        private void InsertNewVehicle(Garage i_Garage, Factory i_Factory)
        {
            Console.Write("Enter License Plate: ");
            string plate = Console.ReadLine();

            if (i_Garage.IsVehicleInGarage(plate))
            {
                i_Garage.ChangeVehicleStatus(plate, eStatusOfVehicleInGarage.InRepair);
                Console.WriteLine("Vehicle already in garage. Status set to In Repair.");
                return;
            }

            eVehicleTypes chosenType = ChooseVehicleType();
            Vehicle newVehicle = i_Factory.CreateNewVehicle(chosenType);

            Console.Write("Enter Model Name: ");
            newVehicle.ModelName = Console.ReadLine();

            Console.WriteLine("Would you like to set the same air pressure for all wheels? (y/n)");
            string answer = Console.ReadLine();
            answer = CheckIfAirInputIsValid(answer);

            if (answer.ToLower() == "y")
            {
                Console.Write("Enter air pressure for all wheels: ");
                float pressure = float.Parse(Console.ReadLine());
                newVehicle.InitializeAirInAllWheels(pressure);
            }
            else
            {
                for (int i = 0; i < newVehicle.Wheels.Count; i++)
                {
                    Console.Write($"Enter air pressure for wheel #{i + 1}: ");
                    float pressure = float.Parse(Console.ReadLine());
                    newVehicle.Wheels[i].CurrentAirPressure = pressure;
                }
            }



            Console.Write("Enter Owner Name: ");
            string ownerName = Console.ReadLine();
            Console.Write("Enter Owner Phone: ");
            string ownerPhone = Console.ReadLine();

            i_Garage.InsertVehicle(plate, newVehicle, ownerName, ownerPhone);
            Console.WriteLine("Vehicle inserted successfully (InRepair).\n");
        }

        /*private void GetUniqueInfoForVehicles( i_New)
        {
            List<UniqueInfoForEachVehicle> info = new List<UniqueInfoForEachVehicle>();
            newVehicle.GetPropertyDefinitions();
        }*/

        private string CheckIfAirInputIsValid(string i_UserInput)
        {
            while (i_UserInput.ToLower() != "y" && i_UserInput.ToLower() != "n")
            {
                Console.WriteLine("Invalid input! Please enter: y/n");
                i_UserInput = Console.ReadLine();
            }

            return i_UserInput;
        }

        private eVehicleTypes ChooseVehicleType()
        {
            Console.WriteLine("Choose the type of vehicle from the list below:");
            eVehicleTypes[] types = (eVehicleTypes[])Enum.GetValues(typeof(eVehicleTypes));
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {types[i]}");
            }

            int choiceIdx;
            while (true)
            {
                Console.Write($"Your choice (1-{types.Length}): ");
                if (int.TryParse(Console.ReadLine(), out choiceIdx) &&
                   choiceIdx >= 1 && choiceIdx <= types.Length)
                {
                    break;
                }
                Console.WriteLine("Invalid choice, try again.");
            }

            return types[choiceIdx - 1];
        }

        private void ShowLicensePlates(Garage i_Garage)
        {
            Console.WriteLine("License plates in garage:");
            List<string> plates = i_Garage.GetLicensePlates();
            if (plates.Count == 0)
            {
                Console.WriteLine("(none)");
            }
            else
            {
                foreach (string plate in plates)
                {
                    Console.WriteLine(" - " + plate);
                }
            }
        }

        private void ChangeVehicleStatus(Garage i_Garage)
        {
            Console.Write("Enter license plate: ");
            string plate = Console.ReadLine();
            Console.WriteLine("Choose new status: 1) InRepair, 2) Repaired, 3) Paid");
            string statusChoice = Console.ReadLine();
            eStatusOfVehicleInGarage newStatus = eStatusOfVehicleInGarage.InRepair;
            switch (statusChoice)
            {
                case "1":
                    newStatus = eStatusOfVehicleInGarage.InRepair;
                    break;
                case "2":
                    newStatus = eStatusOfVehicleInGarage.Repaired;
                    break;
                case "3":
                    newStatus = eStatusOfVehicleInGarage.Paid;
                    break;
            }

            try
            {
                i_Garage.ChangeVehicleStatus(plate, newStatus);
                Console.WriteLine($"Status changed to {newStatus}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void InflateWheels(Garage i_Garage)
        {
            Console.Write("Enter license plate: ");
            string plate = Console.ReadLine();
            try
            {
                i_Garage.InflateWheelsToMaximum(plate);
                Console.WriteLine("Wheels inflated to max.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void RefuelVehicle(Garage i_Garage)
        {
            Console.Write("Enter license plate: ");
            string plate = Console.ReadLine();

            Console.WriteLine("Choose fuel type: 1) Soler, 2) Octan95, 3) Octan96, 4) Octan98");
            string choice = Console.ReadLine();
            eFuelType fuelType = eFuelType.Octan95;
            switch (choice)
            {
                case "1":
                    fuelType = eFuelType.Soler;
                    break;
                case "2":
                    fuelType = eFuelType.Octan95;
                    break;
                case "3":
                    fuelType = eFuelType.Octan96;
                    break;
                case "4":
                    fuelType = eFuelType.Octan98;
                    break;
            }

            Console.Write("Enter amount of fuel (float): ");
            float liters = float.Parse(Console.ReadLine());

            try
            {
                i_Garage.RefuelVehicle(plate, fuelType, liters);
                Console.WriteLine("Refuel succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ChargeVehicle(Garage i_Garage)
        {
            Console.Write("Enter license plate: ");
            string plate = Console.ReadLine();

            Console.Write("How many minutes to charge? ");
            float minutes = float.Parse(Console.ReadLine());

            try
            {
                i_Garage.ChargeBattery(plate, minutes);
                Console.WriteLine("Charge succeeded.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ShowVehicleDetails(Garage i_Garage)
        {
            Console.Write("Enter license plate: ");
            string plate = Console.ReadLine();
            try
            {
                string details = i_Garage.GetVehicleDetails(plate);
                Console.WriteLine(details);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
