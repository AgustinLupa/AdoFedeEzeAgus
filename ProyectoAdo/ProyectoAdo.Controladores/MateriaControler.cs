using ProyectoAdo.Datos;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Controladores
{
    public class MateriaControler
    {
       private MateriaDato dato = new MateriaDato();

        public int CrearMateria (string nombre)
        {
            Materia mat = new Materia() 
            {
                Nombre=nombre
            };

            return dato.CrearMateria(mat);

        }

        public IEnumerable<Materia> TraerMaterias()
        {
            return dato.TraerMaterias();
        }

    }
}
