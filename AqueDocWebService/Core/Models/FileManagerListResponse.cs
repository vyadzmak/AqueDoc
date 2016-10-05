using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AqueDocWebService.Core.Interfaces;

namespace AqueDocWebService.Core.Models
{
    public class FileManagerListResponse : IFileManagerResponse
    {
        public List<Node> result;

        public void SetResult(NodesTree tree)
        {
            result = tree.Tree;
        }

        #region not implemented

        public void SetResult(ResultContent content)
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