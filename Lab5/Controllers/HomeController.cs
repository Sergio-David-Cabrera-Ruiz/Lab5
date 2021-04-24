using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab5.Models;
using System.Reflection;
using System.IO;
using Lab5.Auxiliar;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var opcion = collection["Opcion"];
            switch (opcion)
            {
                case "NuevaTarea":
                    return RedirectToAction("NuevaTarea");
                case "ListaTarea":
                    return RedirectToAction("ListaTarea");
            }

            return View();
        }
        public ActionResult NuevaTarea()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevaTarea (FormCollection collection)
        {
            try
            {
                if(int.Parse(collection["Prioridad"]) <0 || int.Parse(collection["Prioridad"]) > 100)
                {
                    ModelState.AddModelError("Prioridad", "Por favor ingrese valores válidos");
                    return View("NuevaTarea");
                }
                foreach (var tarea in Almacenamiento.Instance.TareaHash.ObtenerNodo())
                {
                    if (tarea.Valor.Titulo ==collection["Titulo"])
                    {
                        ModelState.AddModelError("Titulo", "Una tarea posee el mismo titulo. Por favor ingrese un titulo diferente.");
                        return View("NuevaTarea");
                    }
                }
                var nuevaTarea = new Tarea()
                {
                    Titulo = collection["Titulo"],
                    Descripcion = collection["Descripción"],
                    Proyecto = collection["Proyecto"],
                    FechaEntrega = collection["FechaEntrega"],
                    DescripcionProyecto = collection["DescripcionProyecto"],
                    Prioridad = int.Parse(collection["Prioridad"])
                };
                var structTarea = new TareaStruct()
                {
                    Titulo = nuevaTarea.Titulo,
                    Prioridad = nuevaTarea.Prioridad,
                };
                Almacenamiento.Instance.TareaHash.Insertar(nuevaTarea, nuevaTarea.Titulo);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("DescripcionProyecto", "Por favor llene todos los campos correctamente.");
                return View("NuevaTarea");
            }
        }

        private bool CaracterIncorrecto (string data)
        {
            try
            {
                var numero = int.Parse(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ActionResult ListaTareas(int? pagina, string busqueda, string categoria)
        {
            var tarealista = ObtenerTareas(null, null);
            return View(tarealista);
        }

        private List<TareaStruct> ObtenerTareas(string busqueda, string categoria)
        {
            var lista = new List<TareaStruct>();
            var tarea = new TareaStruct();
            foreach (var node in Almacenamiento.Instance.Tareas)
            {
                lista.Add(tarea);
            }
            return lista;
        }
    }
}