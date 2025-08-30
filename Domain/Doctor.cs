using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor : Person
    {
        protected string Specialty { set; get; }
        [Key]
        protected int License { set; get; }
        public Doctor(string nombre, string apellido, int edad, int telefono, string especialidad, int licencia)
            : base(nombre, apellido, edad, telefono)
        {
            Specialty = especialidad;
            License = licencia;
        }
        public void setSpecialty(string especialidad) => Specialty = especialidad.Trim();
        public void setLicense(int licencia) => License = licencia;
        public string getSpecialty() => Specialty;
        public int getLicense() => License;
    }
}
