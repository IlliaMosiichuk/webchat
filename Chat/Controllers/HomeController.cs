using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Chat.Hubs;
using Chat.Interfaces;
using Chat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageService _messageService;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IImageService _imageService;

        public HomeController(IMessageRepository messageRepository, IMessageService messageService, 
            IHubContext<ChatHub> hubContext, IImageService imageService)
        {
            _messageRepository = messageRepository;
            _messageService = messageService;
            _hubContext = hubContext;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var messages = _messageRepository.GetLastMessages();

            var viewModel = new MessageListViewModel()
            {
                Messages = messages.Select(m => new MessageListItemViewModel()
                {
                    Text = _imageService.ReplaceTextWithImages(m.Text),
                    UserName = m.User.Name,
                }),
                ImageKeys = _imageService.GetAllImageKeys(),
            };

            return View(viewModel);
        }

        public async Task<ActionResult> SendMessage(SendMessageViewModel model)
        {
            string errorMessage = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    _messageService.ProcessMessage(model.Text, model.UserName);
                    var replacedText = _imageService.ReplaceTextWithImages(model.Text);
                    await _hubContext.Clients.All.SendAsync("Receive", model.UserName, replacedText);
                    return Ok();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }

            return BadRequest(errorMessage);
        }
    }
}
