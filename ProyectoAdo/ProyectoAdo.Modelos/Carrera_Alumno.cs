using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Carrera_Alumno
    {
        public int ID { get; set; }
        public int ID_Carrera { get; set; }
        public int ID_Alumno { get; set; }
        public double Promedio { get; set; }
        public Alumno Alumno { get; set; }
    }
}
