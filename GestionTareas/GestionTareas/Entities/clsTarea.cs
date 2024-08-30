using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Entities
{
    public class clsTarea
    {
        public string Descripcion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public bool EstaCompleta { get; set; } = false;
    }
}
