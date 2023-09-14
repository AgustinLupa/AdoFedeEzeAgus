using MySql.Data.MySqlClient;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Datos
{
    public class CarreraDato
    {
        public IEnumerable<Carrera> TraerCarrerasPorAlumnos()
        {
            using (var con = Conexion.Conectar())
            {
                var query = "SELECT c.id, c.nombre, c.duracion, c.modalidad, ca.id_carrera,ca.id as idCarreraPorAlumno, ca.promedio, " +
                    "a.id as idalumno, a.nombre as alumno, a.apellido, a.telefono, a.dni " +
                    "from carreras as c " +
                    "INNER JOIN carrera_alumno as ca on ca.id_carrera = c.id " +
                    "INNER JOIN alumno as a ON ca.id_alumno = a.id";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                List<Carrera> carreras = new List<Carrera>();
                List<Carrera_Alumno> aux = new();
                try
                {
                    var reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Carrera carrera = new Carrera()
                        {
                            ID = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Duracion = reader.GetInt32("duracion"),
                            Modalidad = reader.GetString("modalidad"),                            
                        };
                        carreras.Add(carrera);
                        Alumno alumno = new Alumno()
                        {
                            ID = reader.GetInt32("idalumno"),
                            Nombre = reader.GetString("alumno"),
                            Apellido = reader.GetString("apellido"),
                            Telefono = reader.GetInt32("telefono"),
                            DNI = reader.GetInt32("dni")
                        };
                        Carrera_Alumno carrera_alumno = new Carrera_Alumno()
                        {
                            ID = reader.GetInt32("idCarreraPorAlumno"),
                            Promedio = reader.GetDouble("promedio"),
                            ID_Carrera = reader.GetInt32("id_carrera"),
                            Alumno = alumno,
                        };
                        aux.Add(carrera_alumno);                     
                        
                    }
                    foreach (var item2 in carreras){
                        foreach (var item in aux)
                        {
                            if (item.ID_Carrera == item2.ID)
                            {
                                item2.AlumnoList.Add(item);                               
                            }                              
                        }
                    }
                    return carreras;
                }
                catch
                {
                    return new List<Carrera>();
                }
            }
        }

        public int CrearCarrera(Carrera carrera)
        {
            using (var con = Conexion.Conectar())
            {
                int id = 0;
                var query = "INSERT INTO carrera(nombre, duracion, modalidad) VALUES (@Nombre, @Duracion, @Modalidad)";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Nombre", carrera.Nombre);
                    cmd.Parameters.AddWithValue("@Duracion", carrera.Duracion);
                    cmd.Parameters.AddWithValue("@Modalidad", carrera.Modalidad);
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
