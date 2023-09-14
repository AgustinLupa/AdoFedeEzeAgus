using MySql.Data.MySqlClient;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Datos
{
    public class ProfesorDato
    {
        public IEnumerable<IPersona> TraerProfesores()
        {
            List<IPersona> profesores = new List<IPersona>();
            using (var con = Conexion.Conectar())
            {
                var query = "SELECT * FROM profesor";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        IPersona profesor = new Profesor()
                        {
                            ID = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            Telefono = reader.GetInt32("telefono"),
                            DNI = reader.GetInt32("dni")
                        };
                        profesores.Add(profesor);
                    }
                    return profesores;
                }
                catch (Exception)
                {
                    return new List<IPersona>();
                }
                finally { con.Close(); }
            }
        }

        public int CrearAlumno(IPersona profesor)
        {
            int id = 0;
            using (MySqlConnection con = Conexion.Conectar())
            {
                var query = "INSERT INTO profesor(nombre, apellido, telefono, dni)" +
                    "Values (@Nombre, @Apellido, @Telefono, @Dni);" +
                    "SELECT LAST_INSERT_ID() AS id;";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", profesor.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", profesor.Telefono);
                    cmd.Parameters.AddWithValue("@Dni", profesor.DNI);
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
                    return 0;
                }
            }
        }
    }
}
