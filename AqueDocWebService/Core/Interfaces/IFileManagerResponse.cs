using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AqueDocWebService.Core.Models;

namespace AqueDocWebService.Core.Interfaces
{
    /// <summary>
    /// Интерфейс, который реализуют классы, 
    /// описывающие ответы сервера
    /// </summary>
    public interface IFileManagerResponse
    {
        /// <summary>
        /// Перегруженный метод, создающий объект ответа
        /// сервера, описывающий список файлов и папок.
        /// </summary>
        /// <param name="tree"></param>
        void SetResult(NodesTree tree);

        /// <summary>
        /// Перегруженный метод, создающий объект ответа
        /// сервера об успешности операции.
        /// </summary>
        /// <param name="content"></param>
        void SetResult(ResultContent content);

        /// <summary>
        /// Перегруженный метод, создающий объект результата
        /// для скачивания файла.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        void SetResult(string path, string filename);
    }
}
