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

namespace Game.web.Controllers
{
    public class AthletesController : Controller
    {
        private readonly IAthleteService _athleteService;
        private readonly ITeamService _teamService;

        public AthletesController(IAthleteService athleteService, ITeamService teamService)
        {
            _athleteService = athleteService;
            _teamService = teamService;
        }

        // GET: Athletesx
        public IActionResult Index()
        {
            ViewData["TeamId"] = new SelectList(_teamService.GetAll(), "Id", "Name");
            return View(_athleteService.GetAll());
        }

        // GET: Athletes/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = _athleteService.GetById(id.Value);
            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // GET: Athletes/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_teamService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Athletes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,DateOfBirth,JerseyNumber,DateJoined,TeamId")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                _athleteService.Insert(athlete);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_teamService.GetAll(), "Id", "Name", athlete.TeamId);
            return View(athlete);
        }

        // GET: Athletes/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = _athleteService.GetById(id.Value);
            if (athlete == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_teamService.GetAll(), "Id", "Name", athlete.TeamId);
            return View(athlete);
        }

        // POST: Athletes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,FirstName,LastName,DateOfBirth,JerseyNumber,DateJoined,TeamId")] Athlete athlete)
        {
            if (id != athlete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _athleteService.Update(athlete);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteExists(athlete.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_teamService.GetAll(), "Id", "Name", athlete.TeamId);
            return View(athlete);
        }

        // GET: Athletes/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = _athleteService.GetById(id.Value);
            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _athleteService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteExists(Guid id)
        {
            return _athleteService.GetById(id) == null ? false : true;
        }
    }
}
