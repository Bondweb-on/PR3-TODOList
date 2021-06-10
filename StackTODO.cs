using System;
using System.IO;
using System.Collections.Generic;

namespace PR3_TODOList
{
    class StackTODO
    {
        List<string> listaToDoPendientes = new List<string>();
        List<string> listaToDoCompletados = new List<string>();


        public void Push(string descripcion)
        {
            this.listaToDoPendientes.Add(descripcion);
        }

        public bool Completado(int respuesta)
        {
            if (respuesta == 1)
            {
                Console.WriteLine("La tarea está completada.");
                string value = this.listaToDoPendientes[this.listaToDoPendientes.Count - 1];
                this.listaToDoCompletados.Add(value);
                this.listaToDoPendientes.RemoveAt(this.listaToDoPendientes.Count - 1);
                return true;
            }
            Console.WriteLine("La tarea no está completada.");
            return false;

        }

        public string Borrar()
        {
            if (this.listaToDoPendientes.Count == 0)
            {
                Console.WriteLine("No hay ninguna tarea en la lista.");
                return null;
            }

            this.listaToDoPendientes.RemoveAt(this.listaToDoPendientes.Count - 1);
            return null;
        }

        public void Exportar()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Tareas completadas."))
                {
                    for (int i = this.listaToDoCompletados.Count - 1; i >= 0; i--)
                    {
                        Console.WriteLine("Tus tareas se exportaron correctamente.");
                        sw.WriteLine(listaToDoCompletados[i]);
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("¡Error!");
            }
            finally
            {
                Console.WriteLine("");
            }
        }
        public void PrintStack()
        {
            Console.WriteLine("Las tareas pendientes son las siguientes:");
            for (int i = this.listaToDoPendientes.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(listaToDoPendientes[i]);
            }

            Console.WriteLine("Las tareas completadas son las siguientes:");
            for (int i = this.listaToDoCompletados.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(listaToDoCompletados[i]);
            }
        }
    }
}