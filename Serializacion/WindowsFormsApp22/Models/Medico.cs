using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploSerializacion.Models
{
    [Serializable]
    public class Medico
    {
        public string Nombre { get; set; }
        public int Matricula { get; set; }
    }
}
