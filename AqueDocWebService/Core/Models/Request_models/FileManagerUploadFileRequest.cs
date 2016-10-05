using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    public class FileManagerUploadFileRequest : FileManagerRequest
    {
         public string Action { get; set; }
         public Dictionary<Guid, List<string>> Items { get; set; }
         public string Path { get; set; }

         public FileManagerUploadFileRequest(string action, Dictionary<Guid, List<string>> items, string path)
            : base(action)
        {
            Action = action;
            Items = items;
            Path = path;
        }
    }
}
