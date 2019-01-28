using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlHeaderBlockModel: CtrlBaseModel
    {
        public string FontAwesomeType { get; set; }
        public string Nombre { get; set; }
        public CtrlHeaderBlockModel()
        {
            ViewName = "";
            Id = "";
        }
    }
}