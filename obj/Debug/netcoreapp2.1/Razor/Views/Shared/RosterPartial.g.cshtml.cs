#pragma checksum "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17ab32b842426674484daecad15ff301457dcf70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_RosterPartial), @"mvc.1.0.view", @"/Views/Shared/RosterPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/RosterPartial.cshtml", typeof(AspNetCore.Views_Shared_RosterPartial))]
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
#line 1 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\_ViewImports.cshtml"
using DraftChat;

#line default
#line hidden
#line 2 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\_ViewImports.cshtml"
using DraftChat.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17ab32b842426674484daecad15ff301457dcf70", @"/Views/Shared/RosterPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d65b56e85050ffbaf01aa5b296902aed454038", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_RosterPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 33, true);
            WriteLiteral("<!-- model FantasyTeam -->\r\n<!-- ");
            EndContext();
#line 2 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
       
    var RosterDict = new Dictionary<string, string>()
    {
        { "QB", "Unfilled"},
        { "RB", "Unfilled"},
        { "RB2", "Unfilled"},
        { "WR", "Unfilled"},
        { "WR2", "Unfilled"},
        { "TE", "Unfilled"},
        { "Flex", "Unfilled"},
        { "Kicker", "Unfilled"},
        { "Bench1", "Unfilled"},
        { "Bench2", "Unfilled"},
        { "Bench3", "Unfilled"},
        { "Bench4", "Unfilled"}

    };
    int RB = 0;
    int WR = 0;
    bool QB = false;
    bool TE = false;
    bool Flex = false;
    int Bench = 0;
    foreach(var player in Model.Players){
        if((player.Position == "RB") && (RB < 2)){ RB ++; RosterDict.Add((player.Position + RB.ToString()), player.Name); }
        else if((player.Position == "WR") && (WR < 2)) { WR ++; RosterDict.Add((player.Position + WR.ToString()), player.Name); }
        else if((player.Position == "TE") && (TE == false)) { TE = true; RosterDict.Add(player.Position, player.Name);}
        else if((player.Position == "QB") && (QB == false)) { QB = true; RosterDict.Add(player.Position, player.Name);}
        else if(((player.Position == "WR") || (player.Position == "RB") || (player.Position == "TE")) && (Flex == false))
        { 
            Flex = true; 
            RosterDict.Add("Flex", player.Name); 
        } 
        else 
        {
            Bench ++;
            RosterDict.Add(("Bench" + Bench.ToString()), player.Name);
        }
    }

#line default
#line hidden
            BeginContext(1520, 148, true);
            WriteLiteral(" -->\r\n<div id=\'rostContainer\'>\r\n    <div class=\'rostcol\'>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>QB</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(1669, 16, false);
#line 46 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["QB"]);

#line default
#line hidden
            EndContext();
            BeginContext(1685, 112, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>WR</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(1798, 17, false);
#line 50 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["WR1"]);

#line default
#line hidden
            EndContext();
            BeginContext(1815, 112, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>RB</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(1928, 17, false);
#line 54 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["RB1"]);

#line default
#line hidden
            EndContext();
            BeginContext(1945, 114, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>Flex</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(2060, 18, false);
#line 58 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["Flex"]);

#line default
#line hidden
            EndContext();
            BeginContext(2078, 166, true);
            WriteLiteral("</h4>\r\n        </div>\r\n    </div>\r\n    <div class=\'rostColumn\'>\r\n            <div class=\'rostRow\'>\r\n                <h3><strong>TE</strong></h3>\r\n                <h4>");
            EndContext();
            BeginContext(2245, 16, false);
#line 64 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
               Write(RosterDict["TE"]);

#line default
#line hidden
            EndContext();
            BeginContext(2261, 128, true);
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\'rostRow\'>\r\n                <h3><strong>WR</strong></h3>\r\n                <h4>");
            EndContext();
            BeginContext(2390, 17, false);
#line 68 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
               Write(RosterDict["WR2"]);

#line default
#line hidden
            EndContext();
            BeginContext(2407, 128, true);
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\'rostRow\'>\r\n                <h3><strong>RB</strong></h3>\r\n                <h4>");
            EndContext();
            BeginContext(2536, 17, false);
#line 72 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
               Write(RosterDict["RB2"]);

#line default
#line hidden
            EndContext();
            BeginContext(2553, 131, true);
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\'rostRow\'>\r\n                <h3><strong>Bench</strong></h3>\r\n                <h4>");
            EndContext();
            BeginContext(2685, 20, false);
#line 76 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
               Write(RosterDict["Bench1"]);

#line default
#line hidden
            EndContext();
            BeginContext(2705, 161, true);
            WriteLiteral("</h4>\r\n            </div>\r\n    </div>\r\n    <div class=\'rostColumn\'>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>Bench</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(2867, 20, false);
#line 82 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["Bench2"]);

#line default
#line hidden
            EndContext();
            BeginContext(2887, 115, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>Bench</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(3003, 20, false);
#line 86 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["Bench3"]);

#line default
#line hidden
            EndContext();
            BeginContext(3023, 115, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>Bench</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(3139, 20, false);
#line 90 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["Bench4"]);

#line default
#line hidden
            EndContext();
            BeginContext(3159, 115, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\'rostRow\'>\r\n            <h3><strong>Bench</strong></h3>\r\n            <h4>");
            EndContext();
            BeginContext(3275, 20, false);
#line 94 "C:\Users\riley_000\Documents\Education\Coding Dojo\Week-10 Project Week\DraftChat\Views\Shared\RosterPartial.cshtml"
           Write(RosterDict["Bench5"]);

#line default
#line hidden
            EndContext();
            BeginContext(3295, 41, true);
            WriteLiteral("</h4>\r\n        </div>\r\n    </div>\r\n</div>");
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