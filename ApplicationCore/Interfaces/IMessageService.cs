using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMessageService
    {
        void ProcessMessage(string text, string userName);
    }
}
