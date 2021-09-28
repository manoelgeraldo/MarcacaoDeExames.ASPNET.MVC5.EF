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
                return RedirectToAction("Index");
            }
            return View(novoPaciente);
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
                return RedirectToAction("Index");
            }
            return View(pacienteAlterado);
        }

        // GET: Pacientes/Delete/5
        public ActionResult ExcluirPaciente(int id)
        {
            var pacienteConsultado = manager.GetById(id);
            var paciente = mapper.Map<Paciente, PacienteViewModel>(pacienteConsultado);
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult PacienteExcluido(int id)
        {
            var paciente = manager.GetById(id);
            manager.Remove(paciente);

            return RedirectToAction("Index");
        }
    }
}
