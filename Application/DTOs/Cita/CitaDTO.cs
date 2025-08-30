using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cita
{
    public class CitaDTO
    {
        protected int CitaId { set; get; }
        protected DateTime Inicio { set; get; }
        protected DateTime Fin { set; get; }
        protected string Turno { set; get; }
        protected int Cupos { set; get; }
        public int CuposDisponible {get;set;}
        public string NombreMedico { set; get; }

    }
}
