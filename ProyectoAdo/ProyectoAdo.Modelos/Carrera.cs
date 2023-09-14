using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Carrera
    {
        public int ID {  get; set; }
        public string Nombre { get; set; }

        public int Duracion  { get; set; }
        public string Modalidad { get; set;}
        public List<Carrera_Alumno> AlumnoList { get; set;}
    }
}
