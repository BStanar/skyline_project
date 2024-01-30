using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal interface IPerson
    {
        string name { get; set; }
        string lastname {  get; set; }
        DateTime? dateOfBirth { get; set; }
        int telephoneNumber { get; set; }

    }
}
