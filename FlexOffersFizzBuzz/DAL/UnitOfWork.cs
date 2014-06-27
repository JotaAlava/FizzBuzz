using System;
using FlexOffersFizzBuzz.Models;

namespace FlexOffersFizzBuzz.DAL.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private FlexOffersFizzBuzzModelContainer context;
        private GenericRepository<Operation> operationRepository;

        /// <summary>
        /// This is the only class that should "new" the FlexOffersFizzBuzzModelContainer.
        /// </summary>
        /// <param name="connectionString"> The connection string to the SQL Db </param>
        public UnitOfWork(string connectionString)
        {
            this.context = new FlexOffersFizzBuzzModelContainer(connectionString);
        }

        /// <summary>
        /// This is the only class that should "new" the FlexOffersFizzBuzzModelContainer.
        /// If no connection string is passed then the production Db connection string will be used.
        /// </summary>
        public UnitOfWork()
        {
            this.context = new FlexOffersFizzBuzzModelContainer("FlexOffersFizzBuzzModelContainer");
        }

        /// <summary>
        /// This constructor is used for testing purposes. The data manager receives a child of the main
        /// context class that has access to a quick erase Db method.
        /// </summary>
        public UnitOfWork(FlexOffersFizzBuzzModelContainer contextForTestingONLY)
        {
            this.context = contextForTestingONLY;
        }

        public GenericRepository<Operation> TeamRepository
        {
            get
            {
                if (this.operationRepository == null)
                {
                    this.operationRepository = new GenericRepository<Operation>(context);
                }
                return operationRepository;
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

    public interface IUnitOfWork
    {
        
    }
}