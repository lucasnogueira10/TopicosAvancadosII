#pragma checksum "C:\Users\billy\source\repos\ProjPadaria\ProjPadaria\Views\Padaria\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecbd50b177fb2ae131c7da67b2a65eca6aac2790"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Padaria_Edit), @"mvc.1.0.view", @"/Views/Padaria/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecbd50b177fb2ae131c7da67b2a65eca6aac2790", @"/Views/Padaria/Edit.cshtml")]
    public class Views_Padaria_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjPadaria.Model.Padaria>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\billy\source\repos\ProjPadaria\ProjPadaria\Views\Padaria\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Padaria</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
            <div class=""form-group"">
                <label asp-for=""Nome"" class=""control-label""></label>
                <input asp-for=""Nome"" class=""form-control"" />
                <span asp-validation-for=""Nome"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""CNPJ"" class=""control-label""></label>
                <input asp-for=""CNPJ"" class=""form-control"" />
                <span asp-validation-for=""CNPJ"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""QtdFuncionarios"" class=""control-label""></label>
                <input asp-for=""QtdFuncionarios"" class=""form-control"" />
                <span asp-validation-fo");
            WriteLiteral(@"r=""QtdFuncionarios"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Endereco"" class=""control-label""></label>
                <input asp-for=""Endereco"" class=""form-control"" />
                <span asp-validation-for=""Endereco"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Telefone"" class=""control-label""></label>
                <input asp-for=""Telefone"" class=""form-control"" />
                <span asp-validation-for=""Telefone"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 53 "C:\Users\billy\source\repos\ProjPadaria\ProjPadaria\Views\Padaria\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjPadaria.Model.Padaria> Html { get; private set; }
    }
}
#pragma warning restore 1591
