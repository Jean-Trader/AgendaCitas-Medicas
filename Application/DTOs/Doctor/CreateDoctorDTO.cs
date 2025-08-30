using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Doctor
{
    public class CreateDoctorDTO
    {
        public int Lisence { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Tel { get; set; }
        public string Specialty { get; set; }
    }
}
