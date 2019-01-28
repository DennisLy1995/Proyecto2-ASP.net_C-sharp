using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Models.Controls
{
    public class CtrlDropDownModel : CtrlBaseModel
    {
        public string Label { get; set; }
        public string ListOptions { get; set; }
        public string Id { get; set; }

        public CtrlDropDownModel()
        {
            ViewName = "";
        }
    }
}