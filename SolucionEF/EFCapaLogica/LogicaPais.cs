using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace EFCapaLogica
{
    public class LogicaPais 
    {
        public List<Countries> ObtenerPaisesPorIdioma(String codIdioma)
        {

            List<Countries> paises = new List<Countries>();

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("x-rapidapi-key", "88aa1e0f18msh89a6ffe28e67ba8p12b271jsnc422c57b3ecc");
                client.Headers.Add("x-rapidapi-host", "restcountries-v1.p.rapidapi.com");
                client.Headers.Add("useQueryString", Boolean.TrueString);
                var json = client.DownloadString("https://restcountries-v1.p.rapidapi.com/lang/" + codIdioma);
                dynamic listaPaisesJson = JsonConvert.DeserializeObject(json);

                foreach (var paisJson in listaPaisesJson)
                {
                    paises.Add(new Countries() { Name = paisJson.name, Capital = paisJson.capital, Subregion = paisJson.subregion });
                }
            }
            catch (Exception e)
            {
                throw new ExcepcionPersonalizadaMVC("Error al acceder al servicio web de paises. Detalle: " + e.Message, "ObtenerPaisesPorIdioma("+codIdioma+")");
            }





            return paises;
        }


    }
}
