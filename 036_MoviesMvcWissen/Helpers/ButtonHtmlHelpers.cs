using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Helpers
{
    public static class ButtonHtmlHelpers
    {
        /// <summary>
        /// Tipi submit olan bir Save button oluşturur.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString SaveButton(this HtmlHelper htmlHelper)
        {
            TagBuilder tagBuilder = new TagBuilder("button");
            tagBuilder.InnerHtml = "Save";
            tagBuilder.MergeAttribute("type", "submit");
            tagBuilder.MergeAttribute("class", "btn btn-success");
            return MvcHtmlString.Create(tagBuilder.ToString());
        }

        /// <summary>
        /// Parametrelere göre custom button oluşturur.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="buttonText"></param>
        /// <param name="buttonClass"></param>
        /// <param name="buttonType"></param>
        /// <returns></returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper, string buttonText, string buttonClass, string buttonType = "")
        {
            TagBuilder tagBuilder = new TagBuilder("button");
            tagBuilder.InnerHtml = buttonText;
            if (buttonType != "")
                tagBuilder.MergeAttribute("type", buttonType);
            tagBuilder.MergeAttribute("class", buttonClass);
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}