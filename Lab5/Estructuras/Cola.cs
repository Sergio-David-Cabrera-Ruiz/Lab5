using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Estructuras
{
    public class Cola<T> : ICloneable, IEnumerable<T>
    {
        public ColaNodo<T> Raiz;
        public int NumeroTarea;
        public Cola<T> copiaCola;

        public Cola()
        {
            NumeroTarea = 0;
        }
        public bool Vacio()
        {
            return Raiz == null ? true : false;
        }
        public bool Lleno()
        {
            return NumeroTarea == 10 ? true : false;
        }
        public void añadirTarea(string llave, DateTime fecha, T tarea, int prioridad)
        {
            var nuevoNodo = new ColaNodo<T>(llave, fecha, tarea, prioridad);
            if (Vacio())
            {
                Raiz = nuevoNodo;
                NumeroTarea = 1;
            }
            else
            {
                NumeroTarea++;
                var nuevoNodoPadre = BuscarUltimoNodo(Raiz, 1);
                if (nuevoNodoPadre.HijoIzquierdo != null)
                {
                    nuevoNodoPadre.HijoDerecho = nuevoNodo;
                    nuevoNodo.Padre = nuevoNodoPadre;
                    OrdenarAbajoHaciaArriba(nuevoNodo);
                }
                else
                {
                    nuevoNodoPadre.HijoIzquierdo = nuevoNodo;
                    nuevoNodo.Padre = nuevoNodoPadre;
                    OrdenarAbajoHaciaArriba(nuevoNodo);
                }

            }
        }

        private void OrdenarAbajoHaciaArriba(ColaNodo<T> actual)
        {
            if (actual.Padre != null)
            {
                if (actual.Prioridad < actual.Padre.Prioridad)
                {
                    CambiarNodos(actual);
                }
                else if (actual.Prioridad == actual.Padre.Prioridad)
                {
                    if (actual.FechaFinal < actual.Padre.FechaFinal)
                    {
                        CambiarNodos(actual);
                    }
                }
                OrdenarAbajoHaciaArriba(actual.Padre);
            }
        }

        private void OrdenarArribaHaciaAbajo(ColaNodo<T> actual)
        {
            if (actual.HijoDerecho != null && actual.HijoIzquierdo != null)
            {
                if (actual.HijoIzquierdo.Prioridad > actual.HijoDerecho.Prioridad)
                {
                    if (actual.Prioridad > actual.HijoDerecho.Prioridad)
                    {
                        CambiarNodos(actual.HijoDerecho);
                        OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                    }
                    else if (actual.Prioridad == actual.HijoDerecho.Prioridad)
                    {
                        if (actual.FechaFinal > actual.HijoDerecho.FechaFinal)
                        {
                            CambiarNodos(actual.HijoDerecho);
                            OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                        }
                    }
                }
                else if (actual.HijoIzquierdo.Prioridad < actual.HijoDerecho.Prioridad)
                {
                    if (actual.Prioridad > actual.HijoIzquierdo.Prioridad)
                    {
                        CambiarNodos(actual.HijoIzquierdo);
                        OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                    }
                    else if (actual.Prioridad == actual.HijoIzquierdo.Prioridad)
                    {
                        if (actual.FechaFinal > actual.HijoIzquierdo.FechaFinal)
                        {
                            CambiarNodos(actual.HijoIzquierdo);
                            OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                        }
                    }
                }
                else
                {
                    if (actual.HijoIzquierdo.FechaFinal > actual.HijoDerecho.FechaFinal)
                    {
                        if (actual.Prioridad > actual.HijoDerecho.Prioridad)
                        {
                            CambiarNodos(actual.HijoDerecho);
                            OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                        }
                        else if (actual.Prioridad == actual.HijoDerecho.Prioridad)
                        {
                            if (actual.FechaFinal > actual.HijoDerecho.FechaFinal)
                            {
                                CambiarNodos(actual.HijoDerecho);
                                OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                            }
                        }
                    }
                    else
                    {
                        if (actual.Prioridad > actual.HijoIzquierdo.Prioridad)
                        {
                            CambiarNodos(actual.HijoIzquierdo);
                            OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                        }
                        else if (actual.Prioridad == actual.HijoIzquierdo.Prioridad)
                        {
                            if (actual.FechaFinal > actual.HijoIzquierdo.FechaFinal)
                            {
                                CambiarNodos(actual.HijoIzquierdo);
                                OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                            }
                        }
                    }
                }
            }
            else if (actual.HijoDerecho != null)
            {
                if (actual.Prioridad > actual.HijoDerecho.Prioridad)
                {
                    CambiarNodos(actual.HijoDerecho);
                    OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                }
                else if (actual.Prioridad == actual.HijoDerecho.Prioridad)
                {
                    if (actual.FechaFinal > actual.HijoDerecho.FechaFinal)
                    {
                        CambiarNodos(actual.HijoDerecho);
                        OrdenarArribaHaciaAbajo(actual.HijoDerecho);
                    }
                }
            }
            else if (actual.HijoIzquierdo != null)
            {
                if (actual.Prioridad > actual.HijoIzquierdo.Prioridad)
                {
                    CambiarNodos(actual.HijoIzquierdo);
                    OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                }
                else if (actual.Prioridad == actual.HijoIzquierdo.Prioridad)
                {
                    if (actual.FechaFinal > actual.HijoIzquierdo.FechaFinal)
                    {
                        CambiarNodos(actual.HijoIzquierdo);
                        OrdenarArribaHaciaAbajo(actual.HijoIzquierdo);
                    }
                }
            }
        }

        private void CambiarNodos(ColaNodo<T> node)
        {
            var Prioridad1 = node.Prioridad;
            var Llave1 = node.Llave;
            var Fecha1 = node.FechaFinal;
            var Tarea = node.Tarea;
            node.Prioridad = node.Padre.Prioridad;
            node.Llave = node.Padre.Llave;
            node.FechaFinal = node.Padre.FechaFinal;
            node.Tarea = node.Padre.Tarea;
            node.Padre.Prioridad = Prioridad1;
            node.Padre.Llave = Llave1;
            node.Padre.FechaFinal = Fecha1;
            node.Padre.Tarea = Tarea;

        }
        /// <summary>
        /// Remove the first node from the Priority Queue.
        /// </summary>
        /// <returns></returns>
        public ColaNodo<T> ObtenerPrimero()
        {
            if (Raiz == null)
            {
                return null;
            }
            ColaNodo<T> UltimoNodo = BuscarUltimoNodo(Raiz, 1);
            ColaNodo<T> PrimerNodo = (ColaNodo<T>)Raiz.Clone();
            var CopiaUltimoNodo = (ColaNodo<T>)UltimoNodo.Clone();
            Raiz.Llave = CopiaUltimoNodo.Llave;
            Raiz.Prioridad = CopiaUltimoNodo.Prioridad;
            Raiz.Tarea = CopiaUltimoNodo.Tarea;
            Raiz.FechaFinal = CopiaUltimoNodo.FechaFinal;
            if (UltimoNodo.Padre == null)
            {
                Raiz = null;
                NumeroTarea--;
                return UltimoNodo;
            }
            else
            {
                if (UltimoNodo.Padre.HijoIzquierdo == UltimoNodo)
                {
                    UltimoNodo.Padre.HijoIzquierdo = null;
                }
                else
                {
                    UltimoNodo.Padre.HijoDerecho = null;
                }
            }
            OrdenarArribaHaciaAbajo(Raiz);
            NumeroTarea--;
            return PrimerNodo;
        }
        /// <summary>
        /// It searches the last node added to the Priority Queue.
        /// </summary>
        /// <param name="current"></param> The current node being evaluated.
        /// <param name="number"></param> Total number of elements
        /// <returns></returns>
        private ColaNodo<T> BuscarUltimoNodo(ColaNodo<T> actual, int numero)
        {
            try
            {
                int numAnterior = NumeroTarea;
                if (numAnterior == numero)
                {
                    return actual;
                }
                else
                {
                    while (numAnterior / 2 != numero)
                    {
                        numAnterior = numAnterior / 2;
                    }
                    if (numAnterior % 2 == 0)
                    {
                        if (actual.HijoIzquierdo != null)
                        {
                            return BuscarUltimoNodo(actual.HijoIzquierdo, numAnterior);
                        }
                        else
                        {
                            return actual;
                        }
                    }
                    else
                    {
                        if (actual.HijoDerecho != null)
                        {
                            return BuscarUltimoNodo(actual.HijoDerecho, numAnterior);
                        }
                        else
                        {
                            return actual;
                        }
                    }
                }
            }
            catch
            {
                return actual;
            }

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var copiaCola = new Cola<T>() { Raiz = this.Raiz, NumeroTarea = this.NumeroTarea };
            var actual = copiaCola.Raiz;
            while (actual != null)
            {
                yield return actual.Tarea;
                actual = copiaCola.ObtenerPrimero();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}