using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ChatContext _dbContext;

        public EfUnitOfWork(ChatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
