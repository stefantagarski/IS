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
    public class TransferRequestsController : Controller
    {
        private readonly ITransferRequestService _transferRequestService;

        public TransferRequestsController(ITransferRequestService transferRequestService)
        {
            _transferRequestService = transferRequestService;
        }


        [HttpPost, ActionName("CreateTransferRequest")]
        [Authorize]
        public IActionResult CreateTransferRequest()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var transferReq = _transferRequestService.CreateTransferRequest(userId);

            return RedirectToAction("Details", new {id = transferReq.Id});
        }

        // GET: TransferRequests/Details/5
        public IActionResult Details(Guid id)
        {
            // TODO: Implement method
            // Create ViewModel with Count or pass it through ViewBag/ViewData
           var transfer = _transferRequestService.GetTransferRequestDetails(id);

           return View(transfer); 
        }
    }
}
