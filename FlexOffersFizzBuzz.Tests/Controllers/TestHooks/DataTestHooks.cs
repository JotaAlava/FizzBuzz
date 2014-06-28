using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexOffersFizzBuzz.Tests.Controllers.TestHooks
{
    internal static class DataTestHooks
    {
        internal static void RollBackDb()
        {
            var context = new EFTestHookContext("FlexOffersFizzBuzzTestDb");
            context.DeleteAllEntriesInDb();
        }
    }
}
