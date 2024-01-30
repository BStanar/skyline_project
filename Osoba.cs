using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal interface Osoba
    {
        string ime { get; set; }
        string prezime {  get; set; }
        DateTime? datumRodjenja { get; set; }
        int broj_telefona { get; set; }

    }
}
