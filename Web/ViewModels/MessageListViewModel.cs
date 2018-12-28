using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class MessageListViewModel
    {
        public MessageListViewModel()
        {
            Messages = new List<MessageListItemViewModel>();
        }

        public IEnumerable<MessageListItemViewModel> Messages { get; set; }
        public SendMessageViewModel CreateModel { get; set; } = new SendMessageViewModel();
    }
}
