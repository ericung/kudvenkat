#pragma checksum "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6850ae6c41bdd18a65884ca759dab367513e7ff5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6850ae6c41bdd18a65884ca759dab367513e7ff5", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<kudvenkat.Models.Employee>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
   
  Layout = "~/Views/Shared/_Layout.cshtml";
  ViewBag.Title = "Employee List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table>\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>Id</th>\r\n\t\t\t<th>Name</th>\r\n\t\t\t<th>Department</th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 17 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
         foreach (var employee in Model)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<tr>\r\n\t\t\t\t<td>");
#nullable restore
#line 20 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
               Write(employee.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t<td>");
#nullable restore
#line 21 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
               Write(employee.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t<td>");
#nullable restore
#line 22 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
               Write(employee.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t</tr>\r\n");
#nullable restore
#line 24 "C:\Users\Eric\source\repos\kudvenkat\kudvenkat\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<kudvenkat.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
