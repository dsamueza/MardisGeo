using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Admin
{
   public class Usuario
    {


        [DisplayName("ID")]
        public int id { get; set; }
    
        [Required(ErrorMessage = "Debe ingresar Nombre de Usuario")]
        [DisplayName("Nombre de usuario")]
        public String NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar Login de Usuario")]
        [DisplayName("Login de usuario")]
        public String LoginUsuario { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener al menos 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public String PassUsuario { get; set; }
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener al menos 5 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("PassUsuario")]
        [DisplayName("Repita la Contraseña")]
        public String PassUsuarionew { get; set; }
        [DisplayName("Tipo de Usuario")]
        public int TipoUsuario { get; set; }
            [DisplayName("Fecha")]
          public string FechaUsuario { get; set; }
    }
}
