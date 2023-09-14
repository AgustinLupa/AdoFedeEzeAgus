using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Materia
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Materia_Alumno> Alumnos { get; set; } = new List<Materia_Alumno>();
        public List<Materia_Profesor> Profesores { get; set; } = new List<Materia_Profesor>();

        public override string ToString()
        {
            return " " + Nombre;

        }
    }

}
