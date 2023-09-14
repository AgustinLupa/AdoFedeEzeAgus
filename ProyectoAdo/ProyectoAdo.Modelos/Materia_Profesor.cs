using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Modelos
{
    public class Materia_Profesor
    {
        public int ID { get; set; }
        public int ID_Materia { get; set; }
        public int ID_Profesor { get; set; }
        public DateTime Horario { get; set; }
        public IPersona Profesor { get; set; }
    }
}
