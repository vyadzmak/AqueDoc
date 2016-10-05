using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Класс, описывающий запрос на 
    /// изменение прав доступа
    /// файлов/папок
    /// </summary>
    public class FileManagerChangePermissionsRequest : FileManagerRequest
    {
        public string Action { get; set; }
        public List<string> Items { get; set; }
        public string Perms { get; set; }
        public string PermsCode { get; set; }
        public bool Recursive { get; set; }

        public FileManagerChangePermissionsRequest(string action, List<string> items,
            string perms, string permsCode, bool recursive)
            : base(action)
        {
            Action = action;
            Items = items;
            Perms = perms;
            PermsCode = permsCode;
            Recursive = recursive;
        }
    }
}