using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AqueDocWebService.Core.Models;
using AqueDocWebService.Core.Models.Request_models;
using AqueDocWebService.Core.Interfaces;
using AqueDocWebService.Helpers.DB_helpers;

namespace AqueDocWebService.Core.Request_handlers
{
    /// <summary>
    /// Обработчик запросов
    /// </summary>
    public class RequestHandler
    {
        /// <summary>
        /// Сюда первоочередно попадает запрос, 
        /// отсюда мы перенаправляем их соответственно типу
        /// </summary>
        /// <param name="request"></param>
        public IFileManagerResponse Handle(FileManagerRequest request)
        {
            switch (request.Action)
            {
                case "list":
                    return GettingListHandler(request as FileManagerListRequest);
                    break;
                case "rename":
                    return RenameHandler(request as FileManagerRenameRequest);
                    break;
                case "move":
                    return MoveHandler(request as FileManagerMoveRequest);
                    break;
                case "copy":
                    return CopyHandler(request as FileManagerCopyRequest);
                    break;
                case "remove":
                    return RemoveHandler(request as FileManagerRemoveRequest);
                    break;
                case "createFolder":
                    return CreateFolderHandler(request as FileManagerCreateFolderRequest);
                    break;
                case "changePermissions":
                    return ChangePermissionsHandler(request as FileManagerChangePermissionsRequest);
                    break;
                case "download":
                    return DownloadHandler(request as FileManagerDownloadFileRequest);
                    break;
                case "getContent":
                    return GetContentHandler(request as FileManagerGetContentRequest);
                    break;
                case "edit":
                    return EditHandler(request as FileManagerEditRequest);
                    break;
            }

            return null;
        }

        /// <summary>
        /// Обработка запросов типа "list"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse GettingListHandler(FileManagerListRequest request)
        {
            return DbApi.GetFilesList(request);
        }

        /// <summary>
        /// Обработка запросов типа "rename"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse RenameHandler(FileManagerRenameRequest request)
        {
            return DbApi.Rename(request);
        }

        /// <summary>
        /// Обработка запросов типа "move"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse MoveHandler(FileManagerMoveRequest request)
        {
            return DbApi.Move(request);
        }

        /// <summary>
        /// Обработка запросов типа "copy"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse CopyHandler(FileManagerCopyRequest request)
        {
            return DbApi.Copy(request);
        }

        /// <summary>
        /// Обработка запросов типа "remove"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse RemoveHandler(FileManagerRemoveRequest request)
        {
            return DbApi.Remove(request);
        }

        /// <summary>
        /// Обработка запросов типа "createFolder"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse CreateFolderHandler(FileManagerCreateFolderRequest request)
        {
            return DbApi.CreateFolder(request);
        }

        /// <summary>
        /// Обработка запросов типа "changePermissions"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse ChangePermissionsHandler(FileManagerChangePermissionsRequest request)
        {
            return DbApi.ChangePermissions(request);
        }

        /// <summary>
        /// Обработка запросов типа "download"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse DownloadHandler(FileManagerDownloadFileRequest request)
        {
            return DbApi.DownloadFile(request);
        }

        /// <summary>
        /// Обработка запросов типа "getContent"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse GetContentHandler(FileManagerGetContentRequest request)
        {
            return DbApi.GetContent(request);
        }

        /// <summary>
        /// Обработка запросов типа "edit"
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IFileManagerResponse EditHandler(FileManagerEditRequest request)
        {
            return DbApi.Edit(request);
        }
    }
}