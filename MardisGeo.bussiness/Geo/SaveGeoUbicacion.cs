using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.Query;

using MardisGeo.Data.@base;
namespace MardisGeo.bussiness.Geo
{
   public class SaveGeoUbicacion
    {
        private Geo_Repository GeoImagen = new Geo_Repository();
        public int Save(string geo_ubu_des, int id_img , int id_sec , DateTime create_date, string create_usr, string url)
        {

            geo_ubicacion datageo = new geo_ubicacion();
            datageo.geo_ubu_des = geo_ubu_des;
            datageo.id_img = id_img;
            datageo.id_sec = id_sec;
            datageo.create_date = create_date;
            datageo.create_usr = create_usr;

            GeoImagen.SaveGEO(datageo,  url);
            return 1;
        }
    }
}
