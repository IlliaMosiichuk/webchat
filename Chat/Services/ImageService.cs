using ApplicationCore.Interfaces;
using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Services
{
    public class ImageService : IImageService
    {
        private const string _imageTemplate = "<img style='width:30px; height:30px' src='/images/{0}'>";

        private readonly Dictionary<string, string> _imagePathDictionary = new Dictionary<string, string>()
        {
            { ">:-(", "3.png" },
            { "&-<", "5.png" },
            { ">:-<", "6.png" },
            { ":-)", "1.png" },
            { ":-(", "2.png" },
            { ":-<", "4.png" },
        };

        public IEnumerable<string> GetAllImageKeys()
        {
            return _imagePathDictionary.Keys.ToList();
        }

        public string ReplaceTextWithImages(string text)
        {
            foreach (var key in _imagePathDictionary.Keys.Where(k => text.Contains(k)))
            {
                var image = string.Format(_imageTemplate, _imagePathDictionary[key]);
                text = text.Replace(key, image);
            }
            return text;
        }
    }
}
