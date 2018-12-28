using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Web.Hubs;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(IMessageRepository messageRepository, IMessageService messageService)
        {
            _messageRepository = messageRepository;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var messages = _messageRepository.GetLastMessages();

            var viewModel = new MessageListViewModel()
            {
                Messages = messages.Select(m => new MessageListItemViewModel()
                {
                    Text = m.Text,
                    UserName = m.User.Name,
                }),
            };

            return View(viewModel);
        }

        public async Task<ActionResult> SendMessage(SendMessageViewModel model)
        {
            _messageService.ProcessMessage(model.Text, model.UserName);
            await _hubContext.Clients.All.SendAsync("Receive", model.UserName, model.Text);
            return Ok();
        }
    }
}
