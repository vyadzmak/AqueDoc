using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AqueDocWebService.Models
{
    public class InboxMailModel
    {
        public InboxMailModel()
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }

        public string Id { get; set; }
        public string SubjectName { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DateTime { get; set; }

        public string Text { get; set; }
    }
}