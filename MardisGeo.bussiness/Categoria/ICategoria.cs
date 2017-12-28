using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.Query;
using MardisGeo.Data.@base;

namespace MardisGeo.bussiness.Categoria
{
  public class ICategoria
    {
        private Categoria_repository qryCategoria = new Categoria_repository();

        public IList<geo_categoria> CategoriasActivas() {

            return qryCategoria.GetCategoriaAll().Where(x=>x.status_cat=="A").ToList<geo_categoria>() ;

        }
    }
}
