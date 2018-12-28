using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ViewModels
{
    public class MessageListViewModel
    {
        public MessageListViewModel()
        {
            Messages = new List<MessageListItemViewModel>();
            ImageKeys = new List<string>();
            SendModel = new SendMessageViewModel();
        }

        public IEnumerable<MessageListItemViewModel> Messages { get; set; }
        public IEnumerable<string> ImageKeys { get; set; }
        public SendMessageViewModel SendModel { get; set; } 
    }
}
