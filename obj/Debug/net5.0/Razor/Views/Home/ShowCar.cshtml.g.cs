#pragma checksum "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3217ae9cc1ab9997703517ab7a997b3a08fc0d6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowCar), @"mvc.1.0.view", @"/Views/Home/ShowCar.cshtml")]
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
#line 1 "/Users/ymihaylov/Projects/CarsCatalog/Views/_ViewImports.cshtml"
using CarsCatalog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ymihaylov/Projects/CarsCatalog/Views/_ViewImports.cshtml"
using CarsCatalog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3217ae9cc1ab9997703517ab7a997b3a08fc0d6a", @"/Views/Home/ShowCar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37b092cd5c7d5c7b58e4ec0fe7316b75212723da", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowCar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarsCatalog.Models.CarModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("add-comment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
   ViewData["Title"] = "Show Car"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container\">\n    <h3>");
#nullable restore
#line 5 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
   Write(Model.CarMake.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 5 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    <main role=""main"" class=""pb-3"">
        <div class=""container"">
            <div class=""row"">
                <div id=""car-photos-carousel"" class=""carousel slide"" data-ride=""carousel"">
                    <div class=""carousel-inner"">
                        <div class=""carousel-item active"">
                            <img class=""d-block w-100""");
            BeginWriteAttribute("src", " src=\"", 493, "\"", 511, 1);
#nullable restore
#line 12 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
WriteAttributeValue("", 499, Model.Photo, 499, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        </div>\n\n");
#nullable restore
#line 15 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                         foreach (var Photo in Model.Photos)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"carousel-item\">\n                                <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 747, "\"", 764, 1);
#nullable restore
#line 18 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
WriteAttributeValue("", 753, Photo.Path, 753, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Third slide\">\n                            </div>\n");
#nullable restore
#line 20 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>

                    <a class=""carousel-control-prev"" href=""#car-photos-carousel"" role=""button"" data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#car-photos-carousel"" role=""button"" data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Next</span>
                    </a>
                </div>
            </div>

            <div class=""row car-article-row"">
                <article>
                    ");
#nullable restore
#line 45 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
               Write(Html.Raw(@Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </article>\n            </div>\n\n            <div class=\"row comments-row\">\n                <h4>Коментари</h4>\n            </div>\n\n            <div id=\"car-comments-form-wrapper\" class=\"form-group\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3217ae9cc1ab9997703517ab7a997b3a08fc0d6a7052", async() => {
                WriteLiteral("\n                    <input type=\"hidden\" name=\"car_model_id\"");
                BeginWriteAttribute("value", " value=\"", 2400, "\"", 2417, 1);
#nullable restore
#line 55 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
WriteAttributeValue("", 2408, Model.Id, 2408, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                    <textarea class=\"form-control\" rows=\"4\" placeholder=\"Споделете своето мнение и опит за модела тук:\"></textarea>\n                    <button type=\"submit\" class=\"btn btn-primary\">Изпрати</button>\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 54 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
AddHtmlAttributeValue("", 2306, Url.RouteUrl("post_a_comment"), 2306, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n\n            <div id=\"latest-comments-wrapper\">\n                <div class=\"row\">\n                    <h5>Последни</h5>\n                </div>\n\n                <div id=\"comments-list\">\n");
#nullable restore
#line 67 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                     foreach (var Comment in @Model.Comments)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row\">\n                            <h6>На ");
#nullable restore
#line 70 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                              Write(Comment.CreatedDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" г.</h6>\n                        </div>\n                        <div class=\"row single-comment-description\">\n                            ");
#nullable restore
#line 73 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                       Write(Comment.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </div>\n");
#nullable restore
#line 75 "/Users/ymihaylov/Projects/CarsCatalog/Views/Home/ShowCar.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n            </div>\n        </div>\n    </main>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarsCatalog.Models.CarModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
