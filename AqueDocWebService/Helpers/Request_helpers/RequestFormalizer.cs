using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using AqueDocWebService.Core.Models.Request_models;

namespace AqueDocWebService.Helpers.Request_helpers
{
    /// <summary>
    /// Класс, содержащий методы формирования
    /// объекта запросов к серверу
    /// </summary>
    public static class RequestFormalizer
    {
        #region Методы

        /// <summary>
        /// Метод, выполняющий приведение полученной 
        /// строки к объекту запроса на вывод списка файлов
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static FileManagerRequest SerializeString(string request)
        {
            System.Web.Script.Serialization.JavaScriptSerializer deserializer =
                new System.Web.Script.Serialization.JavaScriptSerializer();
            Dictionary<object, object> deserializedRequest = null;

            try
            {
                deserializedRequest =
                    deserializer.Deserialize<Dictionary<object, object>>(request);
            }
            catch (ArgumentNullException exception)
            {
                return null;
            }

            // Проверим, есть ли вообще в десериализованном
            // объекте поле action. Если нет, то вернем
            // лишь проинициализированный объект запроса
            if (!deserializedRequest.ContainsKey((object)"action"))
            {
                return null;
            }

            // Перейдем к формализации запроса в зависимости
            // от типа действия
            switch (deserializedRequest["action"].ToString())
            {
                case "list":
                    return FormalizeListRequest(deserializedRequest);
                    break;

                case "rename":
                    return FormalizeRenameRequest(deserializedRequest);
                    break;

                case "move":
                    return FormalizeMoveRequest(deserializedRequest);
                    break;

                case "copy":
                    return FormalizeCopyRequest(deserializedRequest);
                    break;

                case "remove":
                    return FormalizeRemoveRequest(deserializedRequest);
                    break;

                case "createFolder":
                    return FormalizeCreateFolderRequest(deserializedRequest);
                    break;

                case "changePermissions":
                    return FormalizeChangePermissionsRequest(deserializedRequest);
                    break;

                case "getContent":
                    return FormalizeGetContentRequest(deserializedRequest);
                    break;

                case "edit":
                    return FormalizeEditRequest(deserializedRequest);
                    break;
            }

            return null;
        }

        /// <summary>
        /// Метод, выполняющий приведение запроса
        /// на загрузку файла к объекту
        /// </summary>
        /// <returns></returns>
        public static FileManagerUploadFileRequest SerializeUploadRequest(Dictionary<Guid, List<string>> fileIdNamePairs, 
            string destinationPath)
        {
            return new FileManagerUploadFileRequest("upload", fileIdNamePairs, destinationPath);
        }

        /// <summary>
        /// Метод, выполняющий приведение запроса
        /// на скачивание файла к объекту
        /// </summary>
        /// <returns></returns>
        public static FileManagerDownloadFileRequest SerializeDownloadRequest(string action, string path)
        {
            if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            return new FileManagerDownloadFileRequest(action, path);
        }

        /// <summary>
        /// Формализация запроса об предоставлении  
        /// списка файлов
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerListRequest FormalizeListRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                Core.Models.Request_models.FileManagerListRequest formalizedRequest =
                    new Core.Models.Request_models.FileManagerListRequest(deserializedRequest["action"].ToString(),
                        deserializedRequest["path"].ToString());

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new Core.Models.Request_models.FileManagerListRequest("", "");
            }
        }

        /// <summary>
        /// Формализация запроса об переименовании
        /// файла/папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerRenameRequest FormalizeRenameRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                FileManagerRenameRequest formalizedRequest =
                    new FileManagerRenameRequest(deserializedRequest["action"].ToString(),
                        deserializedRequest["item"].ToString(), deserializedRequest["newItemPath"].ToString());

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerRenameRequest("", "", "");
            }
        }

        /// <summary>
        /// Формализация запроса об перемещении
        /// файла/папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerMoveRequest FormalizeMoveRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                List<string> filePaths = new List<string>();

                ((Object[])deserializedRequest["items"]).ToList().ForEach(x => filePaths.Add(x.ToString()));

                FileManagerMoveRequest formalizedRequest = new FileManagerMoveRequest(deserializedRequest["action"].ToString(),
                        filePaths, //deserializedRequest["items"].ToString(), 
                        deserializedRequest["newPath"].ToString());

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerMoveRequest("", new List<string> {""}, "");
            }
        }

        /// <summary>
        /// Формализация запроса об перемещении
        /// файла/папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerCopyRequest FormalizeCopyRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                List<string> filePaths = new List<string>();

                ((Object[])deserializedRequest["items"]).ToList().ForEach(x => filePaths.Add(x.ToString()));

                // Возвращает строку, в зависимости от наличия
                // у полученного объекта поля "singleFileName"
                Func<Dictionary<object, object>, string> getSingleFileNameField = (Dictionary<object, object> x) =>
                    x.ContainsKey("singleFilename") ? 
                    deserializedRequest["singleFilename"].ToString() : "";

                FileManagerCopyRequest formalizedRequest = new FileManagerCopyRequest(deserializedRequest["action"].ToString(),
                        filePaths, //deserializedRequest["items"].ToString(), 
                        deserializedRequest["newPath"].ToString(),
                        getSingleFileNameField(deserializedRequest));

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerCopyRequest("", new List<string> { "" }, "", "");
            }
        }

        /// <summary>
        /// Формализация запроса об удалении
        /// файла/папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerRemoveRequest FormalizeRemoveRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                List<string> filePaths = new List<string>();

                ((Object[])deserializedRequest["items"]).ToList()
                    .ForEach(x => filePaths.Add(x.ToString()));


                FileManagerRemoveRequest formalizedRequest = new FileManagerRemoveRequest(deserializedRequest["action"].ToString(),
                        filePaths);

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerRemoveRequest("", new List<string> { "" });
            }
        }

        /// <summary>
        /// Формализация запроса 
        /// об создании папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerCreateFolderRequest FormalizeCreateFolderRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {

                deserializedRequest["newPath"].ToString();


                FileManagerCreateFolderRequest formalizedRequest =
                    new FileManagerCreateFolderRequest(deserializedRequest["action"].ToString(),
                    deserializedRequest["newPath"].ToString());

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerCreateFolderRequest("", "");
            }
        }

        /// <summary>
        /// Формализация запроса 
        /// об создании папки
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerChangePermissionsRequest FormalizeChangePermissionsRequest(Dictionary<object, object> deserializedRequest)
        {
            try
            {
                List<string> filePaths = new List<string>();

                ((Object[])deserializedRequest["items"]).ToList()
                    .ForEach(x => filePaths.Add(x.ToString()));

                FileManagerChangePermissionsRequest formalizedRequest =
                    new FileManagerChangePermissionsRequest(deserializedRequest["action"].ToString(),
                        filePaths, deserializedRequest["perms"].ToString(),
                        deserializedRequest["permsCode"].ToString(),
                        (bool)deserializedRequest["recursive"]);

                return formalizedRequest;
            }
            catch (Exception exception)
            {
                return new FileManagerChangePermissionsRequest("", new List<string> { "" }, "", "", false);
            }
        }

        /// <summary>
        /// Формализация запроса текстового содержания
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerGetContentRequest FormalizeGetContentRequest(Dictionary<object, object> deserializedRequest)
        {
            return new FileManagerGetContentRequest(deserializedRequest["action"].ToString(), 
                deserializedRequest["item"].ToString());
        }

        /// <summary>
        /// Формализация запроса 
        /// корректирования текстового содержания
        /// </summary>
        /// <param name="deserializedRequest"></param>
        /// <returns></returns>
        private static FileManagerEditRequest FormalizeEditRequest(Dictionary<object, object> deserializedRequest)
        {
            return new FileManagerEditRequest(deserializedRequest["action"].ToString(),
                deserializedRequest["item"].ToString(), deserializedRequest["content"].ToString());
        }

        /// <summary>
        /// Возвращает объект
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerRequest FormalizeRequest(string request)
        {
            return SerializeString(request);
        }
        
        #endregion

       
    }
        
}