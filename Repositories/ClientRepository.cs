using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class ClientRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static IEnumerable<Clients> GetAllClients()
        {
            var list = model.Clients
                .Where(x => x.IsExists == 1);
            return list;
        }

        public static void AddClient(Clients client)
        {
            model.Clients.Add(client);
            model.SaveChanges();
        }
        public static void EditClient()
        {
            model.SaveChanges();
        }

        public static IEnumerable<Clients> SearchClientWithoutGender(string fullName)
        {
            var list = model.Clients
                    .Where(
                        x => x.FullName.Contains(fullName)
                        && x.IsExists == 1);
            return list;
        }

        public static IEnumerable<Clients> SearchClientWithGender(string gender, string fullName)
        {
            var list = model.Clients
                    .Where(
                        x => x.Gender == gender
                        && x.FullName.Contains(fullName)
                        && x.IsExists == 1);
            return list;
        }
    }
}
