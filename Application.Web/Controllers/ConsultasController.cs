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
    public class ConsultasController : Controller
    {

        private readonly IMapper mapper;
        private readonly IConsultaManager manager;
        private readonly IExameManager managerExame;
        private readonly IPacienteManager managerPaciente;
        private readonly ITipoExameManager managerTipoExame;

        public ConsultasController(IConsultaManager manager, IPacienteManager managerPaciente, IExameManager managerExame, ITipoExameManager managerTipoExame)
        {
            this.manager = manager;
            this.managerExame = managerExame;
            this.managerPaciente = managerPaciente;
            this.managerTipoExame = managerTipoExame;
            mapper = AutoMapperConfiguration.Mapper;
        }

        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = mapper.Map<IEnumerable<Consulta>, 
                                       IEnumerable<ConsultaViewModel>>
                                       (manager.GetAll()
                                               .OrderBy(x => x.DataConsulta)
                                               .ThenBy(x => x.HorarioConsulta));
            return View(consultas);
        }

        // GET: Consultas/Details/5
        public ActionResult VisualizarConsulta(int id)
        {
            var verificaConsulta = manager.GetById(id);
            var consulta = mapper.Map<Consulta, ConsultaViewModel>(verificaConsulta);
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult NovaConsulta()
        {
            ViewBag.ListaTipos = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            return View();
        }

        public JsonResult ListaCPF(string prefix)
        {
            var listaCPF = managerPaciente.GetAll().Where(c => c.CPF.Contains(prefix))
                                          .Select(c => new { label = c.CPF, value = c.PacienteId });
            return Json(listaCPF, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListaExame(int TipoExameId)
        {
            var listaExames = managerExame.GetAll().Where(e => e.TipoExameId == TipoExameId).ToList();
            return Json(listaExames, JsonRequestBehavior.AllowGet);
        }

        // POST: Consultas/Create
        [HttpPost]
        public ActionResult NovaConsulta(ConsultaViewModel novaConsulta)
        {

            var cpfExiste = managerPaciente.GetById(novaConsulta.PacienteId);

            if (cpfExiste is null)
            {
                this.AddNotification("CPF não encontrado! Por favor, cadastrar o paciente!", NotificationType.INFO);
                return Redirect("~/Pacientes/NovoPaciente");
            }
            else
            {
                novaConsulta.Protocolo = String.Concat(Convert.ToString(novaConsulta.DataConsulta.Year),
                                                   Convert.ToString(novaConsulta.DataConsulta.Day),
                                                   Convert.ToString(novaConsulta.DataConsulta.Month),
                                                   Convert.ToString(novaConsulta.HorarioConsulta.Hours),
                                                   Convert.ToString(novaConsulta.HorarioConsulta.Minutes),
                                                   Convert.ToString(novaConsulta.PacienteId),
                                                   Convert.ToString(novaConsulta.TipoExameId),
                                                   Convert.ToString(novaConsulta.ExameId));
                
                var consultaExiste = manager.VerificarConsulta(novaConsulta.Protocolo);

                if (consultaExiste is null & ModelState.IsValid)
                {
                    var consulta = mapper.Map<ConsultaViewModel, Consulta>(novaConsulta);
                    manager.Add(consulta);
                    this.AddNotification("Consulta agendada com sucesso!", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }

            this.AddNotification("Já existe Consulta agendada! Por favor, escolha outra data e hora!", NotificationType.ERROR);
            return View(novaConsulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult AlterarConsulta(int id)
        {
            var verificaConsulta = manager.GetById(id);
            var consulta = mapper.Map<Consulta, ConsultaViewModel>(verificaConsulta);

            ViewBag.ListaTipos = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarConsulta(ConsultaViewModel consultaAlterada)
        {
            if (ModelState.IsValid)
            {
                var consulta = mapper.Map<ConsultaViewModel, Consulta>(consultaAlterada);
                manager.Update(consulta);
                this.AddNotification("Consulta Alterada com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.ListaTipos = new SelectList(managerTipoExame.GetAll(), "TipoExameId", "Tipo");
            this.AddNotification("A consulta não pode ser Alterada!", NotificationType.ERROR);
            return View(consultaAlterada);
        }

        // GET: Consultas/Delete/5
        public ActionResult Excluir(int id)
        {
            var verificaConsulta = manager.GetById(id);
            var consulta = mapper.Map<Consulta, ConsultaViewModel>(verificaConsulta);
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaExcluida(int id)
        {
            var consulta = manager.GetById(id);
            manager.Remove(consulta);

            this.AddNotification("Consulta Excluída com sucesso!", NotificationType.SUCCESS);

            return RedirectToAction("Index");
        }
    }
}
