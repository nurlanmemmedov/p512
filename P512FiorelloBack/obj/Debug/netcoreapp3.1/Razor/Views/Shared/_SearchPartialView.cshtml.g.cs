#pragma checksum "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5d071421f11de9fc5cbe6510cfe28af2abb9bc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchPartialView), @"mvc.1.0.view", @"/Views/Shared/_SearchPartialView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5d071421f11de9fc5cbe6510cfe28af2abb9bc9", @"/Views/Shared/_SearchPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"831ebf931e860c946676f9cf25f4797e0450bedc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Flower>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
 if (Model.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
     foreach (var flower in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 7 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
       Write(flower.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 8 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
     

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>Netice tapilmadi</li>\r\n");
#nullable restore
#line 14 "C:\Users\nmammadov\Desktop\P512FiorelloBack\P512FiorelloBack\Views\Shared\_SearchPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
