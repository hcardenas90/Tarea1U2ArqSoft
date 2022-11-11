using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Usuarios.Models
{
    public class UsuarioDto
    {
        [Display(Name ="Id")]
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public Nullable<System.DateTime> FechaNacimento { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
    }
}