<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterHome.aspx.cs" Inherits="BugTrackingWebApplication.TesterHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 183px;
            margin-top: 135px;
        }
        .auto-style2 {
            margin-left: 888px;
            margin-top: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" Text="Add New Bug Alert" />
        
        <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" Height="365px" Width="912px">
        </asp:GridView>
    </form>
</body>
</html>
