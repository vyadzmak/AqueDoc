using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqueDocWebService.Core.Models.Request_models
{
    /// <summary>
    /// Абстрактный класс, описывающий 
    /// формализованный запрос от клиента
    /// </summary>
    public abstract class FileManagerRequest
    {
        #region Поля

        /// <summary>
        /// Поле, описывающее действие,
        /// которого требует запрос
        /// </summary>
        public string Action;

        /// <summary>
        /// Путь, описывающий место действия 
        /// запроса в файловой системе
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Путь к объекту, над которым совершается действие
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Новый путь к объекту, который будет создан
        /// </summary>
        public string NewItemPath { get; set; }

        /// <summary>
        /// Множество имён объектов, над которыми
        /// будет совершены действия
        /// </summary>
        public List<string> Items { get; set; }

        /// <summary>
        /// Новый путь, который должен быть 
        /// создан в результате действия
        /// </summary>
        public string NewPath { get; set; }

        /// <summary>
        /// Имя файла, которое должно
        /// быть принято в результате операции
        /// </summary>
        public string SingleFilename { get; set; }

        /// <summary>
        /// Содержание файла
        /// ???
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Какой-то код для установки прав
        /// </summary>
        public string Permissions { get; set; }

        /// <summary>
        /// Буквенный код, rwx-код, описывающий
        /// права доступа к файлу
        /// </summary>
        public string PermissionsCode { get; set; }

        /// <summary>
        /// Флаг рекурсивности
        /// ???
        /// </summary>
        public bool Recursive { get; set; }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="action"></param>
        public FileManagerRequest(string action)
        {
            Action = action;
        }

       

    }
}
