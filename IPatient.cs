using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal interface IPatient:IPerson
    {
        string PatientID { get; set; }
        DateTime CheckInDate { get; set; }
        string Diagnosis {  get; set; }
        bool HasInshurance { get; set; }
        bool IsAdmitted { get; set; }

        void Admit(DateTime admissionDate);
        void Discharge();
        string GetPatientDetails();
    }
}
