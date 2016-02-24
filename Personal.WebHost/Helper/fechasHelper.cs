using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using Personal.Utilities;

namespace Personal.WebHost.Helper
{
    public static class fechasHelper
    {
        public static MvcHtmlString selectDia(this HtmlHelper helper, Dictionary<string, string> attr)
        {
            string contents = "<option>Dia</option>";
            var select = new TagBuilder("select");
            select.MergeAttributes<string, string>(attr);
            foreach (var item in fechasUtil.dia)
            {
                contents += options(item.ToString(), item.ToString());
            }
            select.InnerHtml = contents.ToString();
            return MvcHtmlString.Create(select.ToString());
        }

        public static MvcHtmlString selectMes(this HtmlHelper helper, Dictionary<string, string> attr)
        {
            string contents = "<option>Mes</option>";
            var select = new TagBuilder("select");
            select.MergeAttributes<string, string>(attr);
            foreach (var item in fechasUtil.meses)
            {
                contents += options(item.Value.ToString(), item.Key.ToString());
            }
            select.InnerHtml = contents.ToString();
            return MvcHtmlString.Create(select.ToString());
        }

        public static MvcHtmlString selectAño(this HtmlHelper helper, Dictionary<string, string> attr)
        {
            string contents = "<option>Año</option>";
            var select = new TagBuilder("select");
            select.MergeAttributes<string, string>(attr);
            foreach (var item in fechasUtil.año)
            {
                contents += options(item.ToString(), item.ToString());
            }
            select.InnerHtml = contents.ToString();
            return MvcHtmlString.Create(select.ToString());
        }

        private static string options(string value, string innerHTML)
        {

            var option = new TagBuilder("option");
            option.MergeAttribute("value", value);
            option.InnerHtml = innerHTML;

            return option.ToString();
        }
    }
}