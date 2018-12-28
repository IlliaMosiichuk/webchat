using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Interfaces
{
    public interface IImageService
    {
        IEnumerable<string> GetAllImageKeys();

        string ReplaceTextWithImages(string text);
    }
}
