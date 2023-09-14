using ProyectoAdo.Datos;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Controladores
{
    public class AlumnoControlador
    {
        AlumnoDato datos = new AlumnoDato();


        public int CrearAlumno(string nombre,string ape , int dni,int telefono)
        {
            IPersona alumno = new Alumno(){ 
                Nombre = nombre,
                Apellido = ape,
                DNI = dni,
                Telefono = telefono
            };
            return datos.CrearAlumno(alumno);

        }
        public IEnumerable<IPersona> TraerAlumnos() 
        { 
            return datos.TraerAlumnos();
        }


    }
}
