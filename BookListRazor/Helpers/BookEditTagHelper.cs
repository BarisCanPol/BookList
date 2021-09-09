using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListRazor.Helpers
{
    [HtmlTargetElement("book-edit")]
    public class BookEditTagHelper : TagHelper
    {
        [HtmlAttributeName("for-bookId")]
        public ModelExpression Id { get; set; }
        [HtmlAttributeName("for-bookName")]
        public ModelExpression Name { get; set; }
        [HtmlAttributeName("for-bookISBN")]
        public ModelExpression ISBN { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "BookEditDeail";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<span>This area is only test and example purpose!!</span> <br/>");
            sb.AppendFormat("<span>Id: {0}</span> <br/>", this.Id.Model);
            sb.AppendFormat("<span>Name: {0}</span><br/>", this.Name.Model);
            sb.AppendFormat("<span>ISBN: {0}</span>", this.ISBN.Model);

            output.PreContent.SetHtmlContent(sb.ToString());
        }



    }
}
