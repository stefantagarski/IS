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
    public class TransferRequestService : ITransferRequestService
    {
        private readonly IRepository<TransferRequest> _transferRequestRepository;
        private readonly IRepository<PatientTransfer> _patientTransferRepository;
        private readonly IPatientDepartmentService _patientDepartmentsService;

        public TransferRequestService(IRepository<TransferRequest> transferRequestRepository, IRepository<PatientTransfer> patientTransferRepository, IPatientDepartmentService patientDepartmentsService)
        {
            _transferRequestRepository = transferRequestRepository;
            _patientTransferRepository = patientTransferRepository;
            _patientDepartmentsService = patientDepartmentsService;
        }

        public TransferRequest CreateTransferRequest(string userId)
        {
            var patientDeparments =  _patientDepartmentsService.GetAllByCurrentUser(userId);

            var newTransferRequest = new TransferRequest
            {
                OwnerId = userId,
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
            };

            _transferRequestRepository.Insert(newTransferRequest);

            var allPatientsTransfers = patientDeparments.Select(x => new PatientTransfer
            {
                PatientId = x.PatientId,
                TransferRequestId = newTransferRequest.Id,
            });

            foreach (var item in allPatientsTransfers)
            {
                _patientTransferRepository.Insert(item);
            }

            foreach (var item in patientDeparments)
            {
                _patientDepartmentsService.DeleteById(item.Id);
            }

            return newTransferRequest;

        }
        public TransferRequest? GetTransferRequestDetails(Guid id)
        {
            return _transferRequestRepository.Get(selector: x => x,
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.PatientTransfers).ThenInclude(z => z.Patient));
        }
    }
}
