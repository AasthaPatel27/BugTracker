<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeveloperHome.aspx.cs" Inherits="BugTrackingWebApplication.DeveloperHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 47%;
            height: 339px;
            margin-left: 398px;
            margin-top: 47px;
        }
        .auto-style2 {
            width: 1677px;
        }
        .auto-style3 {
            width: 1665px;
        }
        .auto-style5 {
            width: 755px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">Bug Title :</td>
                <td class="auto-style3" id="title">
                    <asp:Label ID="bTitle" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Description :</td>
                <td class="auto-style3" id="description">
                    <asp:Label ID="description" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Category :</td>
                <td class="auto-style3" id="category">
                    <asp:Label ID="category" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Status :</td>
                <td class="auto-style3" id="status">
                    <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Comments :</td>
                <td class="auto-style3" id="comment">
                    <asp:Label ID="comment" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    &nbsp;</td>
              
            </tr>
        </table>
        
    </form>
</body>
</html>
