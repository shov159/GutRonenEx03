using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class UniqueInfoForEachVehicle
    {
        public string PropertyName { get; set; }
        public string Prompt { get; set; }

        public UniqueInfoForEachVehicle(string i_PropertyName, string i_Prompt)
        {
            PropertyName = i_PropertyName;
            Prompt = i_Prompt;
        }
    }
}
