#pragma checksum "D:\Projects\BlazorServerProfile\MyProfile\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84cf4f7fb992344efa39e077446bf1c3aee05758"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorServerProfile.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using BlazorServerProfile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using BlazorServerProfile.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using BlazorServerProfile.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\BlazorServerProfile\MyProfile\_Imports.razor"
using BlazorServerProfile.Data.Service;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "sidebar");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenComponent<BlazorServerProfile.Shared.NavMenu>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "main");
            __builder.AddMarkupContent(8, "\r\n\r\n    ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "content col-md-12");
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.AddContent(12, 
#nullable restore
#line 11 "D:\Projects\BlazorServerProfile\MyProfile\Shared\MainLayout.razor"
         Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n    ");
            __builder.AddMarkupContent(15, @"<div class=""card-footer px-4 col-md-12"">
        <a href=""https://www.facebook.com/SelesGabriel""><span style=""font-size:xx-large;"" class=""fab fa-facebook-square""></span></a>
        <a href=""https://www.linkedin.com/in/selesgabriel/""><span style=""font-size:xx-large;"" class=""fab fa-linkedin""></span></a>
        <a href=""https://github.com/SelesGabriel""><span style=""font-size:xx-large;"" class=""fab fa-github-square""></span></a>
    </div>
");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
