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




        // GET: Participations/Create
        // TODO: Add the AthleteId as parameter and use it in the view as a value for the hidden input
        // You can make a separate ViewModel or send the parameter via ViewData
        // Use the SelectList to populate the drop-down list in the view
        // Replace the usage of ApplicationDbContext with the appropriate service
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
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //TODO: Bind the form from the view to this POST action in order to create the Participation
        //Implement the IParticipationService and use it here to create the visit

       // After successful creation, the user should be redirected to Index page of Participants

       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CompetitionId,AthleteId,DateRegistered")] Participation participation)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                _participationService.AddParticipationForAthleteAndCompetition(participation.AthleteId
                    , participation.CompetitionId, userId);
                return RedirectToAction("Index", "Athletes");
            }
            ViewData["AthleteId"] = new SelectList(_athleteService.GetAll(), "Id", "Name", participation.AthleteId);
            ViewData["CompetitionId"] = new SelectList(_competitionService.GetAll(), "Id", "Name", participation.CompetitionId);
            return View(participation);
        }
    }
}
