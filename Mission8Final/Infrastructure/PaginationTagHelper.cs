using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission8Final.Models.ViewModels;

namespace Mission7Final.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-list")]

    public class PaginationTagHelper : TagHelper
    {
        // create a url instance
        private IUrlHelperFactory uhf;

        // constructor
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        // Different than the View Context
        // This is for adding class to the target element
        public PageInfo PageList { get; set; }
        public string PageAction { get; set; }
        // CSS enabling
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            // add element in the target element (div)
            TagBuilder final = new TagBuilder("div");

            // append a tag with a url & action (Index)
            for (int i = 1; i <= PageList.TotalPages; i++)
            {
                // declare a tagbuilder instance and assign a new instance with a tag
                TagBuilder tb = new TagBuilder("a");
                // add Attribute (href) with action & page number
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                // put the page number as string inside of the a tag
                tb.InnerHtml.Append(i.ToString());
                // CSS styling
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageList.CurrentPage
                    ? PageClassSelected : PageClassNormal);
                }
                if (i != PageList.TotalPages)
                {
                    final.InnerHtml.AppendHtml(tb);
                    final.InnerHtml.AppendHtml(" ");
                }
                else
                {
                    final.InnerHtml.AppendHtml(tb);
                }

            }
            // append the final's innerhtml in the taghelperoutput
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
