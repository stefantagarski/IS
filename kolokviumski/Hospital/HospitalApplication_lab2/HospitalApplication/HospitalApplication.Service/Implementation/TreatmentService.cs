using HospitalApplication.Domain.DomainModels;
using HospitalApplication.Repository.Interface;
using HospitalApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Service.Implementation
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IRepository<Treatment> _treatmentRepository;

        public TreatmentService(IRepository<Treatment> treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public Treatment DeleteById(Guid id)
        {
            var treatment = _treatmentRepository.Get(selector: x => x,
                                                  predicate: x => x.Id == id);
            return _treatmentRepository.Delete(treatment);
        }

        public List<Treatment> GetAll()
        {
            return _treatmentRepository.GetAll(selector: x => x,
                include: x => x.Include(y => y.Patient)).ToList();
        }

        public Treatment? GetById(Guid id)
        {
            return _treatmentRepository.Get(selector: x => x,
                                          predicate: x => x.Id == id,
                                          include: x => x.Include(y => y.Patient));
        }

        public Treatment Insert(Treatment treatment)
        {
            treatment.Id = Guid.NewGuid();
            return _treatmentRepository.Insert(treatment);
        }

        public Treatment Update(Treatment treatment)
        {
            return _treatmentRepository.Update(treatment);
        }
    }
}
