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
    public class FileManagerMoveRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public List<string> Items { get; set; }
        public string NewPath { get; set; }

        public FileManagerMoveRequest(string action, List<string> items, 
            string newPath)
            : base(action)
        {
            Action = action;
            Items = items;
            NewPath = newPath;
        }
    }
}