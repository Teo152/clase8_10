using lib_aplicaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using ut_presentacion.Nucleo;

namespace asp_servicios.Controllers
{
    public class ProductosController : ControllerBase
    {
        private IFacturasAplicacion? iMesaAplicacion = null;

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";

            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpGet]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            this.iMesaAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

            respuesta["Entidades"] = this.iMesaAplicacion!.Listar();
            respuesta["Respuesta"] = "OK";
            respuesta["Fecha"] = DateTime.Now.ToString();
            return JsonConversor.ConvertirAString(respuesta);
        }
    }
}
