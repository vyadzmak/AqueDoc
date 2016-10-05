using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Core.Models
{
    public class FileManagerInfoResponse 
        : Interfaces.IFileManagerResponse
    {
        public ResultContent result;

        public void SetResult(ResultContent content)
        {
            result = content;
        }

        #region not implemented

        public void SetResult(NodesTree tree)
        {
            throw new NotImplementedException();
        }

        public void SetResult(string path, string filename)
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