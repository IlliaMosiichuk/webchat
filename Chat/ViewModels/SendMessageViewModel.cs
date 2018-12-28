using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.ViewModels
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "The Text field is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string UserName { get; set; }
    }
}
