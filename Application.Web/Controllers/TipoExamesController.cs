using AutoMapper;
using Service.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class TipoExamesController : Controller
    {
        private readonly ITipoExameManager manager;
        private readonly IMapper mapper;

        // GET: TipoExames
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoExames/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoExames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoExames/Create
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

        // GET: TipoExames/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoExames/Edit/5
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

        // GET: TipoExames/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoExames/Delete/5
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
