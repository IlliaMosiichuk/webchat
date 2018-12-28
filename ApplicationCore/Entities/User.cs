using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public List<Message> Messages { get; set; }
    }
}
