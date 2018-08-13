using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.@base;

namespace MardisGeo.Data.Query
{
  public  class Categoria_repository
    {

        public IList<geo_categoria> GetCategoriaAll()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.geo_categoria.ToList<geo_categoria>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }

        public IList<censo_obras> GetUE()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var all = tran.censo_obras;
                    return all.ToList<censo_obras>();
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
