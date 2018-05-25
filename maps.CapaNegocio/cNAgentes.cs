using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using maps.CapaDato;
using maps.CapaEntidad;

namespace maps.CapaNegocio
{
    public class cNAgentes
    {

        public List<Agentes> listarAgentes()
        {
            return new cDAgentes().listarAgentes();
        }
        public List<Agentes> listarAgentesPorGPS(float lat, float lon)
        {
            return new cDAgentes().listarAgentesPorGPS(lat, lon);
        }
    }
}
