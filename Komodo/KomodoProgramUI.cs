using Developers_Repository;
using DevTeamsRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo
{
    class KomodoProgramUI
    {
        private DevelopersRepo _developersRepo = new DevelopersRepo();
        private DevTeamRepo _devTeamsRepo = new DevTeamRepo();
        private DevTeamRepo _teamMemberRepo = new DevTeamRepo();


        public void Run()
        {
            Menu();
        }

        public void Menu()
        {

            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("Select a menu option: \n" +
                    "1. Add new developer \n" +
                    "2. View all developers \n" +
                    "3. Update existing developer \n" +
                    "4. Remove a developer \n" +
                    "5. Add new team \n" +
                    "6. View all teams \n" +
                    "7. Update existing team \n"+
                    "8. Remove a team \n" + 
                    "9. Exit ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        UpdateDevelopers();
                        break;
                    case "4":
                        RemoveDeveloper();
                        break;
                    case "5":
                        CreateNewTeam();
                        break;
                    case "6":
                        ViewAllTeams();
                        break;
                    case "7":
                        UpdateTeams();
                        break;
                    case "8":
                        RemoveTeam();
                        break;
                    case "9":
                        Console.WriteLine("Goodbye");
                        KeepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            }

        public void CreateNewDeveloper()
        {
            Console.Clear();
            Developers newDeveloper = new Developers();

            Console.WriteLine("Enter the developer's name");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the developer's ID number");
            string idNumberString = Console.ReadLine();
            newDeveloper.IdNumber = double.Parse(idNumberString);

            Console.WriteLine("Does this developer have access to Pluralsight? y/n...");
            string pluralsightString = Console.ReadLine().ToLower();
            
            if(pluralsightString == "y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
                          
            }

            _developersRepo.AddDeveloperToList(newDeveloper);
        }

        public void CreateNewTeam()
        {
            Console.Clear();
            DevTeams newTeam = new DevTeams();

            Console.WriteLine("Enter team name");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter team ID");
            string teamIdString = Console.ReadLine();
            newTeam.TeamId = double.Parse(teamIdString);

            ViewAllDevelopers();
            Console.WriteLine("Enter the name of the developer you want to add..");
            string name = Console.ReadLine().ToLower();

            _devTeamsRepo.AddTeamToList(newTeam);
            Developers developer = _developersRepo.GetDeveloperByName(name);
            _devTeamsRepo.AddDeveloperToTeam(developer, newTeam.TeamName);


        }

        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developers> listOfDevelopers = _developersRepo.GetDeveloperList();

            foreach (Developers developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: { developer.Name}\n" +
                    $"ID Number: {developer.IdNumber}\n" +
                    $"Pluralsight Access: {developer.PluralsightAccess}");
            }
        }
        
        private void ViewAllTeams()
        {
            Console.Clear();
            List<DevTeams> listOfTeams = _devTeamsRepo.GetTeamList();
            List<Developers> listOfTeamMembers = _devTeamsRepo.GetTeamMemberList();

            foreach (DevTeams teams in listOfTeams)
            {
                Console.WriteLine($"Team Name: {teams.TeamName}\n" +
                    $"Team ID Number: {teams.TeamId}\n");

                foreach (Developers developer in teams.listOfTeamMembers)
                {
                    Console.WriteLine($"Developer's Name: {developer.Name}\n "+
                        $"Developer's ID: {developer.IdNumber}\n" +
                        $"Pluralsight Access: {developer.PluralsightAccess}");

                }
            }
            
        }

        private void UpdateDevelopers()
        {
            ViewAllDevelopers();

            Console.WriteLine("Enter the name of the developer you would like to update..");

            string oldName = Console.ReadLine().ToLower();

            Developers newDeveloper = new Developers();

            Console.WriteLine("Enter the name of the developer");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the developer's ID number");
            string idNumberAsString = Console.ReadLine();
            newDeveloper.IdNumber = double.Parse(idNumberAsString);

            Console.WriteLine("Does this developer have access to Pluralsight? Y/N..");
            string pluralsightString = Console.ReadLine().ToLower();

            if (pluralsightString == "Y")
            {
                newDeveloper.PluralsightAccess = true;
            }
            else
            {
                newDeveloper.PluralsightAccess = false;
               
            }

            bool wasUpdated = _developersRepo.UpdateExistingDevelopers(oldName, newDeveloper);

            if(wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Please try again");
            }
        }

        private void UpdateTeams()
        {
            ViewAllTeams();

            Console.WriteLine("Please enter the team you would like to update");

            string oldTeamName = Console.ReadLine().ToLower();

            DevTeams newTeam = new DevTeams();

            Console.WriteLine("Enter team name");
            newTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter team ID");
            string teamIdString = Console.ReadLine();
            newTeam.TeamId = double.Parse(teamIdString);

            ViewAllDevelopers();
            Console.WriteLine("Enter the developer's name you would like to add..");
            string name = Console.ReadLine().ToLower();

            _devTeamsRepo.AddTeamToList(newTeam);
            Developers developer = _developersRepo.GetDeveloperByName(name);
             _devTeamsRepo.AddDeveloperToTeam(developer, newTeam.TeamName);


            bool wasUpdated = _devTeamsRepo.UpdateExistingTeams(oldTeamName, newTeam);
          
                if(wasUpdated)
            {
                Console.WriteLine("Team was successfully updated!");
            }
                else
            {
                Console.WriteLine("Please try again..");
            }
        }

        private void RemoveDeveloper()
        {
            Console.Clear();

            ViewAllDevelopers();

            Console.WriteLine("Enter the developer you would like to remove..");

            string input = Console.ReadLine().ToLower();

            bool wasDeleted = _developersRepo.RemoveDeveloperFromList(input);
            
            if(wasDeleted)
            {
                Console.WriteLine("Developer was successfully removed!");
            }
            else
            {
                Console.WriteLine("Please try again..");
            }

        }

        private void RemoveTeam()
        {
            Console.Clear();
            ViewAllTeams();
            Console.WriteLine("Enter the team you would like to remove..");

            string input = Console.ReadLine().ToLower();

            bool wasDeleted = _devTeamsRepo.RemoveTeamFromList(input);

            if(wasDeleted)
            {
                Console.WriteLine("Team was successfully removed!");
            }
            else
            {
                Console.WriteLine("Please try again..");
            }
        }
    }
    }

