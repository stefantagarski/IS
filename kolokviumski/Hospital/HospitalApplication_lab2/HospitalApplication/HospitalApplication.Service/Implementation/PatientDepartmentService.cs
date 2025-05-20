using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Interface;
using HospitalApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Service.Implementation
{
    public class PatientDepartmentService : IPatientDepartmentService
    {
        private readonly IRepository<PatientDepartment> _patientDepartmentRepository;
        private readonly IPatientService _patientService;
        private readonly IDepartmentService _departmentService;

        public PatientDepartmentService(IRepository<PatientDepartment> patientDepartmentRepository, IPatientService patientService, IDepartmentService departmentService)
        {
            _patientDepartmentRepository = patientDepartmentRepository;
            _patientService = patientService;
            _departmentService = departmentService;
        }

        public PatientDepartment AddPatientToDepartment(Guid patientId, Guid departmentId, string userId)
        {
            var patientDepartment = new PatientDepartment
            {
                PatientId = patientId,
                DepartmentId = departmentId,
                DateAssigned = DateTime.Now,
                OwnerId = userId,
            };

            return _patientDepartmentRepository.Insert(patientDepartment);
        }
    }
}
