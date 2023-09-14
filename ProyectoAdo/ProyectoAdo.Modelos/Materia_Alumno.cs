using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Materia_Alumno
    {
        public int ID { get; set; }
        public int ID_Materia { get; set; }
        public int ID_Alumno { get; set; }
        public double Nota { get; set; }
        public IPersona Alumno { get; set; }
    }
}
