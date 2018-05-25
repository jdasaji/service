using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using maps.CapaEntidad;
using maps.CapaNegocio;
using Newtonsoft.Json;
using System.Web;
using maps.CapaDato;

namespace servicesMaps
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AgentesServices
    {
        // Para usar HTTP GET, agregue el atributo [WebGet]. (El valor predeterminado de ResponseFormat es WebMessageFormat.Json)
        // Para crear una operación que devuelva XML,
        //     agregue [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     e incluya la siguiente línea en el cuerpo de la operación:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public List<Agentes> listarAgentes()
        { 
            
            //  return new cNAgentes().listarAgentes();
            var path = HttpContext.Current.Request.PhysicalApplicationPath;
            using (var streamReader = new StreamReader(path + "agentes.txt"))
            { 
                var content = streamReader.ReadToEnd();
                var objAgentes = JsonConvert.DeserializeObject<List<Agentes>>(content);
                return objAgentes;
            }

            //return new cNAgentes().listarAgentes();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public List<Agentes> listarAgentesPorGPS(float lat, float lon)
        {
            // Agregue aquí la implementación de la operación
            //  return new cNAgentes().listarAgentes();
            //var path = HttpContext.Current.Request.PhysicalApplicationPath;
            //using (var streamReader = new StreamReader(path+"agentes.txt"))
            //{
            //    var content = streamReader.ReadToEnd();
            //    var objAgentes = JsonConvert.DeserializeObject<List<Agentes>>(content);
            //    return objAgentes;
            //}

            return new cNAgentes().listarAgentesPorGPS(lat, lon);
        }
        // Agregue aquí más operaciones y márquelas con [OperationContract]
    }
}
