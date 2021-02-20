<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnresolvedBugList.aspx.cs" Inherits="BugTrackingWebApplication.UnresolvedBugList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 450px;
        }
        .auto-style2 {
            margin-left: 474px;
        }
        .auto-style3 {
            margin-left: 317px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CssClass="auto-style1" Height="305px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="509px">
        </asp:GridView>
        <p>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="View" />
            <asp:Button ID="Button2" runat="server" CssClass="auto-style3" Text="Claim" />
        </p>
    </form>
</body>
</html>
