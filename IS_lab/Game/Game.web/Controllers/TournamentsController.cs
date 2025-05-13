using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Game.Domain.DomainModels;
using Game.Repository;
using Game.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Game.web.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            // TODO: Implement method
            // Get current user, call service method, redirect to Details
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

           var tournament = _tournamentService.Create(userId);

            return RedirectToAction("Details", new {id = tournament.Id});
        }


        public IActionResult Details(Guid id)
        {
            var tournament = _tournamentService.GetDetailsById(id);

            return View(tournament);
        }
    }
}
