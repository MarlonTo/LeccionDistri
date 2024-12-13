using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP.conf
{
    public class Task1
    {
        public int TareaID { get; set; }
        public int ProyectoID { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaLimite { get; set; }
    }
}