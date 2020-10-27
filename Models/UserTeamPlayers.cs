using System;
using System.Collections.Generic;

namespace BasketballProjectRazor.Models
{
    public partial class UserTeamPlayers
    {
        public int UserTeamId { get; set; }
        public int PlayerId { get; set; }
        public int Id { get; set; }

        public virtual Players Player { get; set; }
        public virtual UserTeams UserTeam { get; set; }
    }
}
