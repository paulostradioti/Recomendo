using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recomendo.Website.Infrastructure
{
    //[HtmlTargetElement("li", Attributes = "condition-class-active")]
    [HtmlTargetElement("li")]
    public class ConditionalActiveClassTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        [HtmlAttributeName("active-target-controller-name")]
        public string TargetControllerName { get; set; }

        
        [HtmlAttributeName("active-current-controller-name")]
        public string CurrentControllerName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var classes = CssClass;

            if (CurrentControllerName != null &&
                TargetControllerName != null)
            {
                if (TargetControllerName.EndsWith("Controller"))
                {
                    var index = TargetControllerName.LastIndexOf("Controller");
                    TargetControllerName = TargetControllerName.Substring(0, index); ;
                }
                if (CurrentControllerName.Equals(TargetControllerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    classes = string.Join(" ", classes, "active");
                }
            }

            if (classes != null)
            {
                output.Attributes.Add("class", classes);
            }
        }
    }
}
