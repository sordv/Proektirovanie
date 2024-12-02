using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class UserController
    {
        private readonly CountriesRepository _countriesRepository;

        public UserController()
        {
            _countriesRepository = new CountriesRepository();
        }

        public List<string> GetCountries()
        {
            return _countriesRepository.GetCountries();
        }

        public Roadmap GenerateRoadmap(string country, bool isHighlyQualified, bool isRelocationParticipant)
        {
            var roadmap = new Roadmap
            {
                Country = country,
                IsHighlyQualified = isHighlyQualified,
                IsRelocationParticipant = isRelocationParticipant
            };

            roadmap.DeterminePatentRequirement();
            roadmap.GenerateSteps();

            return roadmap;
        }
    }
}
