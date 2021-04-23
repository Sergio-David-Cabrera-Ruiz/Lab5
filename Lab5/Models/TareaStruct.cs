using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class TareaStruct : IComparable
    {
        //Declaracion de variables
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Proyecto")]
        public string Proyecto { get; set; }
        public int Prioridad { get; set; }
        [Display(Name = "FechaEntrega")]
        public string FechaEntrega { get; set; }


        //Comparaciones
        public int CompareTo(object obj)
        {
            return this.Titulo.CompareTo(((TareaStruct)obj).Titulo);
        }
        public static Comparison<TareaStruct> CompararPorTitulo = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Titulo.CompareTo(tarea2.Titulo);
        };
        public static Comparison<TareaStruct> CompararPorDescripcion = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Descripcion.CompareTo(tarea2.Descripcion);
        };
        public static Comparison<TareaStruct> CompararPorProyecto = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Proyecto.CompareTo(tarea2.Proyecto);
        };
        public static Comparison<TareaStruct> CompararPorPrioridad = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Prioridad.CompareTo(tarea2.Prioridad);
        };
        public static Comparison<TareaStruct> CompararPorFechaEntrega = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Titulo.CompareTo(tarea2.FechaEntrega);
        };
    }
}