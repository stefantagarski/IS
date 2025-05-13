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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Game.Web.Controllers
{
    public class ParticipationsController : Controller
    {
        private readonly IParticipationService _participationService;
        private readonly IAthleteService _athleteService;
        private readonly ICompetitionService _competitionService;

        public ParticipationsController(IParticipationService participationService, IAthleteService athleteService, ICompetitionService competitionService)
        {
            _participationService = participationService;
            _athleteService = athleteService;
            _competitionService = competitionService;
        }

        // GET: Participations
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return View(_participationService.GetAllByCurrentUser(userId));
        }

        // GET: Participations/Create
        [Authorize]
        public IActionResult Create(Guid id)
        {
            var partc = new Participation
            {
                AthleteId = id
            };
            ViewData["CompetitionId"] = new SelectList(_competitionService.GetAll(), "Id", "Name");
            return View(partc);
        }

        //POST: Participations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("CompetitionId,AthleteId,DateRegistered")] Participation participation)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _participationService.AddParticipationForAthleteAndCompetition(
                participation.AthleteId,
                participation.CompetitionId,
                userId);

            return RedirectToAction(nameof(Index));
        }


        // POST: Applications/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            _participationService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
