using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using maps.CapaEntidad;

namespace maps.CapaDato
{
    public class cDAgentes
    {

        private string cone = ConfigurationManager.ConnectionStrings["cone"].ToString();
        public List<Agentes> listarAgentes()
        {

            List<Agentes> list = new List<Agentes>();
            SqlConnection cn = new SqlConnection(cone);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_agentesAll", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader lee = cmd.ExecuteReader();
            while (lee.Read())
            {
                Agentes entidad = new Agentes();
                entidad.Identificador = Convert.ToInt32(lee["Identificador"]);
                entidad.NombreAgente = lee["NombreAgente"].ToString();
                entidad.DireccionAgente = lee["DireccionAgente"].ToString();
                entidad.DireccionComplementaria = lee["DireccionComplementaria"].ToString();
                entidad.GpsxLectura = float.Parse(lee["gpsxLectura"].ToString());
                entidad.GpsyLectura = float.Parse(lee["gpsyLectura"].ToString());
                entidad.HorarioAtencion = lee["HorarioAtencion"] == DBNull.Value ? null : lee["HorarioAtencion"].ToString();
                list.Add(entidad);
            }
            cn.Close();
            return list;
        }
        public List<Agentes> listarAgentesPorGPS(float lat, float lon)
        {

            List<Agentes> list = new List<Agentes>();
            SqlConnection cn = new SqlConnection(cone);
            cn.Open();
            SqlCommand cmd = new SqlCommand("sp_listar_agentes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@lat", lat);
            cmd.Parameters.AddWithValue("@lon", lon);
            IDataReader lee = cmd.ExecuteReader();
            while (lee.Read())
            {
                Agentes entidad = new Agentes();
                entidad.Identificador = Convert.ToInt32(lee["Identificador"]);
                entidad.NombreAgente = lee["NombreAgente"].ToString();
                entidad.DireccionAgente = lee["DireccionAgente"].ToString();
                entidad.DireccionComplementaria = lee["DireccionComplementaria"].ToString();
                entidad.GpsxLectura = float.Parse(lee["gpsxLectura"].ToString());
                entidad.GpsyLectura = float.Parse(lee["gpsyLectura"].ToString());
                entidad.HorarioAtencion = lee["HorarioAtencion"] == DBNull.Value ? null : lee["HorarioAtencion"].ToString();
                list.Add(entidad);
            }
            cn.Close();
            return list;
        }
    }
}
