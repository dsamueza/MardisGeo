using MardisGeo.Data.@base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardisGeo.Data.Query
{
 public class Geo_Repository
    {
        public IList<geo_foto> GetfotoCategoria(int idCategoria)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                 var varfoto=tran.geo_foto.ToList<geo_foto>().Where(x => x.id_geo_cat.Equals(idCategoria));

                    return varfoto.ToList<geo_foto>();
                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public int SaveGEO(geo_ubicacion ModeloGEOUbicacion ,  string url)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    using (var tranbegin = tran.Database.BeginTransaction())
                    {
                        try
                        {
                            var geoUbicacion = tran.Set<geo_ubicacion>();
                            geoUbicacion.Add(ModeloGEOUbicacion);
                            var sucess = tran.SaveChanges();


                            var result = tran.Set<geo_secuencial>().SingleOrDefault(b => b.number_sec == ModeloGEOUbicacion.id_sec);
                            if (result != null)
                            {
                                var varfoto = tran.geo_ubicacion.ToList<geo_ubicacion>().Where(x => x.id_sec.Equals(ModeloGEOUbicacion.id_sec));
                                result.id_geo_ubi = varfoto.First().id;
                                tran.SaveChanges();
                            }

                                var resultimag = tran.Set<geo_ubicacion>().SingleOrDefault(b => b.id_sec == ModeloGEOUbicacion.id_sec);
                                var geoUbicacionimg = tran.Set<geo_img_ubicacion>();
                                geo_img_ubicacion modelImg = new geo_img_ubicacion();
                                modelImg.id_geo_ubi = resultimag.id;
                                modelImg.name = resultimag.id_sec.ToString();
                                modelImg.url_img = url;
                             
                                modelImg.create_date = resultimag.create_date;
                                modelImg.create_usr = resultimag.create_usr;
                                
                                geoUbicacionimg.Add(modelImg);
                           
                            sucess = tran.SaveChanges();
                            tranbegin.Commit();
                            return sucess;
                        }
                        catch (Exception )
                        {
                            tranbegin.Rollback();

                            return 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                string error;
                error = ex.ToString();
             
                return 0;
            }
        }
    }
}
