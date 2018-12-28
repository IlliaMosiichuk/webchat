using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ChatContext dbContext) : base(dbContext)
        {
        }

        public User GetByName(string name)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Name == name);
        }
    }
}
