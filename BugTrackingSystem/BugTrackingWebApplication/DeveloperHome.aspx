<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeveloperHome.aspx.cs" Inherits="BugTrackingWebApplication.DeveloperHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 59%;
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
            width: 3245px;
        }
        .auto-style6 {
            width: 1665px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            You have below bug Alert to Resolve:</div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">Bug Title&nbsp; :</td>
                <td class="auto-style6" id="title">
                    <asp:Label ID="bugTitle" runat="server" Text="-"></asp:Label>
                &nbsp;(<asp:Label ID="BugIdLable" runat="server" Text="-"></asp:Label>
                    )</td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Description :</td>
                <td class="auto-style3" id="description">
                    <asp:Label ID="description" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Category :</td>
                <td class="auto-style3" id="category">
                    <asp:Label ID="category" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Bug Status :</td>
                <td class="auto-style3" id="status">
                    <asp:Label ID="status" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Comments :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="resolutionDescription" runat="server" Height="137px" Width="434px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="Set Resolved" OnClick="Button1_Click" />
                </td>
              
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <asp:Label ID="mydisplay" runat="server"></asp:Label>
    </form>
</body>
</html>
