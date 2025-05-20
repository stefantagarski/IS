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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department DeleteById(Guid id)
        {
            var department = _departmentRepository.Get(selector: x => x,
                                                predicate: x => x.Id == id);
            return _departmentRepository.Delete(department);
        }

        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll(selector: x => x).ToList();
        }

        public Department? GetById(Guid id)
        {
            return _departmentRepository.Get(selector: x => x,
                                          predicate: x => x.Id == id);
        }

        public Department Insert(Department department)
        {
            department.Id = Guid.NewGuid();
            return _departmentRepository.Insert(department);
        }

        public Department Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
    }
}
