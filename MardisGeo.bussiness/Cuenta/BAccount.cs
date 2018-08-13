using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Cuenta;
using MardisGeo.Data.Query;
using MardisGeo.Data.@base;
using AutoMapper;
using GeoMardis.Model.Admin;

namespace MardisGeo.bussiness.Cuenta
{
  public  class BAccount
    {
        private Account_Repository account = new Account_Repository();
        private Categoria_repository _UEDAO = new Categoria_repository();
        public IList<MAccount> GetAccount() {

            return account.GetAllAccount();
        }


        public IList<UE> GetUE()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UE, censo_obras>();
            });
            var itemResult = new List<UE>();
            var itemResults = _UEDAO.GetUE();
            itemResult = Mapper.Map<List<UE>>(itemResults);
           
            return itemResult;
        }
    }
}
