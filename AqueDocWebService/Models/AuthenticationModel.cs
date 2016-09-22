using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Models
{
    /// <summary>
    /// модель авторизации
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// признак авторизации
        /// </summary>
        public bool IsAuthorized { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }
    }
}