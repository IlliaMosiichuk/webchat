using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ViewModels
{
    public class MessageListItemViewModel
    {
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
