using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Estructuras
{
    public class HashNodo<T> where T : IComparable
    {
        public HashNodo<T> Previo { get; set; }
        public HashNodo<T> Prox { get; set; }
        public T Valor { get; set; }
        public string Llave { get; set; }
    }
}