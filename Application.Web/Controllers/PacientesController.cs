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
    public class PacientesController : Controller
    {
        private readonly IPacienteManager manager;
        private readonly IMapper mapper;

        public PacientesController(IPacienteManager manager)
        {
            this.manager = manager;
            mapper = AutoMapperConfiguration.Mapper;
        }

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = mapper.Map<IEnumerable<Paciente>, IEnumerable<PacienteViewModel>>(manager.GetAll());
            return View(pacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult VisualizarPaciente(int id)
        {
            var pacienteConsultado = manager.GetById(id);
            var paciente = mapper.Map<Paciente, PacienteViewModel>(pacienteConsultado);
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult NovoPaciente()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoPaciente(PacienteViewModel novoPaciente)
        {
            if (ModelState.IsValid)
            {
                var paciente = mapper.Map<PacienteViewModel, Paciente>(novoPaciente);
                manager.Add(paciente);
                this.AddNotification("Paciente cadastrado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("O Paciente não foi cadastrado!", NotificationType.ERROR);
            return View(novoPaciente);
        }

        //Verifica se existe CPF cadastrado
        public ActionResult ValidarCPF(string cpf)
        {
            var verificaCPF = manager.VerificaCPF(cpf);

            if(verificaCPF is null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(string.Format("CPF '{0}' já está cadastrado!", cpf), JsonRequestBehavior.AllowGet);
            }

        }

        // GET: Pacientes/Edit/5
        public ActionResult AlterarPaciente(int id)
        {
            var pacienteConsultado = manager.GetById(id);
            var paciente = mapper.Map<Paciente, PacienteViewModel>(pacienteConsultado);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarPaciente(PacienteViewModel pacienteAlterado)
        {
            if (ModelState.IsValid)
            {
                var paciente = mapper.Map<PacienteViewModel, Paciente>(pacienteAlterado);
                manager.Update(paciente);
                this.AddNotification("Paciente Alterado com sucesso!", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            this.AddNotification("O Paciente não foi alterado com sucesso!", NotificationType.ERROR);
            return View(pacienteAlterado);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Excluir(int id)
        {
            var pacienteConsultado = manager.GetById(id);
            var paciente = mapper.Map<Paciente, PacienteViewModel>(pacienteConsultado);
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult PacienteExcluido(int id)
        {
            var paciente = manager.GetById(id);
            manager.Remove(paciente);
            this.AddNotification("Paciente excluído com sucesso!", NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}
