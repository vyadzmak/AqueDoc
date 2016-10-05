using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Конкретный класс, описывающий запрос на получение списка
    /// </summary>
    public class FileManagerListRequest : FileManagerRequest
    {
        public string Action;
        public string Path;
        
        public FileManagerListRequest(string action, string path) : base (action)
        {
            Action = action;
            Path = path;
        }
    }
}