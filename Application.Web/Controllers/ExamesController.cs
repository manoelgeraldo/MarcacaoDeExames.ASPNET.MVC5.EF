using Application.Web.AutoMapper;
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
        private readonly ITipoExameManager managerTipoExame;
        private readonly IMapper mapper;

        public ExamesController(IExameManager manager, ITipoExameManager managerTipoExame)
        {
            this.manager = manager;
            this.managerTipoExame = managerTipoExame;
            mapper = AutoMapperConfiguration.Mapper;
        }

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
        public ActionResult VisualizarExame(int id)
        {
            var exameConsultado = manager.GetById(id);
            var exame = mapper.Map<Exame, ExameViewModel>(exameConsultado);
            return View(exame);
        }

        // GET: Exames/Create
        public ActionResult NovoExame()
        {
            ViewBag.TipoExameId = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            return View();
        }

        // POST: Exames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoExame(ExameViewModel novoExame)
        {
            if (ModelState.IsValid)
            {
                var exame = mapper.Map<ExameViewModel, Exame>(novoExame);
                manager.Add(exame);
                return RedirectToAction("Index");
            }
            ViewBag.TipoExameId = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            return View(novoExame);
        }

        // GET: Exames/Edit/5
        public ActionResult AlterarExame(int id)
        {
            var exameConsultado = manager.GetById(id);
            var exame = mapper.Map<Exame, ExameViewModel>(exameConsultado);

            ViewBag.TipoExameId = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo", exame.TipoExameId);

            return View(exame);
        }

        // POST: Exames/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarExame(ExameViewModel exameAlterado)
        {
            if (ModelState.IsValid)
            {
                var exame = mapper.Map<ExameViewModel, Exame>(exameAlterado);
                manager.Update(exame);
                return RedirectToAction("Index");
            }

            ViewBag.Tipos = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo", exameAlterado.TipoExameId);
            return View(exameAlterado);
        }

        // GET: Exames/Delete/5
        public ActionResult Excluir(int id)
        {
            var exameConsultado = manager.GetById(id);
            var exame = mapper.Map<Exame, ExameViewModel>(exameConsultado);
            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExameExcluido(int id)
        {
            var exame = manager.GetById(id);
            manager.Remove(exame);

            return RedirectToAction("Index");
        }
    }
}
