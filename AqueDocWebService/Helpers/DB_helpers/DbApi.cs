using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AqueDocWebService.Core.Models.Request_models;
using AqueDocWebService.Core.Models;
using System.Xml.Linq;
using System.IO;
using AqueDocWebService.Core.Models.Request_models;

namespace AqueDocWebService.Helpers.DB_helpers
{
    public static class DbApi
    {
        public static string DbName = "Files.xml";

        #region Методы

        /// <summary>
        /// Метод, позволяющий получить из базы список файлов и папок
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerListResponse GetFilesList(FileManagerListRequest request)
        {
            XDocument xDocument =
                XDocument.Load(Path
                .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                DbName));

            Helpers.DB_helpers.FromDbToModelBuilder builder =
                new Helpers.DB_helpers.FromDbToModelBuilder();

            NodesTree tree = builder.BuildTree(xDocument, request.Path);

            FileManagerListResponse response = new FileManagerListResponse();
            response.result = tree.Tree;

            return response;
        }

        /// <summary>
        /// Метод, переименовывающий папки/файлы
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse Rename(FileManagerRenameRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                    XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement xElement = builder.ChooseElementByName(xDocument, request.Item);

                xElement.Attribute("name").Value =
                    request.NewItemPath.Split('/').LastOrDefault();

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно переименовать"));
                return response;
            }
        }

        /// <summary>
        /// Метод, перемещающий файлы/папки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse Move(FileManagerMoveRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                    XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();
                XElement xElementDestination;
                List<XElement> elementsToMove = new List<XElement>();

                xElementDestination = builder.ChooseElementByName(xDocument, request.NewPath);
                request.Items.ForEach(x => elementsToMove.Add(builder.ChooseElementByName(xDocument, x)));

                elementsToMove.ForEach(x => { xElementDestination.Add(x); x.Remove(); });

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно переместить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, перемещающий файлы/папки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse Copy(FileManagerCopyRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                    XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();
                XElement xElementDestination;
                List<XElement> elementsToMove = new List<XElement>();

                XElement copiedElement = new XElement("node");

                xElementDestination = builder.ChooseElementByName(xDocument, request.NewPath);
                request.Items.ForEach(x => elementsToMove.Add(builder.ChooseElementByName(xDocument, x)));

                if (request.SingleFilename == "")
                {
                    elementsToMove.ForEach(x => xElementDestination.Add(x));
                }
                else
                {
                    copiedElement = new XElement(elementsToMove[0]);
                    copiedElement.Attribute("name").Value = request.SingleFilename;
                    xElementDestination.Add(copiedElement);
                }

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно переместить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, удаляющий файлы/папки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse Remove(FileManagerRemoveRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                    XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                List<XElement> elementsToRemove = new List<XElement>();

                request.Items.ForEach(x => elementsToRemove.Add(builder.ChooseElementByName(xDocument, x)));

                elementsToRemove.ForEach(x => x.Remove());

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно удалить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, удаляющий файлы/папки
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse CreateFolder(FileManagerCreateFolderRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                   XDocument.Load(Path
                   .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                   DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement destination = builder.ChooseElementByName(xDocument, request.NewPath);

                XElement xElement = new XElement(destination);
                xElement.RemoveAll();

                xElement.Name = "node";
                xElement.Add(new XAttribute("name", request.NewPath.Split('/').LastOrDefault()));
                xElement.Add(new XAttribute("rights", "-rw-r--r--"));
                xElement.Add(new XAttribute("size", "0"));
                xElement.Add(new XAttribute("date",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                xElement.Add(new XAttribute("type", "dir"));

                destination.Add(xElement);

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно удалить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, изменяющий права
        /// доступа к файлам/папкам
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse ChangePermissions(FileManagerChangePermissionsRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                    XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                List<XElement> elementsToChange = new List<XElement>();

                request.Items.ForEach(x =>
                    elementsToChange.Add(builder.ChooseElementByName(xDocument, x)));

                elementsToChange.ForEach(x => { x.Attribute("rights").Value = request.Perms; });

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно изменить права доступа"));
                return response;
            }
        }

        /// <summary>
        /// Метод, осуществляющий 
        /// загрузку файла
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse UploadFile(FileManagerUploadFileRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                   XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement destination = builder.ChooseElementByName(xDocument, request.Path);

                foreach (var item in request.Items)
                {
                    XElement xElement = new XElement(destination);
                    xElement.RemoveNodes();
                    xElement.RemoveAttributes();

                    xElement.Name = "node";
                    xElement.Add(new XAttribute("name", item.Value[0]));
                    xElement.Add(new XAttribute("size", item.Value[1]));
                    xElement.Add(new XAttribute("rights", "-rw-r--r--"));
                    xElement.Add(new XAttribute("date",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    xElement.Add(new XAttribute("id", item.Key.ToString()));
                    xElement.Add(new XAttribute("type", "file"));

                    destination.Add(xElement);
                }

                xDocument.Save(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                response.SetResult(new ResultContent(true, ""));

                return response;
            }

            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно удалить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, осуществляющий 
        /// скачивание файла
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerDownloadResponse DownloadFile(FileManagerDownloadFileRequest request)
        {
            FileManagerDownloadResponse response = new FileManagerDownloadResponse();

            try
            {
                XDocument xDocument =
                   XDocument.Load(Path
                    .Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/DB/"),
                    DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement destination = builder.ChooseElementByName(xDocument, request.Path);

                response.FileName = request.Path.Split('/').LastOrDefault();

                response.Path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/"),
                   destination.Attribute("id").Value);

                response.SetResult(response.Path, response.FileName);

                return response;
            }

            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно удалить"));
                return response;
            }
        }

        /// <summary>
        /// Метод, осуществляющий 
        /// скачивание текстового файла
        /// для редактирования
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerGetContentResponse GetContent(FileManagerGetContentRequest request)
        {
            FileManagerGetContentResponse response = new FileManagerGetContentResponse();

            try
            {
                XDocument xDocument =
                   XDocument.Load(Path
                   .Combine(@"C:/Users/User/Source/Repos/FileManagerMaterial/FileManagerMaterial/DB/",
                   DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement destination = builder.ChooseElementByName(xDocument, request.Item);

                string filePath = Path.Combine(@"C:/Users/User/Source/Repos/FileManagerMaterial/FManagerApi/App_Data/",
                   destination.Attribute("id").Value);

                response.SetResult(File.ReadAllText(filePath));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult("Невозможно прочесть");
                return response;
            }
        }

        /// <summary>
        /// Метод, осуществляющий 
        /// скачивание файла
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static FileManagerInfoResponse Edit(FileManagerEditRequest request)
        {
            FileManagerInfoResponse response = new FileManagerInfoResponse();

            try
            {
                XDocument xDocument =
                   XDocument.Load(Path
                   .Combine(@"C:/Users/User/Source/Repos/FileManagerMaterial/FileManagerMaterial/DB/",
                   DbName));

                Helpers.DB_helpers.FromDbToModelBuilder builder =
                   new Helpers.DB_helpers.FromDbToModelBuilder();

                XElement destination = builder.ChooseElementByName(xDocument, request.Item);

                string filePath = Path.Combine(@"C:/Users/User/Source/Repos/FileManagerMaterial/FManagerApi/App_Data/",
                   destination.Attribute("id").Value);

                File.WriteAllText(filePath, request.Content);

                response.SetResult(new ResultContent(true, ""));

                return response;
            }
            catch (Exception ex)
            {
                response.SetResult(new ResultContent(false, "Невозможно редактировать"));
                return response;
            }
        }

        #endregion

    }
}