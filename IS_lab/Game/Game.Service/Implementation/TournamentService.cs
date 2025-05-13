using Game.Domain.DomainModels;
using Game.Repository;
using Game.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Implementation
{
    public class TournamentService : ITournamentService
    {
        private readonly IRepository<Tournament> _tournamentRepository;
        private readonly IRepository<AthleteInTournament> _athleteInTournamentRepository;
        private readonly IParticipationService _participationService;

        public TournamentService(IRepository<Tournament> tournamentRepository, IRepository<AthleteInTournament> athleteInTournamentRepository, IParticipationService participationService)
        {
            _tournamentRepository = tournamentRepository;
            _athleteInTournamentRepository = athleteInTournamentRepository;
            _participationService = participationService;
        }
        //TODO
        public Tournament Create(string userId)
        {
            // TODO: Implement method
            // Hint: Look at auditory exercises: OrderProducts method in ShoppingCartService

            // Get all Participations by current user
            // Create new Tournament and insert in database
            // Create new AthletesInTournament using Athletes from the Participation and insert in database
            // Delete all Participations
            // Return Tournament
            var participations = _participationService.GetAllByCurrentUser(userId);

            var tournament = new Tournament
            {
                Id = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                OwnerId = userId,
            };

            _tournamentRepository.Insert(tournament);

            var allAthletesInTournament = participations.Select(x => new AthleteInTournament
            {
                TournamentId = tournament.Id,
                Tournament = tournament,
                AthleteId = x.AthleteId,
                Athlete = x.Athlete,
            });

            foreach (var item in allAthletesInTournament)
            {
                _athleteInTournamentRepository.Insert(item);
            }

            foreach (var item in participations)
            {
                _participationService.DeleteById(item.Id);
            }

            return tournament;
        }

        //TODO
        public Tournament GetDetailsById(Guid id)
        {
            return _tournamentRepository.Get(selector: x => x,
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.AthleteInTournaments));
        }
    }
}
