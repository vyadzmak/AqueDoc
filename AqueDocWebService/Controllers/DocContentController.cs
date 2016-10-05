using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AqueDocWebService.Core.Models.Request_models;
using AqueDocWebService.Helpers.Request_helpers;
using System.Net.Http.Headers;

namespace AqueDocWebService.Controllers
{
    public class DocContentController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get(string action, string path)
        {
            FileManagerDownloadFileRequest request = RequestFormalizer.SerializeDownloadRequest(action, path);

            AqueDocWebService.Core.Request_handlers.RequestHandler handler =
                new AqueDocWebService.Core.Request_handlers.RequestHandler();

            AqueDocWebService.Core.Models.FileManagerDownloadResponse response =
                (AqueDocWebService.Core.Models.FileManagerDownloadResponse)handler.Handle(request);

            HttpResponseMessage fileResponse = new HttpResponseMessage(HttpStatusCode.OK);
            fileResponse.Content = new StreamContent(new FileStream(response.Path, FileMode.Open, FileAccess.Read));
            fileResponse.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            fileResponse.Content.Headers.ContentDisposition.FileName = response.FileName;

            fileResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return fileResponse;
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]

        public async Task<HttpResponseMessage> Post()
        {
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            //FileManagerUploadFileRequest request = new FileManagerUploadFileRequest()
            try
            {
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new MultipartFormDataStreamProvider(root);
                    await Request.Content.ReadAsMultipartAsync(streamProvider);

                    Dictionary<Guid, List<string>> fileIdNamePairs = new Dictionary<Guid, List<string>>();

                    string destinationPath = streamProvider.FormData.Get("destination");

                    foreach (MultipartFileData fileData in streamProvider.FileData)
                    {
                        if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                        {

                            return Request.CreateResponse(HttpStatusCode.NotAcceptable,
                                "This request is not properly formatted");
                        }

                        Guid newGuid = Guid.NewGuid();
                        string fileName = fileData.Headers.ContentDisposition.FileName;
                        fileName = fileName.Substring(1, fileName.Length - 2);

                        fileIdNamePairs.Add(newGuid, new List<string>() { fileName, "" });

                        string fileId = newGuid.ToString();

                        if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                        {
                            fileName = fileName.Trim('"');
                        }
                        if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                        {
                            fileName = Path.GetFileName(fileName);
                        }
                        File.Move(fileData.LocalFileName, Path.Combine(root, fileId));
                    }

                    FileManagerUploadFileRequest request = AqueDocWebService.Helpers.Request_helpers
                        .RequestFormalizer.SerializeUploadRequest(fileIdNamePairs, destinationPath);

                    AqueDocWebService.Helpers.DB_helpers.DbApi.UploadFile(request);


                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted");
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}