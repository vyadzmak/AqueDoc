using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    /// <summary>
    /// Класс Node.
    /// </summary>
    public class Node
    {
        public string name;
        public string rights;
        public string size;
        public string date;
        public string type;

        public Node(string name, string rights, string size,
            string date, string type)
        {
            this.name = name;
            this.rights = rights;
            this.size = size;
            this.date = date;
            this.type = type;
        }

        public Node()
        {
            // TODO: Complete member initialization
        }
    }
}