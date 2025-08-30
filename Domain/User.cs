using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Person
    {
        [Key]
        public static int Id { set; get; }
        protected bool IsAdmin { set; get; }
        protected string Password { set; get; }
        protected string Email { set; get; }
        public User(string nombre,string apellido,int edad,int telefono,string email,string contraseña)
            : base(nombre,apellido,edad,telefono) 
        { 
            Id++;
            this.Email = email;
            this.Password = contraseña;
            IsAdmin = false;

        }
        public void setEmail(string email) => Email = email.Trim();
        public void setPassword(string contraseña) => Password = contraseña.Trim();

        public string getEmail() => Email;
        public string getPassword() => Password;
    }
}
