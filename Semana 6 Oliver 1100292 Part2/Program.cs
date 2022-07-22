using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Semana_6_Oliver_1100292_Part2
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            string TipoCaso, FechaCaso, UbicacionCaso, DetalleCaso, cedula, Nombre, Apellido, Direccion, Telefono;
            int NumeroCaso;
            try
            {
                string Select = "Si";
                while (Select.ToUpper()=="SI")
                {   

                    Console.WriteLine("Inserte los datos del caso");
                    Console.WriteLine("Tipo de caso:");
                    TipoCaso = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Fecha del caso:");
                    FechaCaso = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Ubicacion del caso:");
                    UbicacionCaso = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Detalles del caso:");
                    DetalleCaso = Console.ReadLine();
                    Console.WriteLine();


                    WS.MyWSSoapClient soapClient1 = new WS.MyWSSoapClient();
                    WS.Caso caso = new WS.Caso()
                    {
                        TipoCaso=TipoCaso,
                        FechaCaso=FechaCaso,
                        UbicasionCaso=UbicacionCaso,
                        DetalleCaso=DetalleCaso,
                    };
                    WS.Respuesta respuesta = soapClient1.RegistroCaso(caso);
                    Console.WriteLine($"Transaccion completa {respuesta.Mensaje}");
                    log.Debug("Caso Registrado");
                    Console.ReadKey();
                   

                    //persona
                    Console.WriteLine("Inserte los datos de la persona");
                    Console.WriteLine("Cedula:");
                    cedula= Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Nombre:");
                    Nombre= Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Apellido:");
                    Apellido= Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Direccion:");
                    Direccion= Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Telefono:");
                    Telefono= Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Numero del Caso:\n");
                    NumeroCaso= int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    WS.MyWSSoapClient soapClient = new WS.MyWSSoapClient();
                    WS.Persona persona = new WS.Persona()
                    {
                        Cedula = cedula,
                        Nombre = Nombre,
                        Apellido = Apellido,
                        Direccion = Direccion,
                        Telefono = Telefono,
                        IdCaso = NumeroCaso
                    };
                    WS.Respuesta respuesta2 = soapClient.RegistroPersona(persona);
                    Console.WriteLine($"Transaccion completa {respuesta2.Mensaje}");
                    log.Debug("Persona Registrada");

                    Console.WriteLine("Deseas introducir otro caso?");
                    Select = Console.ReadLine();
                    Console.Clear();
                }

            }
            catch (Exception err)
            {

                log.Error(err); 
            }
          


        }
    }
}
