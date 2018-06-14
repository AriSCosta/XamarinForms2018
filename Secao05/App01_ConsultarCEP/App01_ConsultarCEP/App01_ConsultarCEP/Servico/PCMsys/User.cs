using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Servico.PCMsys
{
    class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string CultureID { get; set; }
        public string RegNumber { get; set; }
        public string NetUserId { get; set; }
        public string emailAddress { get; set; }
        public string DepartmentId { get; set; }
        public bool ActiveStatus { get; set; }
        public string LastAccess { get; set; }
        public string CompanyId { get; set; }
        public string Color { get; set; }
        public string Pwd { get; set; }
        public string photoFileName { get; set; }
        public string idProject { get; set; }
        public string projectDescription { get; set; }
        public string cultureDescription { get; set; }
        public string DepartmentId1 { get; set; }
        public string DepartmentDescription { get; set; }
        public string CompanyId1 { get; set; }
        public string CompanyDescription { get; set; }
        public string qtdeOS { get; set; }
        /*
        "UserId":"64",
        "Name":"NILTON ASSIS"
        "CultureID":"pt"
        "RegNumber":"01"
        "NetUserId":"NILTONASSIS"
        "emailAddress":"NILTON.ASSIS@OUTOTEC.COM"
        "DepartmentId":"2"
        "ActiveStatus":true
        "LastAccess":""
        "CompanyId":"2"
        "Color":"#C4D4AB"
        "Pwd":"1234"
        "photoFileName":"NILTONASSIS.jpg"
        "idProject":"1"
        "projectDescription":"OUTOTEC - AMG MINERAÇÃO"
        "cultureDescription":"Português"
        "DepartmentId1":"2"
        "DepartmentDescription":"Coordenador"
        "CompanyId1":"2"
        "CompanyDescription":"OTB - EMISSÃO"
        "qtdeOS":"0"
        */
    }
}
