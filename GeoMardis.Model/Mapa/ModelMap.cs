using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Mapa
{
  public  class ModelMap
    {
        public string Id { get; set; }
        public string geo_map_name { get; set; }
        public string geo_map_descrip { get; set; }
        public string geo_map_status { get; set; }
    
        public string geo_map_link { get; set; }
        public string Idprofile { get; set; }
        public string nameprofile { get; set; }
        public string iduser { get; set; }
    }
}
