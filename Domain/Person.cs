using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Person
    {   
        protected string Name { set; get; }
        protected string LastName {set; get; }
        protected int Age {  set; get; }
        protected int Tel {  set; get; }

        public Person(string nombre, string apellido,int edad,int telefono ) 
        { 
         Name = nombre;
         LastName = apellido;
         Tel = telefono;
         Age = edad;
        }

        public void setName(string nombre) => Name = nombre.Trim();
        public void setLastName(string apellido) => LastName = apellido.Trim();
        public void setAge(int edad) => Age = edad;
        public void setTel(int telefono) => Tel = telefono;
        public string getName() => Name;
        public string getLastName() => LastName;
        public int getAge() => Age;
        public int getTel() => Tel;
        

    }
}
