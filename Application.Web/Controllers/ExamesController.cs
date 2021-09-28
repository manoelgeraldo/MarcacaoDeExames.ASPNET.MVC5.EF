using AutoMapper;
using Domain.Entities;
using Service.Manager.Interfaces;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class ExamesController : Controller
    {
        private readonly IExameManager manager;
        private readonly IMapper mapper;

        // GET: Exames
        public ActionResult Index()
        {
            var exames = mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(manager.GetAll());
            return View(exames);
        }

        public ActionResult ExamesIncluindoTipos()
        {
            var exames = mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(manager.ExamesIncluindoTipos());
            return View(exames);
        }

        // GET: Exames/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exames/Create
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

        // GET: Exames/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exames/Edit/5
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

        // GET: Exames/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exames/Delete/5
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
