using System;
using System.Globalization;

namespace PR3_TODOList
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            CultureInfo culture = new CultureInfo("es-MX");
            string todayAsStr = today.ToString(culture);
            string[] fechaHora = todayAsStr.Split(" ");
            string fechaDeHoy = fechaHora[0];
            string fechaFinal = fechaDeHoy.Replace("/", "-");

            StackTODO listaTareasPendientes = new StackTODO();
            listaTareasPendientes.Push("Sacar la basura." + " " + fechaFinal);
            listaTareasPendientes.Push("Subir al cerro." + " " + fechaFinal);

            StackTODO listaTareasCompletadas = new StackTODO();

            Console.WriteLine("Bienvenido a tu lista de tareas.");

            string opcion = "";
            while (opcion != "9")
            {
                opcion = "";
                while (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "9")
                {
                    Console.WriteLine("1) Agregar tarea.");
                    Console.WriteLine("2) Marcar como completado la tarea previamente agregada.");
                    Console.WriteLine("3) Mostrar las tareas, organizadas por pendientes y completadas.");
                    Console.WriteLine("4) Borrar tarea previamente agregada.");
                    Console.WriteLine("5) Guardar/Exportar tareas a un archivo de texto.");
                    Console.WriteLine("9) Salir.");
                    Console.WriteLine("");
                    Console.WriteLine("Porfavor, selecciona una opción:");
                    opcion = Console.ReadLine();

                    if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "9")
                    {
                        Console.WriteLine("La opción seleccionada no es correcta.");
                    }
                }
                if (opcion == "1")
                {
                    Console.WriteLine("Añade la tarea:");
                    string tarea = Console.ReadLine();
                    string tareaConFecha = (tarea + " " + fechaFinal);
                    listaTareasPendientes.Push(tareaConFecha);
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("¿La tarea está completada?");
                    Console.WriteLine("Presiona 1 si está completada o presiona 2 si no lo está.");
                    int respuesta = int.Parse(Console.ReadLine());
                    listaTareasPendientes.Completado(respuesta);

                }
                else if (opcion == "3")
                {
                    listaTareasPendientes.PrintStack();
                }
                else if (opcion == "4")
                {
                    listaTareasPendientes.Borrar();
                }
                else if (opcion == "5")
                {
                    listaTareasCompletadas.Exportar();
                }
                else if (opcion == "9")
                {
                    Console.WriteLine("Gracias por utilizar el programa.");
                    Console.WriteLine("¡Hasta la próxima!");
                }
                else
                {

                }
            }
        }
    }
}
