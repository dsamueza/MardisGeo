﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMardis.Model.Admin
{
    public class ModelMap
    {


        [DisplayName("ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar Nombre del Mapa")]
        [DisplayName("Nombre de Mapa")]
        public String Name { get; set; }
 
        [DisplayName("Descripcion")]
        public String Description { get; set; }
        [DisplayName("Estado")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "El url es requerida")]

        [DisplayName("Url")]
        public String Link { get; set; }
        [DisplayName("Fecha")]
        public string FechaUsuario { get; set; }
        public string Usuario { get; set; }
        public string estado { get; set; }
    }
}
