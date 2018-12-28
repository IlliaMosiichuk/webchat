using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class MessageRepository : EfRepository<Message>, IMessageRepository
    {
        public MessageRepository(ChatContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Message> GetLastMessages()
        {
            return _dbContext.Messages.Include(m => m.User)
                .OrderByDescending(m => m.CreatedDate)
                .Take(10)
                .OrderBy(m => m.CreatedDate)
                .ToList();
        }
    }
}
