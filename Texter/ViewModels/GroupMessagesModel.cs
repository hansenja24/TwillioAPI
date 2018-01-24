using Texter.Models;
using System.Collections.Generic;

namespace Texter.ViewModels
{
    public class GroupMessagesModel
    {
        public Message Message { get; set; }
        public List<string> Contacts { get; set; } = new List<string>() { };

    }
}