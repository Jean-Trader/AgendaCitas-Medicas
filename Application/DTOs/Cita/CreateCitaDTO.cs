using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cita
{
    public class CreateCitaDTO
    {
        protected DateTime Inicio { set; get; }
        protected DateTime Fin { set; get; }
        protected int Cupos { set; get; }
        protected int  DoctorID { set; get; }
    }
}
