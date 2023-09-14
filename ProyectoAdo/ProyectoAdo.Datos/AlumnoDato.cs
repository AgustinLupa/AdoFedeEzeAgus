using MySql.Data.MySqlClient;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Datos
{
    public class AlumnoDato
    {
        public IEnumerable<IPersona> TraerAlumnos()
        {
            List<IPersona> alumnos = new List<IPersona>();
            using (var con = Conexion.Conectar())
            {
                var query = "SELECT * FROM alumno";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        IPersona alumno = new Alumno()
                        {
                            ID = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            Telefono = reader.GetInt32("telefono"),
                            DNI = reader.GetInt32("dni")
                            
                        };
                        alumnos.Add(alumno);
                    }
                    return alumnos;
                }
                catch (Exception)
                {
                    throw;
                }
                finally { con.Close(); }
            }        
        }

        public int CrearAlumno(IPersona alumno)
        {
            int id = 0;
            using (MySqlConnection con = Conexion.Conectar())
            {
                var query = "INSERT INTO alumno(nombre, apellido, telefono, dni)" +
                    "Values (@Nombre, @Apellido, @Telefono, @Dni);" +
                    "SELECT LAST_INSERT_ID() AS id;";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", alumno.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", alumno.Telefono);
                    cmd.Parameters.AddWithValue("@Dni", alumno.DNI);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader.GetInt32("id");
                    }
                    con.Close();
                    return id;
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
        }
    }
}
