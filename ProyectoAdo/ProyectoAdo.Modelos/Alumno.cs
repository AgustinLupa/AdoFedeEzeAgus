using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Alumno : IPersona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Telefono { get; set; }

        public override string ToString()
        {
            return " " + Nombre + " " + Apellido + " " + DNI + " " + Telefono;

        }
    }
}
