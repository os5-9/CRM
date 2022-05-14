using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static List<Tours> SearchTour(string status, string type, string city, string country, int price, DateTime arrivS, DateTime arrivF, DateTime deparS, DateTime deparF)
        {
            var list = model.Tours
                    .Where(
                        x => x.IsExists == 1
                        && x.TourStates.Name.Contains(status)
                        && x.TourType.Name.Contains(type)
                        && x.City.Contains(city)
                        && x.Country.Contains(country)
                        && x.Price == price
                        //&& (x.Arrival >= arrivS || x.Arrival <= arrivF)
                        //&& (x.Departure >= deparS || x.Departure <= deparF)
                    )
                    .ToList();
            return list;
        }
    }
}
