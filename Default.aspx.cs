using MeDaG1.Controllers;
using System;
using System.Web.UI;

namespace MeDaG1
{
    public partial class _Default : Page
    {
        protected string ResponseColor = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SlowInput.Attributes.Add("autocomplete", "off");
            FastInput.Attributes.Add("autocomplete", "off");
            Console.WriteLine("Não existe um easter egg nesse site.");
            SVerificador.Click += new EventHandler(HasWordBtn_Click);
        }

        protected void HasWordBtn_Click(Object sender,
                           EventArgs e)
        {
            bool success = new RequestFromG1().HasWord(SlowInput.Text);
            AsignColors(success);
            ResponseLabel.Text = (success)
                ? $"A palavra \"{SlowInput.Text}\" ESTÁ na página inicial do G1."
                : $"A palavra \"{SlowInput.Text}\" NÃO ESTÁ na página inicial do G1.";
        }

        // Salva as cores do texto que é mostrado na resposta
        protected void AsignColors(bool success)
        {
            ResponseColor = (success) ? "text-light bg-dark" : "text-danger";
            DataBind();
        }

        // Tentativa de criar um WebMethod na página local
        [System.Web.Services.WebMethod]
        public static string G1Response(string input)
        {
            return new RequestFromG1()
                .HasWord(input)
                ? $"A palavra {input} está na página inicial do G1."
                : $"A palavra {input} não está na página inicial do G1.";
        }
    }
}