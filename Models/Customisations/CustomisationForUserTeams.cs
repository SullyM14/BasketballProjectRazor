using System;
using System.Collections.Generic;
using System.Text;

namespace BasketballProjectRazor.Models
{
    public partial class UserTeams
    {
        public override string ToString()
        {
            return $"{TeamName}";
        }
    }
}
