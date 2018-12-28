using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Web.Hubs;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ChatController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IMessageRepository messageRepository, IMessageService messageService, IHubContext<ChatHub> hubContext)
        {
            _messageRepository = messageRepository;
            _messageService = messageService;
            _hubContext = hubContext;
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

        [HttpPost]
        public async Task<ActionResult> SendMessage(SendMessageViewModel model)
        {
            _messageService.ProcessMessage(model.Text, model.UserName);
            await _hubContext.Clients.All.SendAsync("Receive", model);
            return Ok();
        }
    }
}