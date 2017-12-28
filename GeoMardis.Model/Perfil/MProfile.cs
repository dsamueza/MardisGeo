using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Perfil
{
   public class MProfile
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre de Usuario")]
        [DisplayName("Codigo de Perfil")]
        public int code { get; set; }
        [DisplayName("Cuenta")]
        public int idaccount { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre de Usuario")]
        [DisplayName("Nombre de Perfil")]
        public string nombre { get; set; }

        public DateTime fecha_mod  { get; set; }

    [DisplayName("Estado")]
        public bool Status_Ac { get; set; }
        public string status { get; set; }
        public string geo_permit { get; set; }

        public string  FechaUsuario { get; set; }

        public string usuario { get; set; }
    }
}
