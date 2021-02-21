<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BugDetail.aspx.cs" Inherits="BugTrackingWebApplication.BugDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 44%;
            margin-left: 362px;
            margin-top: 158px;
            height: 248px;
        }
        .auto-style2 {
            width: 196px;
        }
        .auto-style3 {
            width: 196px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 196px;
            height: 49px;
        }
        .auto-style6 {
            height: 49px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Bug Title :</td>
                <td>
                    <asp:Label ID="bugTitle" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Bug Description :</td>
                <td>
                    <asp:Label ID="description" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Bug Status :</td>
                <td>
                    <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Category :</td>
                <td class="auto-style6">
                    <asp:Label ID="category" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Bug Alert Description :</td>
                <td class="auto-style4">
                    <asp:Label ID="resolutionDescription" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
