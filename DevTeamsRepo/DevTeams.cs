using Developers_Repository;
using System;
using System.Collections.Generic;

namespace DevTeamsRepo
{
    public class DevTeams
    {
        public  List<Developers> listOfTeamMembers { get; set; } = new List<Developers>();
        public string TeamName { get; set; }
        public double TeamId { get; set; }

        public DevTeams() { }

        public DevTeams(string teamName, double teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
    }
    
}
