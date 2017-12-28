using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Admin;
using MardisGeo.Data.Query;
namespace MardisGeo.bussiness.Mapa
{
    public class BMapas
    {
        private QryMapa map = new QryMapa();
        public int SaveMap(ModelMap maps) {

            
            return map.InsertMap(maps);
        }
        public IList<ModelMap> AllMap()
        {

            var usuario = map.GetMaptAllData();

            if (usuario.Count() > 0)
            {
                IList<ModelMap> perfil = new List<ModelMap>();
                foreach (var item in usuario)
                {

                    perfil.Add(new ModelMap
                    {
                        id = item.Id,
                        Description = item.geo_map_descrip,
                        Name = item.geo_map_name,
                        Link = item.geo_map_link,
                        estado= status(item.geo_map_status),
                                             
                        FechaUsuario = item.geo_map_create_date.ToString()

                    });
                }

                return perfil;
            }
            else
            {

                return null;
            }


        }
        public int RemoveMap(int id) {

            return map.deleteMaps(id);
        }

        public ModelMap GetMapSig (int id)
        {

            return map.GetMaps(id);
        }

        public string status(string s) {
            if (s.Equals("A "))
            {
                return "Activo";
            }
            else {
                return "Inactivo";
            }

        }
    }

}
