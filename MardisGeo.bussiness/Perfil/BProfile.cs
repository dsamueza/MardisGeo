using MardisGeo.Data.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Perfil;
namespace MardisGeo.bussiness.Perfil
{
   public class BProfile
    {
      
            private Profile_Repository profile = new Profile_Repository();
            public IList<MProfile> GetPerfilAccount(int Idaccount)
            {

            return profile.GetProfileAccount(Idaccount);
            }

        public IList<MProfilePerson> GetPerfilPerson(int idpeson )
        {

            return profile.GetProfilePerson(idpeson);
        }

        public int AddRemovePerfilPerson(MProfilePerson pp)
        {

            return profile.InsertDeleteProfilePerson(pp);
        }


        public IList<MProfileMap> GetPerfilMap(int idpeson)
        {

            return profile.GetProfileMap(idpeson);
        }

        public int AddRemovePerfilMap(MProfileMap pp)
        {

            return profile.InsertDeleteProfileMap(pp);
        }
        public IList<MProfile> GetPerfilAccountMap(int Idaccount)
        {

            return profile.GetProfileAccount(Idaccount);
        }

        public IList<MProfile> AllProfile()
        {

            var usuario = profile.GetProfiletAllData();

            if (usuario.Count() > 0)
            {
                IList<MProfile> perfil = new List<MProfile>();
                foreach (var item in usuario)
                {

                    perfil.Add(new MProfile
                    {
                        Id = item.Id,
                        code = int.Parse( item.code.ToString()),
                        nombre = item.geo_profile_name,
                        idaccount = int.Parse(item.idaccount.ToString()),
                        status = status(item.geo_profile_status),

                        FechaUsuario = item.geo_create_date.ToString()

                    });
                }

                return perfil;
            }
            else
            {

                return null;
            }
     


        }
        public string status(string s)
        {
            if (s.Equals("A "))
            {
                return "Activo";
            }
            else
            {
                return "Inactivo";
            }

        }
        public int RemoveProfile(int id)
        {

            return profile.deleteProfile(id);
        }
        public int SaveProfile(MProfile Profile)
        {
            IList<MProfile> sltProfile = new List<MProfile>();
            sltProfile.Add(Profile);
            return profile.InsertProfile(sltProfile);

        }
        public MProfile GetPerfilSig(int id)
        {

            var perfil = profile.GetProfiles(id);
            if (perfil.status == "A ") {
                perfil.Status_Ac = true;
            }
            else
            {
                perfil.Status_Ac = false;

            }
            
            return perfil;
        }


    }

}

