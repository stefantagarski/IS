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
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient DeleteById(Guid id)
        {
            var patient = _patientRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _patientRepository.Delete(patient);
        }

        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll(selector: x => x).ToList();
        }

        public Patient? GetById(Guid id)
        {
            return _patientRepository.Get(selector: x => x,
                                          predicate: x => x.Id == id);
        }

        public Patient Insert(Patient patient)
        {
            patient.Id = Guid.NewGuid();
            return _patientRepository.Insert(patient);
        }

        public Patient Update(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
    }
}
