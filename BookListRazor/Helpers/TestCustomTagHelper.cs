using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListRazor.Utilities.CustomTagHelper
{
    [HtmlTargetElement("test-custom-tag-helper")]
    public class TestCustomTagHelper : TagHelper 
    {
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "TestCustomTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            sb.AppendFormat("<span>Hi! {0}</span>", this.Name);

            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
