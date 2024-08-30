using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  GestionTareas.Entities;

namespace GestionTareas.Data
{
    public class clsTareaRepository
    {
        private List<clsTarea> tareas = new List<clsTarea>();
        public void AgregarTarea(clsTarea tarea)
        {
            tareas.Add(tarea);
        }
        public List<clsTarea> ObtenerTarea()
        {
            return tareas;
        }
        public void EliminarTarea(int index) 
        {
            //logica para validar que se envia una posicion de la lista valida
            if (index >= 0 && index < tareas.Count)
            {
                tareas.RemoveAt(index);
            }
        }
    }
}
