#pragma checksum "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c2b54fcf8223a316e3768f3263deac07d56f04f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Administrator), @"mvc.1.0.view", @"/Views/Home/Administrator.cshtml")]
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
#line 1 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\_ViewImports.cshtml"
using Marketplace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\_ViewImports.cshtml"
using Marketplace.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c2b54fcf8223a316e3768f3263deac07d56f04f", @"/Views/Home/Administrator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58cdcd2211654fcb9dd30aa3115009e8e9dcd6bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Administrator : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Marketplace.Models.InstructorModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
  
    ViewData["Title"] = "Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Administrator Page</h1>\r\n</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 20 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
 foreach (var instructor in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 24 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
           Write(instructor.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 25 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
           Write(instructor.lastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <p style=\"font-size:11px\"> -Instructor Level: ");
#nullable restore
#line 26 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
                                                         Write(instructor.Level);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </td>\r\n            <td class=\"text-right\">\r\n                ");
#nullable restore
#line 29 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
           Write(Html.ActionLink("Accept", "Accept", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 30 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
           Write(Html.ActionLink("Deny", "Deny", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 33 "D:\Users\bayir\Documents\Documents\College\Third Year\SWENG II\TA-Marketplace\Marketplace\Views\Home\Administrator.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Marketplace.Models.InstructorModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
