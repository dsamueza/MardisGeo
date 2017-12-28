using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Categorias
{

     
    
    public partial class geo_categoria
    {
        public geo_categoria()
        {
            this.geo_foto = new HashSet<geo_foto>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string status_cat { get; set; }

     
        public virtual ICollection<geo_foto> geo_foto { get; set; }
    }
}

