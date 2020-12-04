using System.Net;
using System.IO;
using MeDaG1.Models;
using System.Text.RegularExpressions;

namespace MeDaG1.Controllers
{
    public class RequestFromG1 : System.Web.UI.Page
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

        [System.Web.Services.WebMethod]
        public bool HasWord(string input)
             => Regex.Match(GetResponse(), $@"\b({input})\b").Success;
    }
}