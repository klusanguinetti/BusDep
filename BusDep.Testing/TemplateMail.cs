using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.Common;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;

namespace BusDep.Testing
{
    [TestFixture]
    public class TestTemplateMail
    {
        [Test]
        public void CrearItem()
        {
            string file = System.IO.File.ReadAllText(@"C:\Proyectos\GitHub\BusDep\BusDep.Testing\prueba.html");
            List<TemplateMail> il = new List<TemplateMail>();

            il.Add(new TemplateMail
            {
                Descripcion = "UsuarioIncompleto",
                Mail = file
            });
            Console.Write(il.SerializarToJson());

           var respuesta = RecuperarUsuarioEmail(il.First());

        }
        public IRestResponse RecuperarUsuarioEmail(TemplateMail il)
        {
            RestClient client = new RestClient();

            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            string MailGunKey = System.Configuration.ConfigurationManager.AppSettings["MailGunKey"];

            client.Authenticator = new HttpBasicAuthenticator("api", MailGunKey);

            RestRequest request = new RestRequest();

            request.AddParameter("domain", "allwiners.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Allwiners.com <mailgun@allwiners.com>");
            request.AddParameter("to", "allwiners@allwiners.com");
            request.AddParameter("bcc", "klusanguinetti@gmail.com,lsanguinetti@servexternos.isban-santander.com.ar");
            request.AddParameter("subject", "Recuerda completar tu información");
            request.AddParameter("html", il.Mail);

            request.Method = Method.POST;

            return client.Execute(request);

        }
    }
   
    public class TemplateMail
    {
        public string Descripcion { get; set; }
        public string Mail { get; set; }
    }
}
