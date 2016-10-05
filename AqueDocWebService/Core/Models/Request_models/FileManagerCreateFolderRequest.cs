using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Класс, описывающий запрос на переименование
    /// </summary>
    public class FileManagerCreateFolderRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public string NewPath { get; set; }

        public FileManagerCreateFolderRequest(string action, string newPath)
            : base(action)
        {
            Action = action;
            NewPath = newPath;
        }
    }
}