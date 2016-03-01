using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Web.Profile;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Routing;


namespace Personal.WebHost
{
   
    public static class HtmlExtensions
    {

        public static MvcHtmlString DisplayColumnNameFor<TModel, TClass, TProperty>(this  HtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(null, typeof(TClass), name);
            return new MvcHtmlString(metadata.DisplayName);
        }

        public static MvcHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
                attributes["disabled"] = "disabled";
            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }
    }
}