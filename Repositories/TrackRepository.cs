using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class TrackRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static IEnumerable<Track> GetAllTrack()
        {
            var list = model.Track
                .Where(x => x.IsExists == 1);
            return list;
        }
    }
}
