using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Controls;

namespace WebApp.Helpers
{
    public static class ControlExtensions
    {
        public static HtmlString CtrlTable(this HtmlHelper html, string viewName, string id, string title,
            string columnsTitle, string ColumnsDataName, string onSelectFunction)
        {
            var ctrl = new CtrlTableModel
            {
                ViewName = viewName,
                Id = id,
                Title = title,
                Columns = columnsTitle,
                ColumnsDataName = ColumnsDataName,
                FunctionName = onSelectFunction
            };

            return new HtmlString(ctrl.GetHtml());
        }
        public static HtmlString CtrlInput(this HtmlHelper html, string id, string type, string label, string placeHolder = "", string columnDataName="")
        {
            var ctrl = new CtrlInputModel
            {
                Id = id,
                Type = type,
                Label = label,
                PlaceHolder=placeHolder,
                ColumnDataName=columnDataName
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlButton(this HtmlHelper html, string viewName, string id, string label, string onClickFunction="", string buttonType="primary")
        {
            var ctrl = new CtrlButtonModel
            {
                ViewName = viewName,
                Id = id,
                Label = label,
                FunctionName = onClickFunction,
                ButtonType = buttonType
            };

            return new HtmlString(ctrl.GetHtml());
        }

    
        public static HtmlString CtrlNavBar(this HtmlHelper html, string NAVBAR_TITLE)
        {
            var ctrl = new CtrlNavBarModel
            {
                NavbarTitle = NAVBAR_TITLE
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlHeaderBlock(this HtmlHelper html, string FONT_AWESOME_TYPE, string NOMBRE)
        {
            var ctrl = new CtrlHeaderBlockModel
            {
                FontAwesomeType = FONT_AWESOME_TYPE,
                Nombre = NOMBRE
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlAlert(this HtmlHelper html)
        {
            var ctrl = new CtrlAlertModel();
            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlSelect(this HtmlHelper html, string id, string label, string servicio)
        {
            var ctrl = new CtrlSelectModel
            {
                Id = id,
                Label = label,
                Servicio = servicio
            };

            return new HtmlString(ctrl.GetHtml());
        }

        public static HtmlString CtrlDropDown(this HtmlHelper html, string Label, String ListOptions,string Id)
        {
            var ctrl = new CtrlDropDownModel
            {
                Label = Label,
                ListOptions = ListOptions,
                Id = Id
            };
            return new HtmlString(ctrl.GetHtml());
        }

    }
}