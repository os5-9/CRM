using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class TourRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static int Procent { get; set; }

        public static IEnumerable<Tours> GetAllTours()
        {
            var list = model.Tours.Where(x => x.IsExists == 1 && x.IsApproved == 1);
            return list;
        }
        public static IEnumerable<Tours> GetAllNotApprovedTours()
        {
            var list = model.Tours.Where(x => x.IsExists == 1 && x.IsApproved == 0);
            return list;
        }

        public static void ApproveTour(int id, int procent)
        {
            var tour = model.Tours.Where(x => x.ID == id).First();
            tour.IsApproved = 1;
            tour.Price = tour.Price + (tour.Price * procent) / 100;
            model.SaveChanges();
        }
        public static void DismissTour(int Id)
        {
            var tour = model.Tours.Where(x => x.ID == Id).First();
            tour.IsApproved = 2;
            model.SaveChanges();
        }

        public static IEnumerable<Tours> SearchTour(string status, string type, string city, string country, int price, DateTime arrivalS, DateTime arrivalF, DateTime departureS, DateTime departureF)
        {
            var list = model.Tours
                    .Where(x => x.IsExists == 1 && x.TourStates.Name.Contains(status)
                        && x.TourType.Name.Contains(type) && x.City.Contains(city)
                        && x.Country.Contains(country) && x.Price == price
                        && (x.Arrival >= arrivalS && x.Arrival <= arrivalF) && (x.Departure >= departureS && x.Departure <= departureF));
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
            var list = tours.Where(x => x.City.ToLower().Contains(city.ToLower()));
            return list;
        }
        public static IEnumerable<Tours> SearchTourCountry(IEnumerable<Tours> tours, string country)
        {
            var list = tours.Where(x => x.Country.ToLower().Contains(country.ToLower()));
            return list;
        }
        public static IEnumerable<Tours> SearchTourPrice(IEnumerable<Tours> tours, int price)
        {
            var list = tours.Where(x => x.Price <= price);
            return list;
        }
        public static IEnumerable<Tours> SearchTourarrivalal(IEnumerable<Tours> tours, DateTime arrivalS, DateTime arrivalF)
        {
            var list = tours.Where(x => (x.Arrival >= arrivalS && x.Arrival <= arrivalF));
            return list;
        }
        public static IEnumerable<Tours> SearchTourdepartureture(IEnumerable<Tours> tours, DateTime departureS, DateTime departureF)
        {
            var list = tours.Where(x => (x.Departure >= departureS && x.Departure <= departureF));
            return list;
        }
    }
}
