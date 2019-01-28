using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.Controls
{
    public class CtrlBaseModel
    {

        public string Id { get; set; }
        public string ViewName { get; set; }

        private string ReadFileText()
        {
            //string path = @"C:\Users\Demo User\Desktop\Proyecto 2\Proyecto\Dennis\WebApp\Models\Controls\";
            string path = @"C:\Users\Dennis Ly\Desktop\Punto NET\Proyectos\Proyecto final - proyecto 2\Dennis\WebApp\Models\Controls\";
            string fileName = this.GetType().Name + ".html";

            path = path + fileName;
                
            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop != null) { 
                    var value = prop.GetValue(this, null).ToString();

                    var tag = string.Format("-#{0}-", prop.Name);
                    html = html.Replace(tag, value);
                }
            }
            return html;
        }
    }
}