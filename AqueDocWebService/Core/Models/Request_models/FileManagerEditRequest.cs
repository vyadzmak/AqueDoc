using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    public class FileManagerEditRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public string Item { get; set; }
        public string Content { get; set; }
        public FileManagerEditRequest(string action, string item, string content) 
            : base(action)
        {
            Action = action;
            Item = item;
            Content = content;
        }
    }
}