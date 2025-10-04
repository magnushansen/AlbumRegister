using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AlbumRegister.TagHelpers
{
    [HtmlTargetElement("description", Attributes = "bg-color")]
    public class DescriptionTagHelper : TagHelper
    {
        public string BgColor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Attributes.SetAttribute("class", $"bg-{BgColor}");
            output.Attributes.SetAttribute("style", "padding: 10px; border-radius: 5px;");
        }
    }
}