using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal interface IBuilding
    {
        string NameOfBuilding { get; set; }
        string AddressOfBuilding {  get; set; }
        int NumberofBuilding {  get; set; }
        int SizeOfStaff {  get; set; }
        string TypeOfBuilding {  get; set; }
        int NumberofStaff { get; set; }

    }
}
