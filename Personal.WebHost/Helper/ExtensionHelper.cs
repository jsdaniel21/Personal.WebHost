using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using Personal.Utilities;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Linq.Expressions;

namespace Personal.WebHost.Helper
{
    public static class ExtensionHelper
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, bool disabled)
        {
            Func<TModel, TProperty> method = expression.Compile();
            string value = method(htmlHelper.ViewData.Model) as string;

            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
                attributes["disabled"] = "disabled";

            return htmlHelper.DropDownListFor(expression, selectList, optionLabel, attributes, disabled);
        }
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
                attributes["disabled"] = "disabled";
            return htmlHelper.TextBoxFor(expression, attributes);
        }
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