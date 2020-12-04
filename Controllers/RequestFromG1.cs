using System.Net;
using System.IO;
using MeDaG1.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MeDaG1.Controllers
{

    // Tentativa de criar um WebMethod como controller
    public class RequestFromG1 : Controller
    {
        private WebClient client = new WebClient();

        public RequestFromG1() => client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        private string GetResponse()
        {
            Stream data = client.OpenRead(G1Request.URL);
            StreamReader reader = new StreamReader(data);
            string response = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return response;
        }

        public bool HasWord(string input)
             => Regex.Match(GetResponse(), $@"\b({input})\b").Success;

        [System.Web.Services.WebMethod]
        public static string HasWordWeb(string input)
            => Regex.Match(new RequestFromG1().GetResponse(), $@"\b({input})\b").Success.ToString();
    }
}