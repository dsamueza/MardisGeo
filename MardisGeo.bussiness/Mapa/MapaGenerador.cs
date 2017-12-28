using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Mapa;
using MardisGeo.Data.Query;
using MardisGeo.Data.@base;
namespace MardisGeo.bussiness.Mapa
{
   public class MapaGenerador
    {
        private QryMapa map = new QryMapa();
        public IList<ModelMap> GetMap(int CodigoUsuario) {
            IList<ModelMap> sltmap = new List<ModelMap>();
            var maps = map.GetMapasUsuario(CodigoUsuario);
            //foreach (geo_map item in maps)
            //{
            //    sltmap.Add(new ModelMap {
            //        Id = item.Id,
            //        geo_map_name = item.geo_map_name,
            //        geo_map_descrip = item.geo_map_descrip,
            //        geo_map_status=item.geo_map_status,
            //        geo_map_link=item.geo_map_link
            //    });

            //}
            return maps;
        }  
    }
}
