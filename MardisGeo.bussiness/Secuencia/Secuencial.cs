using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.Query;
namespace MardisGeo.bussiness.Secuencia
{
   
   public class Secuencial
    {
        private Secuencial_Repository secuencial = new Secuencial_Repository();
        public int NumberSecuencial()
        {
            
            return secuencial.GetSecuencial();
        }
    }
}
