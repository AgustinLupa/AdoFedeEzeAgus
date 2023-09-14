using ProyectoAdo.Controladores;
using ProyectoAdo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAdo.View
{
    public class Vista
    {
        public Vista() {
            AlumnoControlador alumCon = new AlumnoControlador();
            CarreraControlador carreraCon = new CarreraControlador();
            MateriaControler matCon = new MateriaControler();
            ProfesorControler proCon = new ProfesorControler();
            int op = 0;

            do
            {
                Console.WriteLine("1 crear Profesor ");
                Console.WriteLine("2 crear Materia ");
                Console.WriteLine("3 crear Alumno ");
                Console.WriteLine("4 crear Carerra ");
                Console.WriteLine("5 Traer profesor");
                Console.WriteLine("6 Traer Materia");
                Console.WriteLine("7 Traer Alumno");
                Console.WriteLine("8 Traer Carrera");
                Console.WriteLine("0 Para Salir");

                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 0:
                        Console.WriteLine("Saliendo Del Programa");
                        break;
                    case 1:
                        {
                            Console.WriteLine("Ingrese nombre");
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese apellido");
                            var apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese DNI");
                            var dni = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese telefono");
                            var telefono = Convert.ToInt32(Console.ReadLine());

                            proCon.CrearProfe(nombre, apellido, dni, telefono);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Ingrese nombre");
                            var nombre = Console.ReadLine();
                            matCon.CrearMateria(nombre);
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Ingrese nombre");
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese apellido");
                            var apellido = Console.ReadLine();
                            Console.WriteLine("Ingrese DNI");
                            var dni = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese telefono");
                            var telefono = Convert.ToInt32(Console.ReadLine());

                            alumCon.CrearAlumno(nombre, apellido, dni, telefono);

                        } break;
                    case 4:
                        {
                            Console.WriteLine("Ingrese nombre");
                            var nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese Duracion");
                            var dura =Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese Modalidad");
                            var mod = Console.ReadLine();
                            carreraCon.CrearCarrera(nombre, dura, mod);

                        }break;
                    case 5:
                        {
                            foreach (var item in proCon.TraerProfesores())
                            {
                                Console.WriteLine(item.ToString());
                            }
                            
                        }break;

                    case 6:
                        {
                            foreach (var item in matCon.TraerMaterias())
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }break;

                        case 7:
                        {
                            foreach (var item in alumCon.TraerAlumnos())
                            {
                               Console.WriteLine(item.ToString());
                            }
                        }break;
                        case 8:
                        {
                            foreach (var item in carreraCon.TraerCarrearaPorAlumno() )
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        break;







                }
            } while (op != 0) ;
        }
    }
}
