using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;
using Lab5.Estructuras;

namespace Lab5.Auxiliar
{
    public class Almacenamiento
    {
        public static Almacenamiento _instance = null;
        public static Almacenamiento Instance
        {
            get
            {
                if (_instance == null) _instance = new Almacenamiento();
                return _instance;
            }
        }
        public List<TareaStruct> Tareas = new List<TareaStruct>();
        public Hash<Tarea> TareaHash = new Hash<Tarea>(100);
    }
}