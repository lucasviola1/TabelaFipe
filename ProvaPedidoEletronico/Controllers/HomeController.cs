using ProvaPedidoEletronico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using Microsoft.Ajax.Utilities;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Policy;
using System.Web.UI.HtmlControls;

namespace ProvaPedidoEletronico.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            var homeIndex =  new HomeIndexModel();

            string ano = "/2014-3";

            homeIndex.marca = getMarcas();

            homeIndex.modelo = getModelo();

            homeIndex.ano = getAno();

            homeIndex.resultado = Pesquisar(ano);

            return View(homeIndex);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IEnumerable<Marca> getMarcas() {

            IEnumerable<Marca> marcas = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/carros/marcas");


                var responseTask = client.GetAsync("marcas");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Marca>>();
                    readTask.Wait();
                    marcas = readTask.Result;
                }
                else
                {
                    marcas = Enumerable.Empty<Marca>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return marcas;
            }
        }

        public ModeloNames getModelo()
        {
            string uri = "https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos";

            WebClient webCliente = new WebClient();

            string json = webCliente.DownloadString(uri);

            var model = JsonConvert.DeserializeObject<ModeloNames>(json);

            return model;
        }

        public IEnumerable<Ano> getAno()
        {
            IEnumerable<Ano> ano = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos/5940/anos");

                var responseTask = client.GetAsync("anos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Ano>>();
                    readTask.Wait();
                    ano = readTask.Result;
                }
                else
                {
                    ano = Enumerable.Empty<Ano>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return ano;
            }
        }
        public Resultado Pesquisar(string ano)
        {
            var uriAno = "https://parallelum.com.br/fipe/api/v1/carros/marcas/59/modelos/5940/anos";

            var novaUri = "";
            if (ano != null)
            {
                novaUri = uriAno + ano;
            }
            WebClient webCliente = new WebClient();

            string json = webCliente.DownloadString(novaUri);

            var model = JsonConvert.DeserializeObject<Resultado>(json);

            return model;
        }
    }
}