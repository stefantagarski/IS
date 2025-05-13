using Game.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Interface
{
    public interface ITournamentService
    {
        Tournament Create(string userId);
        Tournament GetDetailsById(Guid id);
    }
}
