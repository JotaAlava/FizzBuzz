using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexOffersFizzBuzz.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private UltiDashDbEntities1 context;
        private GenericRepository<Operation> teamRepository;

        /// <summary>
        /// This is the only class that should "new" the UltiDashDbEntities1.
        /// </summary>
        /// <param name="connectionString"> The connection string to the SQL Db </param>
        public DataManager(string connectionString)
        {
            this.context = new UltiDashDbEntities1(connectionString);
        }

        /// <summary>
        /// This is the only class that should "new" the UltiDashDbEntities1.
        /// If no connection string is passed then the production Db connection string will be used.
        /// </summary>
        public DataManager()
        {
            this.context = new UltiDashDbEntities1("UltiDashDbEntities1");
        }

        /// <summary>
        /// This constructor is used for testing purposes. The data manager receives a child of the main
        /// context class that has access to a quick erase Db method.
        /// </summary>
        public DataManager(UltiDashDbEntities1 contextForTestingONLY)
        {
            this.context = contextForTestingONLY;
        }

        public GenericRepository<Team> TeamRepository
        {
            get
            {
                if (this.teamRepository == null)
                {
                    this.teamRepository = new GenericRepository<Team>(context);
                }
                return teamRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}