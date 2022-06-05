using System.Collections.Generic;
using System.Linq;
using TravelAgencyCRM.Models;

namespace TravelAgencyCRM.Repositories
{
    public static class OperatorRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static IEnumerable<Operators> GetAllOperators()
        {
            var list = model.Operators
                .Where(x => x.IsDenied == 1);
            return list;
        }

        public static IEnumerable<Operators> GetAllWaitingOperators()
        {
            var list = model.Operators
                .Where(x => x.IsDenied == 0);
            return list;
        }

        public static void ApproveOperator(int Id)
        {
            var operat = model.Operators.Where(x => x.ID == Id).First();
            operat.IsDenied = 1;
            model.SaveChanges();
        }

        public static void DismissOperator(int Id)
        {
            var operat = model.Operators.Where(x => x.ID == Id).First();
            operat.IsDenied = 2;
            model.SaveChanges();
        }
    }
}
