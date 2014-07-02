using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PostView
    {
        public int uid { get; set; }

        public string text { get; set; }

        public string username { get; set; }

        public string avatar { get; set; }

        public bool favorite { get; set; }
    }

}