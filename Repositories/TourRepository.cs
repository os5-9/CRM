using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class TourRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static List<Tours> GetAllTours()
        {
            var list = model.Tours
                .Where(x => x.IsExists == 1)
                .ToList();
            return list;
        }

        public static List<Tours> SearchTour(string status, string type, string city, string country, int price,DateTime arrivS, DateTime arrivF, DateTime deparS, DateTime deparF)
        {
            var list = model.Tours
                    .Where(x => x.IsExists == 1 && x.TourStates.Name.Contains(status)
                        && x.TourType.Name.Contains(type) && x.City.Contains(city)
                        && x.Country.Contains(country) && x.Price == price
                        && (x.Arrival >= arrivS && x.Arrival <= arrivF) && (x.Departure >= deparS && x.Departure <= deparF)).ToList();
            return list;
        }
        public static List<Tours> SearchTourStatus(List<Tours> tours, string status)
        {
            var list = tours
                    .Where(x => x.TourStates.Name.Contains(status))
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourType(List<Tours> tours, string type)
        {
            var list = tours
                    .Where(x => x.TourType.Name.Contains(type))
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourCity(List<Tours> tours, string city)
        {
            int cityLenght = city.Length;
            var cityModified = city.Substring(0, 1).ToUpper() + city.Substring(1, cityLenght - 1);
            var list = tours
                    .Where(x => x.City.Contains(cityModified))
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourCountry(List<Tours> tours, string country)
        {
            int countryLenght = country.Length;
            var countryModified = country.Substring(0, 1).ToUpper() + country.Substring(1, countryLenght- 1);
            var list = tours
                    .Where(x => x.Country.Contains(countryModified))
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourPrice(List<Tours> tours, int price)
        {
            var list = tours
                    .Where(x => x.Price <= price)
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourArrival(List<Tours> tours, DateTime arrivS, DateTime arrivF)
        {
            var list = tours
                    .Where(x => (x.Arrival >= arrivS && x.Arrival <= arrivF))
                    .ToList();
            return list;
        }
        public static List<Tours> SearchTourDeparture(List<Tours> tours, DateTime deparS, DateTime deparF)
        {
            var list = tours
                    .Where(x => (x.Departure >= deparS && x.Departure <= deparF))
                    .ToList();
            return list;
        }
    }
}
