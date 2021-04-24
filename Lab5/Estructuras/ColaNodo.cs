using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Lab5.Estructuras
{
    public class ColaNodo<T> : ICloneable
    {
        public ColaNodo<T> Padre;
        public ColaNodo<T> HijoDerecho;
        public ColaNodo<T> HijoIzquierdo;
        public T Tarea;
        public string Llave;
        public int Prioridad;
        public DateTime FechaFinal;
        public ColaNodo(string llave, DateTime fecha, T tarea, int prioridad)
        {
            Llave = llave;
            FechaFinal = fecha;
            Tarea = tarea;
            Prioridad = prioridad;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}