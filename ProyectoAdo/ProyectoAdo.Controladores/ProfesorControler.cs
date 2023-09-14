using ProyectoAdo.Datos;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Controladores
{
    public class ProfesorControler
    {
        private ProfesorDato Dato = new ProfesorDato(); 
        public IEnumerable<IPersona> TraerProfesores()
        {
            return Dato.TraerProfesores();  
        }

        public int CrearProfe(string nombre, string ape, int dni, int telefono)
        {
            IPersona profe = new Profesor()
            {
                Nombre = nombre,
                Apellido = ape,
                DNI = dni,
                Telefono = telefono
            };
            return Dato.CrearAlumno(profe);
        }
    }
}
