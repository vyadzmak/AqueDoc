using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    /// <summary>
    /// Класс, описывающий сообщение, отправляемое клиенту
    /// при успешном выполнении операций переименования, удаления и проч.
    /// </summary>
    public class ResultContent
    {
        /// <summary>
        /// true, если все прошло успешно,
        /// очевидно же
        /// </summary>
        public bool success;

        /// <summary>
        /// поле, содержащее текст ошибки
        /// </summary>
        public string error;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="success"></param>
        /// <param name="error"></param>
        public ResultContent(bool success, string error)
        {
            this.success = success;
            this.error = error;
        }
    }
}