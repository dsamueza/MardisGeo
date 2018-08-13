using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.@base;
using GeoMardis.Model.Admin;
namespace MardisGeo.Data.Query
{
public  class Usuario
    {

        public string  TipoUserName(int ids)
        {
            string nombre = "";

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    nombre = tran.tpo_usr_geo.Where(x => x.Id == ids).ToList<tpo_usr_geo>().First().tpo_usr_geo_name;
                    return nombre;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return "";


            }
        }
        public IList<USER_GEO> GetUsertAll(String Login, String Pass)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.USER_GEO.Where(x => x.LOGIN==Login && x.PASSWORD==Pass).ToList<USER_GEO>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public IList<USER_GEO> GetUsertAllData()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.USER_GEO.ToList<USER_GEO>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public IList<tpo_usr_geo> GetUsertTipoAll()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.tpo_usr_geo.ToList<tpo_usr_geo>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public int deleteUser(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    USER_GEO user = new USER_GEO() { ID = id };
                    tran.USER_GEO.Attach(user);
                    tran.USER_GEO.Remove(user);
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

        public int UpdatePassUser(string pass ,int ids)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    int id = ids;
                    var localDate = DateTime.Now;
                    var u1 = tran.USER_GEO.Where(z => z.ID == id).ToList<USER_GEO>().First();
                    // var u= tran.USER_GEO.Where(y => y.ID == sltUser.First().id).ToList<USER_GEO>();
                    USER_GEO users = u1;                  
                    users.PASSWORD = pass;
                    users.CREATE_DATE = localDate;
                    tran.Entry(users).State = System.Data.Entity.EntityState.Modified; ;
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

        public int InsertUser(IList<GeoMardis.Model.Admin.Usuario> sltUser) {



            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    DateTime localDate = DateTime.Now;
                    if (sltUser.First().id == 0)
                    {
                        
                        /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base
                        var Secuencial = tran.USER_GEO.ToList<USER_GEO>().Last().ID + 1;
                        USER_GEO user = new USER_GEO();
                        var Tuser = tran.Set<USER_GEO>();
                        user.ID = Secuencial;
                        user.idtpo = sltUser.First().TipoUsuario;
                        user.LOGIN = sltUser.First().LoginUsuario;
                        user.FULL_NAME = sltUser.First().NombreUsuario;
                        user.PASSWORD = sltUser.First().PassUsuario;
                        user.CREATE_DATE = localDate;
                        Tuser.Add(user);
                        tran.SaveChanges();
                    }
                    else {
                        UpdateUser(sltUser);



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
      
        }

        public int UpdateUser(IList<GeoMardis.Model.Admin.Usuario> sltUser) {
            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    int id = sltUser.First().id;
                   var localDate = DateTime.Now;
                    var u1 = tran.USER_GEO.Where(z => z.ID == id).ToList<USER_GEO>().First();
                    // var u= tran.USER_GEO.Where(y => y.ID == sltUser.First().id).ToList<USER_GEO>();
                    USER_GEO users = u1;




             
                    users.idtpo = sltUser.First().TipoUsuario;
                    users.LOGIN = sltUser.First().LoginUsuario;
                    users.FULL_NAME = sltUser.First().NombreUsuario;
                    users.PASSWORD = sltUser.First().PassUsuario;
                    users.CREATE_DATE = localDate;
                    tran.Entry(users).State = System.Data.Entity.EntityState.Modified; ;
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
        public GeoMardis.Model.Admin.Usuario GetUsers(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var users = tran.USER_GEO.Where(z => z.ID == id).ToList<USER_GEO>().First();

                    GeoMardis.Model.Admin.Usuario mUsers = new GeoMardis.Model.Admin.Usuario
                    {
                        id = users.ID,
                        NombreUsuario = users.FULL_NAME,
                        LoginUsuario = users.LOGIN,
                        TipoUsuario = int.Parse( users.idtpo.ToString())
                         ,
                        FechaUsuario = users.CREATE_DATE.ToString()
                      
                    };
                    return mUsers;

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
