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
    public class TipoExamesController : Controller
    {
        private readonly ITipoExameManager manager;
        private readonly IMapper mapper;

        public TipoExamesController(ITipoExameManager manager)
        {
            this.manager = manager;
            mapper = AutoMapperConfiguration.Mapper;
        }

        // GET: TipoExames
        public ActionResult Index()
        {
            var tipos = mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(manager.GetAll());
            return View(tipos);
        }

        // GET: TipoExames/Details/5
        public ActionResult VisualizarTipoExame(int id)
        {
            var tipoConsultado = manager.GetById(id);
            var tipo = mapper.Map<TipoExame, TipoExameViewModel>(tipoConsultado);
            return View(tipo);
        }

        // GET: TipoExames/Create
        public ActionResult NovoTipo()
        {
            return View();
        }

        // POST: TipoExames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoTipo(TipoExameViewModel novoTipo)
        {
            if (ModelState.IsValid)
            {
                var tipo = mapper.Map<TipoExameViewModel, TipoExame>(novoTipo);
                manager.Add(tipo);
                this.AddNotification("Tipo de Exame cadastrado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(novoTipo);
        }

        // GET: TipoExames/Edit/5
        public ActionResult AlterarTipo(int id)
        {
            var tipoConsultado = manager.GetById(id);
            var tipo = mapper.Map<TipoExame, TipoExameViewModel>(tipoConsultado);
            return View(tipo);
        }

        // POST: TipoExames/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarTipo(TipoExameViewModel tipoAlterado)
        {
            if (ModelState.IsValid)
            {
                var tipo = mapper.Map<TipoExameViewModel, TipoExame>(tipoAlterado);
                manager.Update(tipo);
                this.AddNotification("Tipo de Exame alterado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("O Tipo de Exame não foi alterado!", NotificationType.ERROR);
            return View(tipoAlterado);
        }

        // GET: TipoExames/Delete/5
        public ActionResult Excluir(int id)
        {
            var tipoConsultado = manager.GetById(id);
            var tipo = mapper.Map<TipoExame, TipoExameViewModel>(tipoConsultado);
            return View(tipo);
        }

        // POST: TipoExames/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult TipoExcluido(int id)
        {
            var tipo = manager.GetById(id);
            manager.Remove(tipo);
            this.AddNotification("Tipo de Exame excluído com sucesso!", NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}
