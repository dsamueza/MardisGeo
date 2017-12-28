using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Login
{
    public class login
    {
        [DisplayName("Nombre de usuario o dirección de correo electrónico")]
        public String NombreUsuario { get; set; }
        [DisplayName("Contraseña")]
        public String PassUsuario { get; set; }

    }
}
