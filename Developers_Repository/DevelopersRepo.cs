using System;
using System.Collections.Generic;
using System.Text;

namespace Developers_Repository
{
    public class DevelopersRepo
    {
        private List<Developers> _listOfDevelopers = new List<Developers>();

        public void AddDeveloperToList(Developers developer)
        {
            _listOfDevelopers.Add(developer);
        }

        public List<Developers> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        public bool UpdateExistingDevelopers(string originalDeveloper, Developers newDeveloper)
        {
            Developers oldDeveloper = GetDeveloperByName(originalDeveloper);

            if(oldDeveloper != null)
            {
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.IdNumber = newDeveloper.IdNumber;
                oldDeveloper.PluralsightAccess = newDeveloper.PluralsightAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveDeveloperFromList(string name)
        {
            Developers developer = GetDeveloperByName(name);

            if(developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Developers GetDeveloperByName(string name)
        {
            foreach (Developers developer in _listOfDevelopers)
            {
                if(developer.Name.ToLower() == name)
                {
                    return developer;
                }

            }

            return null;
                        
        }
    }
}
