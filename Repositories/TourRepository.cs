using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class TourRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static IEnumerable<Tours> GetAllTours()
        {
            var list = model.Tours
                .Where(x => x.IsExists == 1)
                ;
            return list;
        }

        public static IEnumerable<Tours> SearchTour(string status, string type, string city, string country, int price,DateTime arrivS, DateTime arrivF, DateTime deparS, DateTime deparF)
        {
            var list = model.Tours
                    .Where(x => x.IsExists == 1 && x.TourStates.Name.Contains(status)
                        && x.TourType.Name.Contains(type) && x.City.Contains(city)
                        && x.Country.Contains(country) && x.Price == price
                        && (x.Arrival >= arrivS && x.Arrival <= arrivF) && (x.Departure >= deparS && x.Departure <= deparF));
            return list;
        }
        public static IEnumerable<Tours> SearchTourStatus(IEnumerable<Tours> tours, string status)
        {
            var list = tours.Where(x => x.TourStates.Name.Contains(status));
            return list;
        }
        public static IEnumerable<Tours> SearchTourType(IEnumerable<Tours> tours, string type)
        {
            var list = tours.Where(x => x.TourType.Name.Contains(type));
            return list;
        }
        public static IEnumerable<Tours> SearchTourCity(IEnumerable<Tours> tours, string city)
        {
            int cityLenght = city.Length;
            var cityModified = city.Substring(0, 1).ToUpper() + city.Substring(1, cityLenght - 1);
            var list = tours.Where(x => x.City.Contains(cityModified));
            return list;
        }
        public static IEnumerable<Tours> SearchTourCountry(IEnumerable<Tours> tours, string country)
        {
            int countryLenght = country.Length;
            var countryModified = country.Substring(0, 1).ToUpper() + country.Substring(1, countryLenght- 1);
            var list = tours.Where(x => x.Country.Contains(countryModified));
            return list;
        }
        public static IEnumerable<Tours> SearchTourPrice(IEnumerable<Tours> tours, int price)
        {
            var list = tours.Where(x => x.Price <= price);
            return list;
        }
        public static IEnumerable<Tours> SearchTourArrival(IEnumerable<Tours> tours, DateTime arrivS, DateTime arrivF)
        {
            var list = tours.Where(x => (x.Arrival >= arrivS && x.Arrival <= arrivF));
            return list;
        }
        public static IEnumerable<Tours> SearchTourDeparture(IEnumerable<Tours> tours, DateTime deparS, DateTime deparF)
        {
            var list = tours.Where(x => (x.Departure >= deparS && x.Departure <= deparF));
            return list;
        }
    }
}
