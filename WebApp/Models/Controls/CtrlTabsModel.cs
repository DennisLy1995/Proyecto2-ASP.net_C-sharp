using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlTabsModel : CtrlBaseModel
    {
        public string Tabs { get; set; }
        public string TabsDataName { get; set; }
        public string Title { get; set; }

        public int TabsCount => Tabs.Split(',').Length;

        public string ColumnHeaders
        {
            get
            {
                var headers = "";
                foreach (var text in Tabs.Split(','))
                {
                    headers += "<th>" + text + "</th>";
                }

                return headers;
            }
        }
    }
}