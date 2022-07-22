using Semana_6_Oliver_1100292.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Semana_6_Oliver_1100292
{
    /// <summary>
    /// Summary description for MyWS
    /// </summary>
    [WebService(Namespace = "http://oliver.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public Respuesta RegistroCaso(Caso caso)
        {
            Respuesta respuesta = null;
            CasoTableAdapter adapter = new CasoTableAdapter();
            int Rcords = adapter.InsertCaso(caso.TipoCaso, caso.FechaCaso, caso.UbicasionCaso, caso.DetalleCaso);
            if (Rcords == 1)
            {
                respuesta = new Respuesta() { Codigo = 0, Tipo = 0, Mensaje = "Transaccion Completada" };
                log.Debug("Registro fue realizado");
            }
            else
            {
                respuesta = new Respuesta() { Codigo = 1, Tipo = 1, Mensaje = "Transaccion NO fue Completada" };
                log.Error("Registro No pudo ser realizado");
            }


            return respuesta;

        }
        [WebMethod]
        public Respuesta RegistroPersona(Persona persona)
        {
            Respuesta respuesta = null;
            PersonaTableAdapter adapter = new PersonaTableAdapter();
            int Rcords = adapter.InsertPersona(persona.Cedula, persona.Nombre, persona.Apellido, persona.Direccion, persona.Telefono,persona.IdCaso);
            if (Rcords == 1)
            {
                respuesta = new Respuesta() { Codigo = 0, Tipo = 0, Mensaje = "Transaccion Completada" };
                log.Debug("Registro fue realizado");
            }
            else
            {
                respuesta = new Respuesta() { Codigo = 1, Tipo = 1, Mensaje = "Transaccion NO fue Completada" };
                log.Error("Registro No pudo ser realizado");
            }


            return respuesta;
        }
    }
}
