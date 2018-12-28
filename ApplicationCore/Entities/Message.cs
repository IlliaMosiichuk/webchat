using System;
namespace ApplicationCore.Entities
{
    public class Message : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
