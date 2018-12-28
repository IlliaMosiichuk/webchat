using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork, IMessageRepository messageRepository, 
            IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }


        public void ProcessMessage(string text, string userName)
        {
            var user = _userRepository.GetByName(userName);
            if (user == null)
            {
                user = new User()
                {
                    Name = userName,
                };
                _userRepository.Add(user);
            }

            var message = new Message()
            {
                Text = text,
                User = user,
                CreatedDate = DateTime.Now,
            };
            _messageRepository.Add(message);

            _unitOfWork.Commit();
        }
    }
}
