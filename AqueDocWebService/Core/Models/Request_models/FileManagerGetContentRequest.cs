using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    public class FileManagerGetContentRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public string Item { get; set;}
        public FileManagerGetContentRequest(string action, string item) : base (action)
        {
            Action = action;
            Item = item;
        }
    }
}