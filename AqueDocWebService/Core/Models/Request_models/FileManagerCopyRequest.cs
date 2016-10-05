using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Класс, описывающий запрос на перемещение 
    /// файлов/папок
    /// </summary>
    public class FileManagerCopyRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public List<string> Items { get; set; }
        public string NewPath { get; set; }
        public string SingleFilename {get; set;}

        public FileManagerCopyRequest(string action, List<string> items,
            string newPath, string singleFilename)
            : base(action)
        {
            Action = action;
            Items = items;
            NewPath = newPath;
            SingleFilename = singleFilename;
        }
    }
}