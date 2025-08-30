using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cita 
    {
        protected  int CitaId { set; get; }
        protected DateTime Inicio { set; get; }
        protected DateTime Fin { set; get; }
        protected string Turno { set; get; }
        protected int Cupos { set; get; }
        public int CuposDisponibles => Cupos - (Pacientes?.Count ?? 0);
        protected string Tipo => Medico?.getSpecialty() ?? "General";

        protected List<User> Pacientes = new List<User>();
        protected Doctor Medico { set; get; }

        public Cita(DateTime inicio, DateTime fin,string tipo, bool estado, Doctor doctor)
        {
            CitaId++;

            Inicio = inicio;
            Fin = fin;
            Fin = fin;
            Medico = doctor;

            if (inicio.Hour < 12)
            {
                Turno = "Mañana";
            }
            else if (inicio.Hour >= 12 && inicio.Hour < 18)
            {
                Turno = "Tarde";
            }
            else
            {
                Turno = "Noche";
            }

        }
        public bool AgendarCita(User paciente)
        {
            if (CuposDisponibles > 0 && !Pacientes.Contains(paciente))
            {
                Pacientes.Add(paciente);
                return true;
            }
            return false;
        }
    }
}
