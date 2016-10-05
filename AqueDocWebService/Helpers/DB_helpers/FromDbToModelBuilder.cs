using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;

namespace AqueDocWebService.Helpers.DB_helpers
{
    /// <summary>
    /// Класс предоставляет методы для работы
    /// с деревом документа XML через модели
    /// </summary>
    public class FromDbToModelBuilder
    {
        /// <summary>
        /// Возвращает элемент исходя из 
        /// заданного атрибута имени
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns></returns>
        public XElement ChooseElementByName(XDocument xDocument, string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    throw new ArgumentNullException();
                }

                string[] separatedPathItems = path.Split('/');

                XElement xElement = xDocument.Element("root");
                XElement extractedElement = null;

                for (int i = 1; i < separatedPathItems.Length; i++)
                {
                    if (separatedPathItems[i] != "")
                    {
                        extractedElement = xElement.Elements()
                            .Where(x => x.Attribute("name")
                                .Value == separatedPathItems[i]).Select(x => x).LastOrDefault();

                        if (extractedElement == null)
                        {
                            break;
                        }
                        else
                        {
                            xElement = extractedElement;
                        }
                    }
                }

                return xElement;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Делает выборку по потомком данного элемента
        /// с построением модели
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private List<Core.Models.Node> CollectList(XElement element)
        {
            try
            {
                return element.Elements("node")
                    .Select(n => new Core.Models.Node
                    {
                        name = n.Attribute("name").Value,
                        rights = n.Attribute("rights").Value,
                        size = n.Attribute("size").Value,
                        date = n.Attribute("date").Value,
                        type = n.Attribute("type").Value
                    }).ToList();
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Построение дерева для показа на клиенте.
        /// ВМЕСТЕ С КОРНЕМ ДЕРЕВО ГЛУБИНОЙ 2!
        /// </summary>
        /// <param name="path"> 
        /// Это полный путь (от корня) к интересующей нас папке
        /// или файлу 
        /// </param>
        /// <returns></returns>
        public Core.Models.NodesTree BuildTree(XDocument xDocument, string path)
        {
            // Тут получаем узел, от которого строим дерево
            XElement chosenElement = ChooseElementByName(xDocument, path);

            // Если ничего подходящего не нашли.
            // Хотя такого быть не должно.
            if (chosenElement == null)
            {
                return null;
            }

            Core.Models.NodesTree tree = new Core.Models.NodesTree();
            tree.Tree = CollectList(chosenElement);

            return tree;

        }
    }
}
