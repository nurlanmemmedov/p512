#pragma checksum "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b954fabb16696bf0a066818e88a04aeb6e3268ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FlowersPartialView), @"mvc.1.0.view", @"/Views/Shared/_FlowersPartialView.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\_ViewImports.cshtml"
using P512FiorelloBack;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\_ViewImports.cshtml"
using P512FiorelloBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\_ViewImports.cshtml"
using P512FiorelloBack.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b954fabb16696bf0a066818e88a04aeb6e3268ab", @"/Views/Shared/_FlowersPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"831ebf931e860c946676f9cf25f4797e0450bedc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__FlowersPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Flower>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "flower", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
 foreach (Flower flower in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 67, "\"", 240, 2);
            WriteAttributeValue("", 75, "flowers-item", 75, 12, true);
            WriteAttributeValue(" ", 87, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 4 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                              foreach (FlowerCategory flowerCategory in flower.FlowerCategories)
	{
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                        Write(flowerCategory.Category.Name.ToLower() + " ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                                                           
	}

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 88, 152, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"img\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b954fabb16696bf0a066818e88a04aeb6e3268ab6072", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b954fabb16696bf0a066818e88a04aeb6e3268ab6343", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 460, "~/assets/images/", 460, 16, true);
#nullable restore
#line 10 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
AddHtmlAttributeValue("", 476, flower.MainImage, 476, 17, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                                             WriteLiteral(flower.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                                                                               WriteLiteral(flower.FlowerCategories.FirstOrDefault().CategoryId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["categoryId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-categoryId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["categoryId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"flower-body text-center\">\r\n            <p class=\"flower-name\">");
#nullable restore
#line 14 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                              Write(flower.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"flowers-title\">\r\n                <div class=\"addToCart\" data-id=\"1\" style=\"display: inline-block;\">Add To Cart</div>\r\n                <div class=\"price-container \" style=\"display: inline-block;\">\r\n");
#nullable restore
#line 18 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                     if (flower.DiscountPrice == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"price\">$");
#nullable restore
#line 20 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                        Write(flower.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 21 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"price\"><span style=\"text-decoration:line-through\">$");
#nullable restore
#line 24 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                                                                   Write(flower.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>, $");
#nullable restore
#line 24 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                                                                                                          Write(flower.DiscountPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 25 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 30 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_FlowersPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Flower>> Html { get; private set; }
    }
}
#pragma warning restore 1591
