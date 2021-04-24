using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Estructuras
{
    public class Hash<T> where T : IComparable
    {

        public int Longitud;
        public HashNodo<T>[] HashTable;


        public Hash(int longitud)
        {
            Longitud = longitud;
            HashTable = new HashNodo<T>[Longitud];
        }


        public void Insertar(T InsertV, string llave)
        {
            HashNodo<T> T1 = new HashNodo<T>();
            T1.Valor = InsertV;
            T1.Llave = llave;
            int code = ObtenerCodigo(T1.Llave);
            if (HashTable[code] != null)
            {
                HashNodo<T> Aux = HashTable[code];
                while (Aux.Prox != null)
                {
                    Aux = Aux.Prox;
                }
                Aux.Prox = T1;
                T1.Previo = Aux;
            }
            else
            {
                HashTable[code] = T1;
            }
        }

        public void Insertar(T InsertV, string llave, int multiplicador)
        {
            HashNodo<T> T1 = new HashNodo<T>();
            T1.Valor = InsertV;
            T1.Llave = llave;
            int CodigoOriginal = ObtenerCodigo(T1.Llave, multiplicador);
            int codigo =CodigoOriginal;
            if (HashTable[codigo] != null)
            {
                while (HashTable[codigo] != null)
                {
                    if (codigo >= (multiplicador + 1) * 10)
                    {
                        codigo = multiplicador * 10;
                    }
                    else
                    {
                        codigo += 1;
                    }
                }
                if (HashTable[codigo] == null)
                {
                    HashTable[codigo] = T1;
                }
            }
            else
            {
                HashTable[codigo] = T1;
            }
        }

        public HashNodo<T> Buscar(string LLaveBuscada, int multiplicador)
        {
            int CodigoOriginal = ObtenerCodigo(LLaveBuscada, multiplicador);
            int codigo = CodigoOriginal;
            bool Encontrado = false;
            while (!Encontrado)
            {
                if (HashTable[codigo] != null)
                {
                    if (LLaveBuscada != HashTable[codigo].Llave)
                    {
                        if (codigo >= (multiplicador + 1) * 10)
                        {
                            codigo = multiplicador * 10;
                        }
                        else
                        {
                            codigo += 1;
                        }
                        if (codigo == CodigoOriginal)
                        {
                            return null;
                        }
                    }
                    else
                    {
                        Encontrado = true;
                    }

                }
                else
                {
                    codigo += 1;
                    if (codigo == CodigoOriginal)
                    {
                        return null;
                    }
                }
            }
            return HashTable[codigo];

        }


        public HashNodo<T> Buscar(string LlaveBuscada)
        {
            int codigo = ObtenerCodigo(LlaveBuscada);

            if (HashTable[codigo] != null)
            {

                if (HashTable[codigo].Llave != LlaveBuscada)
                {
                    HashNodo<T> Aux = HashTable[codigo];
                    while (Aux.Llave != LlaveBuscada && Aux.Prox != null)
                    {
                        Aux = Aux.Prox;
                    }
                    if (Aux.Llave == LlaveBuscada)
                    {
                        return Aux;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return HashTable[codigo];
                }
            }
            else
            {
                return null;
            }
        }

        public void Borrar(T valor, string LlaveBuscada, int multiplicador)
        {
            int codigo = ObtenerCodigo(valor, LlaveBuscada, multiplicador);

            while (HashTable[codigo] == null)
            {
                codigo++;
            }

            if (HashTable[codigo] != null)
            {
                if (HashTable[codigo].Llave != LlaveBuscada)
                {
                    while (HashTable[codigo].Llave != LlaveBuscada)
                    {
                        if (codigo >= (multiplicador + 1) * 10)
                        {
                            codigo = multiplicador * 10;
                        }
                        else
                        {
                            codigo += 1;
                        }
                    }
                    if (HashTable[codigo].Llave == LlaveBuscada)
                    {
                        HashTable[codigo] = null;
                    }
                }
                else
                {
                    if (HashTable[codigo].Prox != null)
                    {
                        HashTable[codigo] = HashTable[codigo].Prox;
                    }
                    else
                    {
                        HashTable[codigo] = null;
                    }
                }
            }
        }

        private int ObtenerCodigo(string Llave)
        {
            int longitud = Llave.Length;
            int codigo = 0;
            for (int i = 0; i < longitud; i++)
            {
                codigo += Convert.ToInt32(Llave.Substring(i, 1));
            }
            codigo = (codigo * 7) % longitud;
            return codigo;
        }

        private int ObtenerCodigo(string Llave, int multiplicador)
        {
            int codigo = Llave.Length * 11 % (multiplicador * 10);
            while (codigo < multiplicador * 10)
            {
                if (codigo >= (multiplicador * 10))
                {
                    codigo -= 10;
                }
                else
                {
                    if (HashTable[codigo] != null)
                    {
                        codigo += 1;
                    }
                    else
                    {
                        return codigo;
                    }
                }
            }
            return codigo;
        }

        private int ObtenerCodigo(T valor, string Llave, int multiplicador)
        {
            int codigo  = Llave.Length * 11 % (multiplicador * 10);
            while (codigo < multiplicador * 10)
            {
                if (codigo >= (multiplicador * 10))
                {
                    codigo -= 10;
                }
                else
                {
                    if (HashTable[codigo] != null)
                    {
                        if (HashTable[codigo].Valor.CompareTo(valor) == 0)
                        {
                            return codigo;
                        }
                        else
                        {
                            codigo += 1;
                        }
                    }
                    else
                    {
                        return codigo;
                    }
                }
            }
            return codigo;
        }

        public List<HashNodo<T>> ObtenerNodo()
        {
            var regresarLista = new List<HashNodo<T>>();
            var nodoActual = new HashNodo<T>();
            foreach (var task in HashTable)
            {
                nodoActual = task;
                while (nodoActual != null)
                {
                    regresarLista.Add(nodoActual);
                    nodoActual = nodoActual.Prox;
                }
            }
            return regresarLista;
        }

        public List<T> ObtenerListaFiltrada(Func<T, bool> predicate)
        {
            List<T> ListaFiltrada = new List<T>();
            var nodoActual = new HashNodo<T>();
            foreach (var task in HashTable)
            {
                nodoActual = task;
                while (nodoActual != null)
                {
                    if (predicate(nodoActual.Valor))
                    {
                        ListaFiltrada.Add(nodoActual.Valor);
                    }
                    nodoActual = nodoActual.Prox;
                }
            }
            return ListaFiltrada;
        }

        public HashNodo<T> ObtenerT(int pos, int block)
        {
            return HashTable[pos + block];
        }
    }


}