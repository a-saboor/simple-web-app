#pragma checksum "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c856b921ae67c53a227c032c3b089898c83060cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_User_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/User/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c856b921ae67c53a227c032c3b089898c83060cb", @"/Areas/Admin/Views/User/Edit.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_User_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Proj9.DAL.Entities.User>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<form action=\"Edit\" class=\"form\" method=\"post\" autocomplete=\"off\" enctype=\"multipart/form-data\" id=\"user-edit\">\r\n    <input type=\"text\" name=\"UserId\"");
            BeginWriteAttribute("value", " value=\"", 246, "\"", 269, 1);
#nullable restore
#line 8 "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml"
WriteAttributeValue("", 254, Model.UserId, 254, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden/>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col form-group\">\r\n            <label class=\"control-label\">Name</label>\r\n            <input type=\"text\" class=\"form-control\" id=\"Name\" name=\"Name\" autocomplete=\"off\" placeholder=\"Enter Name here...\"");
            BeginWriteAttribute("value", " value=\"", 524, "\"", 571, 1);
#nullable restore
#line 13 "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml"
WriteAttributeValue("", 532, Model.Name != null ? Model.Name: "-", 532, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" required />
        </div>
        <div class=""col form-group"">
            <label class=""control-label"">Role</label>
            <select id=""RoleId"" name=""RoleId"" class=""form-control form-control-solid form-control-lg"">
                <option value=""3"" selected>User</option>
                <option value=""1"">Manager</option>
            </select>
        </div>
    </div>
    <div class=""row"">
        <div class=""col form-group"">
            <label class=""control-label"">Email</label>
            <input type=""email"" class=""form-control"" id=""Email"" name=""Email"" placeholder=""Enter email here..."" autocomplete=""off""");
            BeginWriteAttribute("value", " value=\"", 1206, "\"", 1255, 1);
#nullable restore
#line 26 "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml"
WriteAttributeValue("", 1214, Model.Email != null ? Model.Email: "-", 1214, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" required />
        </div>

        <div class=""col form-group"">
            <label class=""control-label"">Password</label>
            <i class=""fa fa-eye input-group-append"" id=""togglePassword"" style=""cursor: pointer;""></i>
            <input type=""password"" class=""form-control"" id=""Password"" name=""Password"" placeholder=""Enter password here..."" autocomplete=""off""");
            BeginWriteAttribute("value", " value=\"", 1629, "\"", 1684, 1);
#nullable restore
#line 32 "C:\Technomites\Projects\Proj9\Proj9\Areas\Admin\Views\User\Edit.cshtml"
WriteAttributeValue("", 1637, Model.Password != null ? Model.Password: "-", 1637, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" required />
        </div>

    </div><hr />
    <div class=""row form-group"">
        <div class=""col-12"">
            <button type=""button"" class=""btn btn-secondary btn-sm btn-close"" data-dismiss=""modal"" aria-label=""Close"">Close</button>
            <input type=""submit"" class=""btn btn-lg btn-success float-right"" value=""Save"" />
        </div>
    </div>
</form>

<script>
    $(function () {
        $(""#user-edit"").submit(function (e) {

            e.preventDefault();
            let actionurl = e.currentTarget.action;
            $.ajax({
                url: actionurl,
                type: 'post',
                //dataType: 'application/json',
                data: $(""#user-edit"").serialize(),
                success: function (data) {
                    if(data.success){toastr.success(data.userMessage);RefreshDataTable();$(""#popup-modal"").modal('hide');}
                    else
                        toastr.error(data.userMessage);
                },
                error");
            WriteLiteral(@": function( jqXhr, textStatus, errorThrown ){toastr.error('Internal server error..!');}
            });
        });
    });

    const togglePassword = document.querySelector('#togglePassword');
    const password = document.querySelector('#Password');

    togglePassword.addEventListener('click', function (e) {
    // toggle the type attribute
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);
    // toggle the eye slash icon
    this.classList.toggle('fa-eye-slash');
     });
</script>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Proj9.DAL.Entities.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591