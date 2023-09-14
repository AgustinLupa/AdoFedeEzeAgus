using ProyectoAdo.Datos;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Controladores
{
    public class CarreraControlador
    {
        private CarreraDato datos = new CarreraDato();
        public IEnumerable<Carrera> TraerCarrearaPorAlumno ()
        {
        return datos.TraerCarrerasPorAlumnos ();
        }

        public int CrearCarrera(string nom, int duracion,string mod)
        {
            Carrera carrera = new Carrera()
            {
                Nombre = nom,
                Duracion = duracion,
                Modalidad = mod
            };
          
            return datos.CrearCarrera(carrera);
        }
    }
}
