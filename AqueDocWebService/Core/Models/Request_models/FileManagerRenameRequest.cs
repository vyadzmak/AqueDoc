using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Класс, описывающий запрос на переименование
    /// </summary>
    public class FileManagerRenameRequest : FileManagerRequest
    {
        public string Action {get; set;}
        public string Item {get; set;}
        public string NewItemPath { get; set; }

        public FileManagerRenameRequest(string action, string item, 
            string newItemPath) : base(action)
        {
            Action = action;
            Item = item;
            NewItemPath = newItemPath;
        }
    }
}