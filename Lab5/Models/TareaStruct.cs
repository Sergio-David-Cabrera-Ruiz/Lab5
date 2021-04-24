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
        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }


        //Comparaciones
        public int CompareTo(object obj)
        {
            return this.Titulo.CompareTo(((TareaStruct)obj).Titulo);
        }
        public static Comparison<TareaStruct> CompararPorTitulo = delegate (TareaStruct tarea1, TareaStruct tarea2)
        {
            return tarea1.Titulo.CompareTo(tarea2.Titulo);
        };
    }
}