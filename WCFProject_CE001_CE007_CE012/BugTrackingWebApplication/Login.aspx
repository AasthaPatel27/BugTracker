<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BugTrackingWebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 41%;
            margin-left: 389px;
        }
        .auto-style2 {
            width: 519px;
            text-align:center;
        }
        .auto-style4 {
            width: 519px;
            height: 27px;
            text-align:center;
        }
        .auto-style5 {
            width: 566px;
        }
        .auto-style6 {
            width: 169px;
            height: 51px;
        }
        .auto-style7 {
            height: 51px;
        }
        .auto-style8 {
            width: 169px;
            height: 37px;
        }
        .auto-style9 {
            height: 37px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <table class="auto-style1" >
            <tr>
                <td class="auto-style4" colspan="2"><strong><h2 class="auto-style5">Login</h2>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style8">Email :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="email" runat="server" Width="396px" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Password :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="password" runat="server" Width="396px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"   />
                </td>
              
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
