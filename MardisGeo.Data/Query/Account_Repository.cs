using MardisGeo.Data.@base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Cuenta;
namespace MardisGeo.Data.Query
{
  public  class Account_Repository
    {
        public IList<MAccount> GetAllAccount()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

        var acc = tran.geo_map_account.ToList<geo_map_account>();
            
                    IList<MAccount> account = new List<MAccount>();
                    foreach (geo_map_account x in acc) {
                        account.Add(new MAccount {
                            Id = int.Parse(x.Id.ToString()),
                            code = int.Parse(x.code.ToString()),
                            Nombre = x.geo_map_account_name,
                            fecha_mod = Convert.ToDateTime(x.geo_map_create_date.ToString()),
                            geo_map_usr = x.geo_map_usr
                        });
                    }
                   
                    return account;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
    }
}
