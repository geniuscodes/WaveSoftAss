using WaveSoftAss.UnitOfWork.Interfaces;

namespace WaveSoftAss.UnitOfWork.Repositories
{

    
    public class TournamentRepository : ITournamentRepository
    {

        private readonly MyHollyWoodBetContext _database;

        public TournamentRepository(MyHollyWoodBetContext database)
        {
            _database = database;
        }
        public Tournament AddTournament(Tournament tournament)
        {
            //
            var newTournament = new Tournament
            {
                TournamentName = tournament.TournamentName,
                TournamentId = tournament.TournamentId

            };
            _database.Add(newTournament);
            _database.SaveChanges();
            return newTournament;

        }

        public Tournament? GetTournamentById(long Id)
        {
            //Check Tournament Existence
            var tourmament = from t in _database.Tournaments.ToList()
                         where t.TournamentId == Id
                         select new Tournament
                         {
                             TournamentId = t.TournamentId,
                             TournamentName = t.TournamentName,
                         };

            return tourmament.FirstOrDefault();
        }

        public IEnumerable<Tournament> GetTournaments()
        {
            var Tournaments = _database.Tournaments.ToList();
            var results = from tournament in Tournaments
                          select new Tournament
                          {
                              TournamentId = tournament.TournamentId,
                              TournamentName = tournament.TournamentName,

                          };
            return results.ToList();
        }

        public void RemoveTournament(long Id)
        {
            //GetTournament
            var tournament = _database.Tournaments.FirstOrDefault(x => x.TournamentId == Id);
            _database.Remove(tournament);
            _database.SaveChanges();

        }

        public Tournament UpdateTournament(long Id, Tournament tournament)
        {
            //GetById
             var tournmnt = _database.Tournaments.FirstOrDefault(x => x.TournamentId == Id);
            if (tournmnt == null)
                return null;
              tournmnt.TournamentName = tournament.TournamentName;
            _database.Update(tournmnt);
            _database.SaveChanges();
            return tournmnt;


        }
    }
}
