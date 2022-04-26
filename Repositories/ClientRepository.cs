using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class ClientRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static List<Clients> GetAllClients()
        {
            var list = model.Clients
                .Where(x => x.IsExists == 1)
                .ToList();
            return list;
        }

        public static List<Clients> SearchClientWithoutGender(string fullName)
        {
            var list = model.Clients
                    .Where(
                        x => x.FullName.Contains(fullName)
                        && x.IsExists == 1
                    )
                    .ToList();
            return list;
        }

        public static List<Clients> SearchClientWithGender(string gender, string fullName)
        {
            var list = model.Clients
                    .Where(
                        x => x.Gender == gender
                        && x.FullName.Contains(fullName)
                        && x.IsExists == 1
                    )
                    .ToList();
            return list;
        }
    }
}
