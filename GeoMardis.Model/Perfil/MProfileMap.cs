using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Perfil
{
 public   class MProfileMap
    {
        public int Id { get; set; }
        public int Idprofile { get; set; }
        public int idmap { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_mod { get; set; }
        public string geo_map_usr { get; set; }
        public string status { get; set; }
    }
}
