using MardisGeo.Data.@base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Mapa;
using System.Collections;

namespace MardisGeo.Data.Query
{
   public class QryMapa
    {
        public IList<ModelMap> GetMapasUsuario(int idUsuario)
        {

            try
            {
        //           public int Id { get; set; }
        //public string geo_map_name { get; set; }
        //public string geo_map_descrip { get; set; }
        //public string geo_map_status { get; set; }

        //public string geo_map_link { get; set; }
        //public int Idprofile { get; set; }
        //public string nameprofile { get; set; }
        //public int iduser { get; set; }
                using (var tran = new MardisGEOEntities())
                {
                    IList<ModelMap> sltmap = new List<ModelMap>();
                    var map = (from user in tran.USER_GEO
                               join pu in tran.geo_usr_profile on user.ID equals pu.iduser
                               join p in tran.geo_profile on pu.Idprofile equals p.Id
                               join pm in tran.geo_map_profile on p.Id equals pm.Idprofile
                               join m in tran.geo_map on pm.idmap equals m.Id
                               where user.ID == idUsuario
                               select new
                               {
                                   Id = m.Id,
                                   geo_map_name = m.geo_map_name,
                                   geo_map_descrip = m.geo_map_descrip,
                                   geo_map_status = m.geo_map_status,
                                   geo_map_link = m.geo_map_link,
                                   Idprofile = p.Id,
                                   nameprofile = p.geo_profile_name,
                                   iduser = user.ID
                               }).ToList();

                    foreach ( var item in map)
                    {
                        sltmap.Add(new ModelMap
                        {
                            Id = item.Id.ToString(),
                            geo_map_name = item.geo_map_name,
                            geo_map_descrip = item.geo_map_descrip,
                            geo_map_status = item.geo_map_status,
                            geo_map_link = item.geo_map_link,
                            Idprofile=item.Idprofile.ToString(),
                            nameprofile = item.nameprofile,
                            iduser = item.iduser.ToString()
                        });

                    }
                   
                    return sltmap;
                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }

        public int InsertMap(GeoMardis.Model.Admin.ModelMap sltMap)
        {



            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    string Activo ;
                    if (sltMap.Status) {
                        Activo = "A";
                    }
                    else { Activo = "I"; }
                    DateTime localDate = DateTime.Now;
                    /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base
                    if (sltMap.id == 0)
                    {
                        geo_map map = new geo_map();
                        var Tuser = tran.Set<geo_map>();



                        map.geo_map_status = Activo;
                        map.geo_map_descrip = sltMap.Description;
                        map.geo_map_link = sltMap.Link;
                        map.geo_map_name = sltMap.Name;
                        map.geo_map_create_date = localDate;
                        map.geo_map_usr = sltMap.Usuario;
                        Tuser.Add(map);
                        tran.SaveChanges();
                    }
                    else {
                        geo_map map = tran.geo_map.Where(y => y.Id == sltMap.id).FirstOrDefault<geo_map>();
                        var Tuser = tran.Set<geo_map>();


                        map.Id = sltMap.id;
                        map.geo_map_status = Activo;
                        map.geo_map_descrip = sltMap.Description;
                        map.geo_map_link = sltMap.Link;
                        map.geo_map_name = sltMap.Name;
                        map.geo_map_create_date = localDate;
                        map.geo_map_usr = sltMap.Usuario;
                        tran.Entry(map).State = System.Data.Entity.EntityState.Modified;
                        tran.SaveChanges();

                    }
                    return 1;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return 0;
            }
            return 0;
        }

        public IList<geo_map> GetMaptAllData()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.geo_map.ToList<geo_map>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }

        public int deleteMaps(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    geo_map map = new geo_map() { Id = id };
                    tran.geo_map.Attach(map);
                    tran.geo_map.Remove(map);
                    tran.SaveChanges();
                    return 1;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return 0;
            }
        }

        public GeoMardis.Model.Admin.ModelMap GetMaps(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {
                   
                  var maps=  tran.geo_map.Where(z => z.Id == id).ToList<geo_map>().First();

                    GeoMardis.Model.Admin.ModelMap mMapas = new GeoMardis.Model.Admin.ModelMap
                    {
                        id = maps.Id,
                        Name = maps.geo_map_name,
                        Description = maps.geo_map_descrip,
                        Link = maps.geo_map_link
                         , FechaUsuario = maps.geo_map_create_date.ToString()
                         , Status = Status(maps.geo_map_status)
                    };
                    return mMapas;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public bool Status(string s) {

            if (s.Equals("A "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
