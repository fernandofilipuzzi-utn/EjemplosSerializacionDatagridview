using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploSerializacion.Models;

namespace EjemploSerializacion.Controllers
{
    [Serializable]
    public class Sistema
    {
        public List<Medico> Medicos = new List<Medico>();
        public List<HistorialMedico> historiales = new List<HistorialMedico>();
    }
}
