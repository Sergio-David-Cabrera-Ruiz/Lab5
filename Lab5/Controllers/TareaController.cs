﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class TareaController : Controller
    {

        // GET: Tarea
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tarea/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tarea/Create
        public ActionResult Create([Bind(Include = "Titulo,Descripcion,Proyecto,Prioridad,FechaEntrega")] Tarea Tarea)
        {
            return View();
        }

        // POST: Tarea/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarea/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tarea/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tarea/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
