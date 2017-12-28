using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.@base;
using MardisGeo.Data.Query;
namespace MardisGeo.bussiness.Geo
{
   public  class Geofoto
    {
        private Geo_Repository foto = new Geo_Repository();
        public IList<geo_foto> Getfoto(int idCategoria) {
            var fotos = foto.GetfotoCategoria(idCategoria);
            if (fotos.Count() > 0) {
                return fotos;
            }
            return null ;
        }
    }
}
