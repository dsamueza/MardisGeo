using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Admin
{
   public class UE
    {

        public string meta_instanceID { get; set; }
        public string Codigo { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Coordenadas { get; set; }
        public string Parroquia { get; set; }
        public string Zona { get; set; }
        public string Dirección { get; set; }
        public string Imagen { get; set; }
        public string Nombre_de_la_obra { get; set; }
        public string Tipo_Obra { get; set; }
        public string Categoria { get; set; }
        public string Esctructura { get; set; }
        public double Tamano_Obra_m2 { get; set; }
        public double  Hormigon_total_m3 { get; set; }
        public double Porcentaje_Avance { get; set; }
        public double Hormigon_por_ejecutar_m3 { get; set; }
        public string Tipo_mezcla { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_finalizacion { get; set; }
        public string Constructora { get; set; }
        public string marcas_cemento { get; set; }
        public string hormigonera__Hormigon_premezclado_ { get; set; }
        public string proveedor__sacos_ { get; set; }
        public string Tipo_de_Responsable { get; set; }
        public string Responsable { get; set; }
        public string Nombre { get; set; }
        public string celular { get; set; }
        public int ID { get; set; }
    }
}
