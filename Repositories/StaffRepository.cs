using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class StaffRepository
    {
        public static int CurrentStaffID { get; set; }
        private static AgencyModel model = new AgencyModel();
        public static IEnumerable<Staff> GetAllStaff()
        {
            var list = model.Staff;
            return list;
        }

        public static Staff GetStaffByID(int id)
        {
            var staff = model.Staff.Where(x => x.ID == id);
            if (staff.Any())
            {
                return staff.First();
            }
            else
            {
                return null;
            }
        }

        public static void AddStaff(Staff staff)
        {
            model.Staff.Add(staff);
            model.SaveChanges();
        }
        public static void EditStaff()
        {
            model.SaveChanges();
        }

        public static void Unlock(int id)
        {
            var staff = model.Staff.Where(x => x.ID == id).First();
            staff.IsExists = 1;
            model.SaveChanges();
        }
        public static void Lock(int id)
        {
            var staff = model.Staff.Where(x => x.ID == id).First();
            staff.IsExists = 0;
            model.SaveChanges();
        }

        public static IEnumerable<Staff> SearchAllStaffWithoutPlace(string fullName)
        {
            var list = model.Staff
                    .Where(
                        x => x.FullName.Contains(fullName));
            return list;
        }
        public static IEnumerable<Staff> SearchAllStaffWithPlace(byte role, string fullName)
        {
            var list = model.Staff
                    .Where(
                        x => x.IsAdmin == role
                        && x.FullName.Contains(fullName));
            return list;
        }
        public static IEnumerable<Staff> SearchStaffWithoutPlace(string fullName, int existing)
        {
            var list = model.Staff
                    .Where(
                        x => x.FullName.Contains(fullName)
                        && x.IsExists == existing);
            return list;
        }
        public static IEnumerable<Staff> SearchStaffWithPlace(byte role, string fullName, int existing)
        {
            var list = model.Staff
                    .Where(
                        x => x.IsAdmin == role
                        && x.FullName.Contains(fullName)
                        && x.IsExists == existing);
            return list;
        }
    }
}