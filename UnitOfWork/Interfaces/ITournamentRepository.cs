namespace WaveSoftAss.UnitOfWork.Interfaces
{
    public interface ITournamentRepository
    {
        //Create Tournament
        public Tournament AddTournament(Tournament tournament);
        //Update Tournament
        Tournament UpdateTournament(long Id, Tournament tournament);
        //Remove Tournanment
        void RemoveTournament(long Id);
        //GetById
        Tournament GetTournamentById(long Id);
        //GetAll Tournaments
        IEnumerable<Tournament> GetTournaments();
    }
}
