using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosBLL.Dto
{
    public partial class UsuarioDto
    {
        [Display(Name = "Id")]
        public int IdUsuario { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime FechaNacimento { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
    }
}
