#pragma checksum "C:\Users\Dan Woda\Desktop\CodingDojo\CSharp\FinalProject\DraftChat\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db21e7a8bef2b6593be5816b008e722f3ecd62cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\Dan Woda\Desktop\CodingDojo\CSharp\FinalProject\DraftChat\Views\_ViewImports.cshtml"
using DraftChat;

#line default
#line hidden
#line 2 "C:\Users\Dan Woda\Desktop\CodingDojo\CSharp\FinalProject\DraftChat\Views\_ViewImports.cshtml"
using DraftChat.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db21e7a8bef2b6593be5816b008e722f3ecd62cd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d65b56e85050ffbaf01aa5b296902aed454038", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "PlayerData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chat.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/playerTable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Dan Woda\Desktop\CodingDojo\CSharp\FinalProject\DraftChat\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 20, true);
            WriteLiteral("\r\n<div id=\"tData\">\r\n");
            EndContext();
            BeginContext(65, 28, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecf66929444649ccb735b3427a1410fe", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(93, 3012, true);
            WriteLiteral(@"
</div>
<script>
    function BindControlEvents(){
        $(document).on(""click"", "".GetByTeam"", function(){
            var enterData = $(this).val();
            console.log(""I'm here!"");
            console.log(enterData);
            $.ajax({
                type: 'GET',
                url: '/Ajax/AllOfTeam',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: { 'team': enterData },
            })
            .done(function(partialViewResult) {
                $(""#tData"").html(partialViewResult)
            });
        });
        $(document).on(""click"", "".GetByPos"", function(){
            var enterData = $(this).val();
            console.log(""I'm here!"");
            console.log(enterData);
            $.ajax({
                type: 'GET',
                url: '/Ajax/AllOfPos',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: { 'position': enter");
            WriteLiteral(@"Data },
            })
            .done(function(partialViewResult) {
                console.log(""Here!!!"")
                $(""#tData"").html(partialViewResult)
            });
        });
        $(document).on(""click"", "".GetByAvail"", function(){
            var enterData = $(this).val();
            console.log(""I'm here!"");
            console.log(enterData);
            $.ajax({
                type: 'GET',
                url: '/Ajax/AllOfAvail',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                data: { 'avail': enterData },
            })
            .done(function(partialViewResult) {
                $(""#tData"").html(partialViewResult)
            });
        });
    }
    $(document).ready(function(){
        BindControlEvents();
    });
    // var prm = Sys.WebForms.PageRequestManager.getInstance(); 

    // prm.add_endRequest(function() { 
    //     BindControlEvents();
    // });
</script>
<div class=""righ");
            WriteLiteral(@"t-container"">
    <div class=""timer-wrapper"">
        <span class=""round-number round-font"">Round: #</span>
        <br>
        <span class=""round-font"">Round Countdown: </span>
        <span class=""round-font"" id=""demo""></span>
    </div>
    <div class=""chat-wrapper"">
        <div class=""row"">
            <div class=""message-box col-6"">
                <ul id=""messagesList""></ul>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-6"">
                <input class=""chat-input"" type=""text"" id=""userInput"" placeholder=""UserName""/>
                <input class=""chat-input"" type=""text"" id=""messageInput"" placeholder=""Comment Here""/>
                <button class=""chat-input btn"" id=""sendButton"" value=""Send Message"">Send Message</button>
            </div>
        </div>
    </div>
</div>
<button id=""startTimer"" type=""hidden"">Start Timer</button>

<script src=""/lib/signalr/signalr.js""></script>
");
            EndContext();
            BeginContext(3105, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fdd70c9dc7e349e9a6b54f9ea9519689", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3141, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
            EndContext();
            BeginContext(3149, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b60ae4e7624e4c4e8e0b9621f50384a1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
