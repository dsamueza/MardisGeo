using MardisGeo.Data.@base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMardis.Model.Perfil;
namespace MardisGeo.Data.Query
{
    public class Profile_Repository
    {
        public IList<MProfile> GetProfileAccount(int Idaccount)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var pro = tran.geo_profile.Where(x => x.idaccount == Idaccount).ToList<geo_profile>();

                    IList<MProfile> Profile = new List<MProfile>();
                    foreach (geo_profile x in pro)
                    {
                        Profile.Add(new MProfile
                        {
                            Id = int.Parse(x.Id.ToString()),
                            code = int.Parse(x.code.ToString()),
                            nombre = x.geo_profile_name,
                            fecha_mod = Convert.ToDateTime(x.geo_create_date.ToString()),
                            status = x.geo_profile_status,
                            geo_permit = x.geo_permit,
                            idaccount = int.Parse(x.idaccount.ToString())

                        });
                    }

                    return Profile;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public IList<MProfilePerson> GetProfilePerson(int idperson)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var pro = tran.geo_usr_profile.Where(x => x.iduser == idperson).ToList<geo_usr_profile>();

                    IList<MProfilePerson> Profile = new List<MProfilePerson>();
                    foreach (geo_usr_profile x in pro)

                        Profile.Add(new MProfilePerson
                        {
                            Id = int.Parse(x.Id.ToString()),
                            Idprofile = int.Parse(x.Idprofile.ToString()),
                            iduser = int.Parse(x.iduser.ToString()),
                            descripcion = x.geo_usr_profile_decrip,
                            fecha_mod = Convert.ToDateTime(x.geo_map_create_date.ToString()),
                            status = x.C_status,
                            geo_usr_profile1 = x.geo_usr_profile1


                        });
                    return Profile;
                }



            }


            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }

        public int InsertDeleteProfilePerson(MProfilePerson mperson)
        {



            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    DateTime localDate = DateTime.Now;
                    /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base

                    var profile = tran.geo_usr_profile.Where(x => x.Idprofile == mperson.Idprofile && x.iduser == mperson.iduser).ToList<geo_usr_profile>();

                    if (profile.Count() == 0)
                    {
                        geo_usr_profile user = new geo_usr_profile();
                        var Tuser = tran.Set<geo_usr_profile>();




                        user.geo_map_create_date = localDate;
                        user.geo_map_usr = mperson.geo_map_usr;
                        user.iduser = mperson.iduser;
                        user.Idprofile = mperson.Idprofile;
                        user.C_status = mperson.status;
                        user.geo_usr_profile1 = mperson.geo_usr_profile1;
                        Tuser.Add(user);
                        tran.SaveChanges();
                    }
                    else {
                        int idppu = profile.First().Id;
                        int idppus = int.Parse(profile.First().iduser.ToString());
                        int idppup = int.Parse(profile.First().Idprofile.ToString());
                        var existing = tran.geo_usr_profile.Find(idppu);
                        geo_usr_profile profi = new geo_usr_profile() { Id = idppu, Idprofile = idppup, iduser = idppup };
                        tran.Entry(existing).State = System.Data.Entity.EntityState.Deleted;

                        tran.SaveChanges();

                    }




                }
            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return 0;
            }
            return 0;
        }
        public IList<MProfileMap> GetProfileMap(int idmap)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var pro = tran.geo_map_profile.Where(x => x.idmap == idmap).ToList<geo_map_profile>();

                    IList<MProfileMap> Profile = new List<MProfileMap>();
                    foreach (geo_map_profile x in pro)

                        Profile.Add(new MProfileMap
                        {
                            Id = int.Parse(x.Id.ToString()),
                            Idprofile = int.Parse(x.Idprofile.ToString()),
                            idmap = int.Parse(x.idmap.ToString()),
                            descripcion = x.geo_map_usr_tpo_decrip,
                            fecha_mod = Convert.ToDateTime(x.geo_map_create_date.ToString()),
                            status = x.geo_profile_map_status


                        });
                    return Profile;
                }



            }


            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }

        public IList<MProfileMap> GetProfileDash(int idmap)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var pro = tran.geo_map_profile.Where(x => x.IdDashboard == idmap).ToList<geo_map_profile>();

                    IList<MProfileMap> Profile = new List<MProfileMap>();
                    foreach (geo_map_profile x in pro)

                        Profile.Add(new MProfileMap
                        {
                            Id = int.Parse(x.Id.ToString()),
                            Idprofile = int.Parse(x.Idprofile.ToString()),
                          
                            Iddash = int.Parse(x.IdDashboard.ToString()),
                            descripcion = x.geo_map_usr_tpo_decrip,
                            fecha_mod = Convert.ToDateTime(x.geo_map_create_date.ToString()),
                            status = x.geo_profile_map_status


                        });
                    return Profile;
                }



            }


            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public int InsertDeleteProfileMap(MProfileMap mmap)
        {



            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    DateTime localDate = DateTime.Now;
                    /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base

                    var profile = tran.geo_map_profile.Where(x => x.Idprofile == mmap.Idprofile && x.idmap == mmap.idmap).ToList<geo_map_profile>();

                    if (profile.Count() == 0)
                    {
                        geo_map_profile user = new geo_map_profile();
                        var Tuser = tran.Set<geo_map_profile>();




                        user.geo_map_create_date = localDate;
                        user.geo_map_usr = mmap.geo_map_usr;
                        user.idmap = mmap.idmap;
                        user.Idprofile = mmap.Idprofile;
                        user.geo_profile_map_status = mmap.status;
                        user.geo_map_usr_tpo_decrip = mmap.descripcion;
                        Tuser.Add(user);
                        tran.SaveChanges();
                    }
                    else
                    {
                        int idppu = profile.First().Id;
                        int idppus = int.Parse(profile.First().idmap.ToString());
                        int idppup = int.Parse(profile.First().Idprofile.ToString());
                        var existing = tran.geo_map_profile.Find(idppu);
                        geo_map_profile profi = new geo_map_profile() { Id = idppu, Idprofile = idppup, idmap = idppus };
                        tran.Entry(existing).State = System.Data.Entity.EntityState.Deleted;

                        tran.SaveChanges();

                    }




                }
            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return 0;
            }
            return 0;
        }
        public int InsertDeleteProfileDashboard(MProfileMap mmap)
        {



            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    DateTime localDate = DateTime.Now;
                    /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base

                    var profile = tran.geo_map_profile.Where(x => x.Idprofile == mmap.Idprofile && x.IdDashboard == mmap.Iddash).ToList<geo_map_profile>();

                    if (profile.Count() == 0)
                    {
                        geo_map_profile user = new geo_map_profile();
                        var Tuser = tran.Set<geo_map_profile>();




                        user.geo_map_create_date = localDate;
                        user.geo_map_usr = mmap.geo_map_usr;
                        user.IdDashboard = mmap.Iddash;
                        user.Idprofile = mmap.Idprofile;
                        user.geo_profile_map_status = mmap.status;
                        user.geo_map_usr_tpo_decrip = mmap.descripcion;
                        Tuser.Add(user);
                        tran.SaveChanges();
                    }
                    else
                    {
                        int idppu = profile.First().Id;
                        int idppus = int.Parse(profile.First().IdDashboard.ToString());
                        int idppup = int.Parse(profile.First().Idprofile.ToString());
                        var existing = tran.geo_map_profile.Find(idppu);
                        geo_map_profile profi = new geo_map_profile() { Id = idppu, Idprofile = idppup, IdDashboard = idppus };
                        tran.Entry(existing).State = System.Data.Entity.EntityState.Deleted;

                        tran.SaveChanges();

                    }




                }
            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return 0;
            }
            return 0;
        }
        public IList<geo_profile> GetProfiletAllData()
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    return tran.geo_profile.ToList<geo_profile>();

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null;
            }
        }
        public int deleteProfile(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    geo_profile pro = new geo_profile() { Id = id };
                    tran.geo_profile.Attach(pro);
                    tran.geo_profile.Remove(pro);
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

        public int InsertProfile(IList<MProfile> sltProfile)
        {



            try
            {
                using (var tran = new MardisGEOEntities())
                {
                    string Activo;
                    if (sltProfile.First().Status_Ac)
                    {
                        Activo = "A";
                    }
                    else { Activo = "I"; }
                    DateTime localDate = DateTime.Now;
                    if (sltProfile.First().Id == 0)
                    {

                        /// Se debe sacar el secuencial de la tabla porque no existe identity en la tabla base
                        var Secuencial = tran.USER_GEO.ToList<USER_GEO>().Last().ID + 1;
                        geo_profile perfil = new geo_profile();
                        var Tuser = tran.Set<geo_profile>();

                        perfil.idaccount = sltProfile.First().idaccount;
                        perfil.geo_profile_name = sltProfile.First().nombre;
                        perfil.geo_profile_status = Activo;
                        perfil.code = sltProfile.First().code;
                        perfil.geo_create_date = localDate;
                        perfil.geo_create_usr = sltProfile.First().usuario;
                        Tuser.Add(perfil);
                        tran.SaveChanges();
                    }
                    else
                    {
                        int id = sltProfile.First().Id;
                        geo_profile perfil = tran.geo_profile.Where(y => y.Id == id).FirstOrDefault<geo_profile>();
                        var Tuser = tran.Set<geo_profile>();
                   

                        perfil.idaccount = sltProfile.First().idaccount;
                        perfil.geo_profile_name = sltProfile.First().nombre;
                        perfil.geo_profile_status = Activo;
                        perfil.code = sltProfile.First().code;
                        perfil.geo_create_date = localDate;
                        perfil.geo_create_usr = sltProfile.First().usuario;
                        tran.Entry(perfil).State = System.Data.Entity.EntityState.Modified;
                        tran.SaveChanges();



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
        public MProfile GetProfiles(int id)
        {

            try
            {
                using (var tran = new MardisGEOEntities())
                {

                    var profile = tran.geo_profile.Where(z => z.Id == id).ToList<geo_profile>().First();

                    var MProfiles = new MProfile
                    {
                        Id = profile.Id,
                        nombre = profile.geo_profile_name,
                        code = int.Parse(profile.code.ToString()),
                        idaccount = int.Parse(profile.idaccount.ToString())
                        , status = profile.geo_profile_status,
                        FechaUsuario = profile.geo_create_date.ToString()

                    };
                    return MProfiles;

                }

            }
            catch (Exception ex)
            {
                string error;
                error = ex.ToString();
                return null ;
            }
           

        }

   
}
}
