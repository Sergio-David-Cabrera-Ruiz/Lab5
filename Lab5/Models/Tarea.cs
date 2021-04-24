using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    public class Tarea : TareaStruct
    {
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Proyecto")]
        public string Proyecto { get; set; }

        [Display(Name = "FechaEntrega")]
        public string FechaEntrega { get; set; }
        [Display(Name ="DescripcionProyecto")]
        public string DescripcionProyecto { get; set; }
    }
}