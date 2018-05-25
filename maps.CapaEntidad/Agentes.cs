using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maps.CapaEntidad
{
    public class Agentes 
    {
         
        public int Identificador { get; set; }
        public string NombreAgente { get; set; }
        public string DireccionAgente { get; set; }
        public string DireccionComplementaria { get; set; }
        public float GpsxLectura { get; set; }
        public float GpsyLectura { get; set; }
        public string HorarioAtencion { get; set; }
    }
}
