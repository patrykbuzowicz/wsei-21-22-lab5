using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wsei.Lab5.TagHelpers
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        public string Color { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var colorClass = string.IsNullOrEmpty(Color)
                // default value
                ? "alert-info"
                // color passed via parameter
                : $"alert-{Color}";

            output.TagName = "div";
            output.Attributes.Add("class", $"alert {colorClass}");
        }
    }
}
