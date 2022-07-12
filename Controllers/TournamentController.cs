using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaveSoftAss.UnitOfWork.Interfaces;

namespace WaveSoftAss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        private readonly MyHollyWoodBetContext _database;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentController(MyHollyWoodBetContext database, 
            ITournamentRepository tournamentRepository)
        {
            _database = database;
            _tournamentRepository = tournamentRepository;
        }
        //GetAllTournament

        [HttpGet(Name = "GetTournaments")]
        public  ActionResult<IEnumerable<Tournament>> Get()
        {
            //
            var allTournaments = _tournamentRepository.GetTournaments();
            if(allTournaments == null)
            {
                return BadRequest("Tournaments still Empty");
            }
            return Ok(allTournaments);


        }

        //GetTournamentById
        [HttpGet("{Id}")]
        public ActionResult<Tournament> GetTournament(long Id)
        {
            //
            var t = _tournamentRepository.GetTournamentById(Id);
            return Ok(t);
        }

        //UpdateTournament
        [HttpPut("{Id}")]
        public ActionResult<Tournament> UpdateTournamet( long Id, [FromBody] Tournament tournament)
        {
            //
            var updatedTournament = _tournamentRepository.UpdateTournament(Id, tournament);
            return Ok(updatedTournament);
        }

        //DeleteTournament
        [HttpDelete("{Id}")]
        public ActionResult DeleteTournament(long Id)
        {
            //delete
            _tournamentRepository.RemoveTournament(Id);
            _database.SaveChanges();
             Get();
            return Ok($"Event deleted");
        }

        //Create Tournament
        [HttpPost(Name ="AddNewTournament")]
        public ActionResult<Tournament> CreateTournament([FromBody] Tournament tournament)
        {
            // 
            var newTournament = _tournamentRepository.AddTournament(tournament);
            _database.SaveChanges();
            return Ok(newTournament);
        }


    }
}
