using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string name);
    }
}
