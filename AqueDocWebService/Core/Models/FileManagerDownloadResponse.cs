using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    public class FileManagerDownloadResponse : AqueDocWebService.Core.Interfaces.IFileManagerResponse
    {
        public string Path {get; set;}

        public string FileName {get; set;}

        public void SetResult(string path, string filename)
        {
            Path = path;
            FileName = filename;
        }

        #region not implemented

        public void SetResult(ResultContent content)
        {
            throw new NotImplementedException();
        }

        public void SetResult(NodesTree tree)
        {
            throw new NotImplementedException();
        }

        public void SetResult(string result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}