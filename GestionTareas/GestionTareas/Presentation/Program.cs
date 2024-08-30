using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTareas.Services;
using GestionTareas.Data;

namespace GestionTareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsTareaRepository repository = new clsTareaRepository();
            clsTareasService service = new clsTareasService(repository);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gestion de Tareas:");
                Console.WriteLine("1. Agregar Tareas");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Marcar Tarea como completada");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese la Descripcion de la tarea: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Ingrese la fecha limite (dd/mm/yyyy) o deje en blanco para no establecer fecha: ");
                        string fechaInput = Console.ReadLine();
                        DateTime? fechalimite = null;
                        //validacion del formato de fecha en caso de no cumplirse no se registra la tarea
                        if (DateTime.TryParse(fechaInput, out DateTime fecha))
                        {
                            fechalimite = fecha;
                        }
                        service.AgregarTarea(descripcion, fechalimite);
                        break;

                        case "2":
                        var tareas = service.ObtenerTarea();
                        Console.WriteLine("\nlista de Tareas:");
                        //ciclo recorriendo la lista de tareas
                        for (int i = 0; i < tareas.Count; i++)
                        {
                            var tarea = tareas[i];
                            Console.WriteLine($"{i + 1}. {tarea.Descripcion} - Fecha limite: {tarea.FechaLimite?.ToString("dd/mm/yyyy") ?? "No especificada"} - Completada: {tarea.EstaCompleta}");
                            
                        }
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                        case "3":
                        Console.Write("Ingrese el numero de la Tarea que desea marcar como completada: ");
                        int indiceMarcar = int.Parse(Console.ReadLine()) - 1;
                        service.MarcarTareaComoCompletada(indiceMarcar);
                        break;

                        case "4":
                        Console.Write("Ingrese el numero de la Tarea que desea eliminar: ");
                        int indiceEliminar = int.Parse(Console.ReadLine()) - 1;
                        service.EliminarTarea(indiceEliminar);
                        break;

                        case "5":
                        return;

                        default:
                        Console.WriteLine("Opcion no valida presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                }
            }
            
        }
    }
}
