#pragma checksum "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb9ef70a9ff2b9e9e4c7dc031ec5010214a10f6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ReportMasters_Index), @"mvc.1.0.view", @"/Views/ReportMasters/Index.cshtml")]
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
#line 1 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\_ViewImports.cshtml"
using DynaimcReporting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\_ViewImports.cshtml"
using DynaimcReporting.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb9ef70a9ff2b9e9e4c7dc031ec5010214a10f6c", @"/Views/ReportMasters/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5b5ab19c9ba40a03e190ec1a0fc5a03fff433e5", @"/Views/_ViewImports.cshtml")]
    public class Views_ReportMasters_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DynaimcReporting.Models.ReportMaster>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/excel.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
  
    ViewBag.Title = "Report List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Report Lists</h2>\r\n<hr />\r\n<p>\r\n    ");
#nullable restore
#line 10 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 14 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-2\">\r\n            <div class=\"card\" style=\"width: 18rem;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fb9ef70a9ff2b9e9e4c7dc031ec5010214a10f6c5097", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\"> ");
#nullable restore
#line 20 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\"> ");
#nullable restore
#line 21 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Categories.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
#nullable restore
#line 22 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 23 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"
               Write(Html.ActionLink("View Reports", "ViewReports", new { reportId = item.Id }, new { @class = "btn btn-primary btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 27 "C:\SSD USE\DynaimcReporting\DynaimcReporting\Views\ReportMasters\Index.cshtml"





    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DynaimcReporting.Models.ReportMaster>> Html { get; private set; }
    }
}
#pragma warning restore 1591
