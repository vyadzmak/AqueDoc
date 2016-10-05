using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    public class FileManagerGetContentResponse : AqueDocWebService.Core.Interfaces.IFileManagerResponse
    {
        public string result { get; set; }

        public void SetResult(string result)
        {
            this.result = result;
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

        public void SetResult(string path, string filename)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}