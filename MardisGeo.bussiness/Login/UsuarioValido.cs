using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardisGeo.Data.Query;
using GeoMardis.Model.Login;
using GeoMardis.Model.Admin;
namespace MardisGeo.bussiness.Login
{
  public  class UsuarioValido
    {
        private Data.Query.Usuario qryUsuario = new Data.Query.Usuario();
        public IList<PerfilUsuario> IsUsuario(String Login , String Pass) {

            var usuario = qryUsuario.GetUsertAll(Login,Pass);

            if (usuario.Count() > 0)
            { IList<PerfilUsuario> perfil = new List<PerfilUsuario>();

                perfil.Add(new PerfilUsuario { NombreUsuario= usuario.First().FULL_NAME, Tipo= Int16.Parse( usuario.First().idtpo.ToString() ), Id = Int16.Parse(usuario.First().ID.ToString())});
               
                return perfil;
            }
            else {

                return null;
            }

            
        }
        public IList<TipoUsuario> AllTypeUser()
        {

            var TypeUser = qryUsuario.GetUsertTipoAll();

            if (TypeUser.Count() > 0)
            {
                IList<TipoUsuario> perfil = new List<TipoUsuario>();
                foreach (var item in TypeUser)
                {

                    perfil.Add(new TipoUsuario { id = item.Id, tipo = item.tpo_usr_geo_name });
                }
                return perfil;
            }
            else
            {

                return null;
            }


        }
        public int SaveUser(GeoMardis.Model.Admin.Usuario user)
        {
            IList<GeoMardis.Model.Admin.Usuario> sltuser = new List<GeoMardis.Model.Admin.Usuario>();
            sltuser.Add(user);
            return qryUsuario.InsertUser(sltuser);

        }

        public IList<GeoMardis.Model.Admin.Usuario> AllUser()
        {

            var usuario = qryUsuario.GetUsertAllData();

            if (usuario.Count() > 0)
            {
                IList<GeoMardis.Model.Admin.Usuario> perfil = new List<GeoMardis.Model.Admin.Usuario>();
                foreach (var item in usuario)
                {

                    perfil.Add(new GeoMardis.Model.Admin.Usuario
                    {
                                                id = item.ID,
                                               NombreUsuario = item.FULL_NAME,
                                                LoginUsuario=item.LOGIN,
                                                TipoUsuario= int.Parse(item.idtpo.ToString())
                                             ,FechaUsuario=item.CREATE_DATE.ToString()

                                        });
                }

                return perfil;
            }
            else
            {

                return null;
            }


        }
        public string TypeName(int id)
        {

            var usuario = qryUsuario.TipoUserName(id);

                return usuario;
           


        }
        public int RemoveUser(int id)
        {

            var usuario = qryUsuario.deleteUser(id);

            return usuario;



        }
        public int UpdatePass(String pass , int id)
        {

            var usuario = qryUsuario.UpdatePassUser(pass,id);

            return usuario;



        }
        public GeoMardis.Model.Admin.Usuario GetUserSig(int id)
        {

            return qryUsuario.GetUsers(id);
        }
    }
}
