using System.Linq;
using FlexOffersFizzBuzz.Models;

namespace FlexOffersFizzBuzz.Tests.Controllers.TestHooks
{
    public class EFTestHookContext : FlexOffersFizzBuzzModelContainer
    {
        public EFTestHookContext(string connectionString)
            : base(connectionString)
        {

        }

        internal void DeleteAllEntriesInDb()
        {
            this.DeleteAllTypes();
            this.DeleteAllOperationHistory();
        }

        internal void DeleteAllOperationHistory()
        {
            var allOperationsPerformed = from operation in Operations select operation;
            if (allOperationsPerformed != null)
            {
                Operations.RemoveRange(allOperationsPerformed);
            }
            SaveChanges();
        }

        internal void DeleteAllTypes()
        {
            var allTeams = from type in Types select type;
            if (allTeams != null)
            {
                Types.RemoveRange(allTeams);
            }
            SaveChanges();
        }
    }
}
