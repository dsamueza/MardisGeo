using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Cuenta
{
  public  class MAccount
    {
        public int Id { get; set; }
        public int  code { get; set; }
        public string Nombre{ get; set; }
        public DateTime fecha_mod{ get; set; }
        public string geo_map_usr { get; set; }
    }
}
