using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.TagHelpers;

namespace TagHelpers
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    [HtmlTargetElement("datetime")]
    public class DateTimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.TagMode = TagMode.SelfClosing;

            string formatString = null;
            string datetimeValue = null;
            if (context.AllAttributes["format"]!=null)
            {
                formatString = context.AllAttributes["format"].Value.ToString();
            }

            datetimeValue = DateTime.Now.ToString(formatString ?? "yyyy MMMM dd");

            output.Content.SetContent(datetimeValue);
        }
    }
}
