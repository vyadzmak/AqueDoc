using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Класс, описывающий запрос на удаление 
    /// файлов/папок
    /// </summary>
    public class FileManagerRemoveRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public List<string> Items { get; set; }

        public FileManagerRemoveRequest(string action, List<string> items)
            : base(action)
        {
            Action = action;
            Items = items;
        }
    }
}