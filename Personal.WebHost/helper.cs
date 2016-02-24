using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Linq.Expressions;

namespace BussinessLogic.WebHost
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
    }
}