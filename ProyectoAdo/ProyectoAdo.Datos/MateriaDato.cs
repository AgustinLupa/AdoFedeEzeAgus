using MySql.Data.MySqlClient;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.Datos
{
    public class MateriaDato
    {
        public IEnumerable<Materia> TraerMaterias()
        {            
            using (var con = Conexion.Conectar())
            {
                var query = new StringBuilder();
                query.Append(GetQuery());                
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = Convert.ToString(query);
                List<Materia> materias = new List<Materia>();
                List<IPersona> alumnos_y_profesores = new List<IPersona>();
                List<Materia_Alumno> materia_Alumnos = new List<Materia_Alumno>();
                List<Materia_Profesor> materia_Profesores = new List<Materia_Profesor>();
                con.Open();
                try
                {                    
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Materia materia = new Materia()
                        {
                            ID = reader.GetInt32("id"),
                            Nombre = reader.GetString("materia"),
                        };
                        materias.Add(materia);

                        IPersona alumno = new Alumno()
                        {
                            ID = reader.GetInt32("alumno_id"),
                            Nombre = reader.GetString("nombre_alumno"),
                            Apellido = reader.GetString("apellido_alumno"),
                            Telefono = reader.GetInt32("telefono_alumno"),
                            DNI = reader.GetInt32("dni_alumno")

                        };
                        alumnos_y_profesores.Add(alumno);

                        IPersona profesor = new Profesor()
                        {
                            ID = reader.GetInt32("profesor_id"),
                            Nombre = reader.GetString("profesor_nombre"),
                            Apellido = reader.GetString("profesor_apellido"),
                            Telefono = reader.GetInt32("profesor_tel"),
                            DNI = reader.GetInt32("profesor_dni")
                        };
                        alumnos_y_profesores.Add(profesor);

                        Materia_Alumno materia_Alumno = new Materia_Alumno()
                        {
                            ID = reader.GetInt32("ma_id"),
                            ID_Materia = reader.GetInt32("ma_idmateria"),
                            ID_Alumno = reader.GetInt32("ma_idalumno"),
                            Nota = reader.GetDouble("ma_nota")
                        };
                        materia_Alumnos.Add(materia_Alumno);

                        Materia_Profesor materia_Profesor = new Materia_Profesor()
                        {
                            ID = reader.GetInt32("mp_id"),
                            ID_Materia = reader.GetInt32("mp_idmateria"),
                            ID_Profesor = reader.GetInt32("mp_profesor"),
                            Horario = reader.GetDateTime("mp_hora")
                        };
                        materia_Profesores.Add(materia_Profesor);

                        foreach (var ma in materia_Alumnos)
                        {
                            foreach (var valores in alumnos_y_profesores)
                            {
                                if (valores is Alumno)
                                {
                                    if (ma.ID_Alumno == valores.ID)
                                    {
                                        ma.Alumno = valores;
                                    }
                                    
                                }
                            }
                        }

                        foreach (var mp in materia_Profesores)
                        {
                            foreach (var valores in alumnos_y_profesores)
                            {
                                if (valores is Profesor)
                                {
                                    if (mp.ID_Profesor == valores.ID)
                                    {
                                        mp.Profesor = valores;
                                    }

                                }
                            }
                        }

                        foreach (var materias_aux in materias)
                        {
                            foreach (var mp in materia_Profesores)
                            {
                                if(materias_aux.ID == mp.ID_Materia)
                                {
                                    materias_aux.Profesores.Add(mp);
                                }
                            }
                        }

                        foreach (var materias_aux in materias)
                        {
                            foreach (var ma in materia_Alumnos)
                            {
                                if (materias_aux.ID == ma.ID_Materia)
                                {
                                    materias_aux.Alumnos.Add(ma);
                                }
                            }
                        }
                    }
                    return materias;
                }
                catch (Exception)
                {
                    return materias;
                }
                finally { con.Close(); }
            }
        }

        public int CrearMateria(Materia materia)
        {
            int id = 0;
            using (MySqlConnection con = Conexion.Conectar())
            {
                var query = "INSERT INTO materia(nombre)" +
                    "Values (@Nombre);" +
                    "SELECT LAST_INSERT_ID() AS id;";
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);                    
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

        private string GetQuery()
        {
            return " SELECT m.id, m.nombre as materia, " +
                    "a.id as alumno_id, a.nombre as nombre_alumno, a.apellido as apellido_alumno, a.dni as dni_alumno," +
                    "a.telefono as telefono_alumno, " +
                    "p.id as profesor_id, p.nombre as profesor_nombre, p.apellido as profesor_apellido," +
                    "p.dni as profesor_dni, p.telefono as profesor_tel, " +
                    "mp.id as mp_id, mp.id_materia as mp_idmateria, mp.id_profesor as mp_profesor, mp.horario as mp_hora, " +
                    "ma.id as ma_id, ma.id_materia as ma_idmateria, ma.id_alumno as ma_idalumno, ma.nota as ma_nota " +
                    "FROM materia m " +
                    "INNER JOIN materia_alumno as ma on ma.id_materia = m.id " +
                    "INNER JOIN materia_profesor as mp on mp.id_materia = m.id " +
                    "INNER JOIN profesor as p on p.id = mp.id_profesor " +
                    "INNER JOIN alumno as a on a.id = ma.id_alumno ";
        }
    }
}
