using EntidadesPOJO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using WebApi.Models;

namespace WebApp.Models.Controls
{
    public class CtrlSelectModel : CtrlBaseModel
    {
        public CtrlSelectModel()
        {
            ViewName = "";
        }

        public string Label { get; set; }
        private string URL_API_SERVICIO = "http://localhost:58520/api/opcion/";
        public string Servicio { get; set; }

        public string Opciones
        {
            get
            {
                var resultado = "";
                List<OpcionLista> lista = CrearPeticion(URL_API_SERVICIO + Servicio);

                foreach(var opt in lista)
                {
                    resultado += "<option value=" + opt.Valor + ">" + opt.Texto + "</option>";
                }
                return resultado;
            }
        }

        private List<OpcionLista> CrearPeticion(string url)
        {
            var cliente = new WebClient();
            var respuesta = cliente.DownloadString(url);
            var apiRes =  JsonConvert.DeserializeObject<ApiResponse>(respuesta);
            var jsonList = JsonConvert.SerializeObject(apiRes.Data);
            return JsonConvert.DeserializeObject<List<OpcionLista>>(jsonList);
        }
    }
}