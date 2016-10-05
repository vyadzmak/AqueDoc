using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    public class FileManagerDownloadFileRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public string Path { get; set; }

        public FileManagerDownloadFileRequest(string action, string path)
            : base(action)
        {
            Action = action;
            Path = path;
        }
    }
}
