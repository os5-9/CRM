using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class StaffRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static List<Staff> GetAllStaff()
        {
            var list = model.Staff
                .Where(x => x.IsExists == 1)
                .ToList();
            return list;
        }

        public static List<Staff> SearchStaffWithoutPlace(string fullName)
        {
            var list = model.Staff
                    .Where(
                        x => x.FullName.Contains(fullName)
                        && x.IsExists == 1
                    )
                    .ToList();
            return list;
        }

        public static List<Staff> SearchStaffWithPlace(byte role, string fullName)
        {
            var list = model.Staff
                    .Where(
                        x => x.IsAdmin == role
                        && x.FullName.Contains(fullName)
                        && x.IsExists == 1
                    )
                    .ToList();
            return list;
        }
    }
}
