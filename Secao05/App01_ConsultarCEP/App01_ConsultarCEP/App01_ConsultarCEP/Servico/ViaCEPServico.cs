using System;
using System.Collections.Generic;
using System.Text;
using System.Net;       // possui classe para pesquisa na internet (WebClient)
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;    // 'deserializa' a string e transforma em dado de endereço

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();

            //método síncrono de download (assíncrono seria 'DownloadStringAsync')
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
