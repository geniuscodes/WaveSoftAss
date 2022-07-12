using System;
using System.Collections.Generic;

namespace WaveSoftAss
{
    public  class Tournament
    {
      
       

        public long TournamentId { get; set; }
        public string TournamentName { get; set; } = null!;

        //Collection of Events - One-to-Many
    }
}
