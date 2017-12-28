using MardisGeo.Data.@base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MardisGeo.Data.Query
{
    public class Secuencial_Repository
    {
        public int GetSecuencial()
        {
            DateTime localDate = DateTime.Now;
            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var novedad = tran.Set<geo_secuencial>();
                    novedad.Add(new geo_secuencial { sec = 100 , create_date= localDate });
                    tran.SaveChanges();
                    var id = tran.geo_secuencial.ToList<geo_secuencial>().Last().id;
                    var result = tran.Set<geo_secuencial>().SingleOrDefault(b => b.id == id);
                    if (result != null)
                    {
                        result.number_sec =(result.id+result.sec) ;
                        tran.SaveChanges();
                    }
                     var numberSec = tran.geo_secuencial.ToList<geo_secuencial>().Last().number_sec;
                    return Convert.ToInt32(numberSec);
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
