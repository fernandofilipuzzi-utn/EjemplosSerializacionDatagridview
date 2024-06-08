using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploSerializacion.Models
{
    [Serializable]
    public class HistorialMedico
    {
        public DateTime Fecha { get; set; }
        public Medico Medico { get; set; }
    }
}
