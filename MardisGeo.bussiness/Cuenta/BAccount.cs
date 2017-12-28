using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Cuenta;
using MardisGeo.Data.Query;
namespace MardisGeo.bussiness.Cuenta
{
  public  class BAccount
    {
        private Account_Repository account = new Account_Repository();
        public IList<MAccount> GetAccount() {

            return account.GetAllAccount();
        }
    }
}
