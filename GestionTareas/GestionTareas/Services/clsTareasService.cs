using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTareas.Entities;
using GestionTareas.Data;

namespace GestionTareas.Services
{
    public class clsTareasService
    {
        
        private readonly clsTareaRepository tareaRepository;
        public clsTareasService(clsTareaRepository repository)
        {
            tareaRepository = repository;
        }
        public void MarcarTareaComoCompletada(int index)
        {
            var tareas = tareaRepository.ObtenerTarea();
            {
                if (index >= 0 && index < tareas.Count)
                {
                    tareas[index].EstaCompleta = true; 
                }
            }
        }
        public void AgregarTarea(string descripcion, DateTime? FechaLimite)
        {
            var tarea = new clsTarea { Descripcion = descripcion, FechaLimite = FechaLimite };
            tareaRepository.AgregarTarea(tarea);
        }
        public void EliminarTarea(int index)
        {
            tareaRepository.EliminarTarea(index);
        }
        public List<clsTarea> ObtenerTarea()
        {
            return tareaRepository.ObtenerTarea();
        }
        

        
        
        

    }
}
