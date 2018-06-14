using System;
using System.Collections.Generic;
using System.Text;
using System.Net;       // possui classe para pesquisa na internet (WebClient)
using App01_ConsultarCEP.Servico.PCMsys;
using Newtonsoft.Json;    // 'deserializa' a string e transforma em dado de User, ...

namespace App01_ConsultarCEP.Servico
{
    class GetUser
    {
        private static string url_GetUser = "https://www.pcmsys.com.br/WSProtocols/WSProtocol.asmx/GetUsers?idProject={0}&NetUserId={1}";

        public static User buscarUser(string projeto, string netUserId)
        {
            string urlPreenchida = string.Format(url_GetUser, projeto, netUserId);
            WebClient wc = new WebClient();

            string usuario = wc.DownloadString(urlPreenchida);
            /**
            usuario = usuario.Replace("{\"Table\":[", "");
            usuario = usuario.Replace("}]}", "}");
            /**/
            
            User UserReturn = JsonConvert.DeserializeObject<User>(usuario);
            return UserReturn;
        }
        /*
        retorno de:   string usuario = wc.DownloadString(urlPreenchida);

        {"Table":[{"UserId":"64","Name":"NILTON ASSIS","CultureID":"pt","RegNumber":"01","NetUserId":"NILTONASSIS","emailAddress":"NILTON.ASSIS@OUTOTEC.COM",
         "DepartmentId":"2","ActiveStatus":true,"LastAccess":"","CompanyId":"2","Color":"#C4D4AB","Pwd":"xyzw","photoFileName":"NILTONASSIS.jpg","idProject":"1",
         "projectDescription":"OUTOTEC - AMG MINERAÇÃO","cultureDescription":"Português","DepartmentId1":"2","DepartmentDescription":"Coordenador","CompanyId1":"2",
         "CompanyDescription":"OTB - EMISSÃO","qtdeOS":"0"}]}
         */
    }
}
