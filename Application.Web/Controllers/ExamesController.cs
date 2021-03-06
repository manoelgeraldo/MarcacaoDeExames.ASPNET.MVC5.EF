using Application.Web.AutoMapper;
using Application.Web.Extensions;
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
            ViewBag.ListaTipo = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
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
                this.AddNotification("Exame cadastrado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.ListaTipo = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            return View(novoExame);
        }

        // GET: Exames/Edit/5
        public ActionResult AlterarExame(int id)
        {
            var exameConsultado = manager.GetById(id);
            var exame = mapper.Map<Exame, ExameViewModel>(exameConsultado);

            ViewBag.ListaTipo = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");

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
                this.AddNotification("Exame alterado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.ListaTipo = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo", exameAlterado.TipoExameId);
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
            
            this.AddNotification("Exame excluído com sucesso!", NotificationType.SUCCESS);

            return RedirectToAction("Index");
        }
    }
}
