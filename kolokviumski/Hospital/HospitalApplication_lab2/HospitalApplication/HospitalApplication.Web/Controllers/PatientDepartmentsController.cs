using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Data;
using HospitalApplication.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HospitalApplication.Web.Controllers
{
    public class PatientDepartmentsController : Controller
    {
        private readonly IPatientDepartmentService _patientDepartmentService;
        private readonly IDepartmentService _departmentService;
        private readonly IPatientService _patientService;

        public PatientDepartmentsController(IPatientDepartmentService patientDepartmentService, IDepartmentService departmentService, IPatientService patientService)
        {
            _patientDepartmentService = patientDepartmentService;
            _departmentService = departmentService;
            _patientService = patientService;
        }


        // GET: PatientDepartments/Create


        // TODO: Add the PatientId as parameter and use it in the view as a value for the hidden input
        // You can make a separate ViewModel or send the parameter via ViewData
        // Use the SelectList to populate the drop-down list in the view
        // Replace the usage of ApplicationDbContext with the appropriate service
        public IActionResult Create(Guid id)
        {
            var patient = new PatientDepartment
            {
                PatientId = id
            };
            ViewData["DepartmentId"] = new SelectList(_departmentService.GetAll(), "Id", "Name");
            return View(patient);
        }

        // POST: PatientDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see h
        // ttp://go.microsoft.com/fwlink/?LinkId=317598.

        // TODO: Bind the form from the view to this POST action in order to create the Registration
        // Implement the IPatientDepratmentService and use it here to create the enrollment
        // After successful creation, the user should be redirected to Index page of Patients
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,PatientId,DepartmentId,DateAssigned")] PatientDepartment patientDepartment)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _patientDepartmentService.AddPatientToDepartment(
                patientDepartment.PatientId,
                patientDepartment.DepartmentId,
                userId
                );

            return RedirectToAction("Index", "Patients");
        }
    }
}
