using Developers_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTeamsRepo
{
    public class DevTeamRepo
        
    {
        private List<DevTeams> _listOfTeams = new List<DevTeams>();
        public List<Developers> _listOfTeamMembers = new List<Developers>();
        DevelopersRepo _developerRepo = new DevelopersRepo();

        public void AddTeamToList(DevTeams team)
        {
            _listOfTeams.Add(team);
            
        }

        public bool AddDeveloperToTeam(Developers developer, string teamName)
        { 
            DevTeams teams = GetTeamByName(teamName);
            if (teams == null)
            {
                return false;
            }
           
            if (developer == null)
            {
                return false;
            }
            else
            {
                teams.listOfTeamMembers.Add(developer);

                return true;
            }
        }

        public List<DevTeams> GetTeamList()
        {
            return _listOfTeams;
        }

        public List<Developers> GetTeamMemberList()
        {
            return _listOfTeamMembers;
        }

        public bool UpdateExistingTeams(string originalTeam, DevTeams newteam)
        {

            DevTeams oldTeam = GetTeamByName(originalTeam);

            if (oldTeam != null)
            {
                oldTeam.TeamName = newteam.TeamName;
                oldTeam.TeamId = newteam.TeamId;

                return true;
            }
            else
            {
                return false;
            }
        }

            public bool RemoveTeamFromList(string teamName)
            {
                DevTeams team = GetTeamByName(teamName);

                if(teamName == null)
                {
                    return false;
                }

             int initialCount = _listOfTeams.Count;
             _listOfTeams.Remove(team);

                if(initialCount > _listOfTeams.Count)
                {
                return true;
                }
                else
                {
                return false;
                }


                
                    
            }

           public DevTeams GetTeamByName (string teamName)
           {
            foreach(DevTeams team in _listOfTeams)
            {
                if(team.TeamName.ToLower() == teamName)
                {
                    return team;
                }

               
            }
                    return null;
           }


    }
    }

