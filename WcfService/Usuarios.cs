using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaNacimento { get; set; }
        public string Sexo { get; set; }
    }
}