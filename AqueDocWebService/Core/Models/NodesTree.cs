using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    /// <summary>
    /// Структура, содержащая список файлов на 
    /// данном уровне
    /// </summary>
    public class NodesTree
    {
        public List<Node> Tree;

        #region конструкторы
        public NodesTree(List<Node> tree)
        {
            Tree = tree;
        }

        public NodesTree()
        {
            Tree = new List<Node>();
        }

        #endregion
    }
}