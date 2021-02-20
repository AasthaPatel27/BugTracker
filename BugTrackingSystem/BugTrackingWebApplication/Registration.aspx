<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BugTrackingWebApplication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 111%;
            margin-left: 494px;
            margin-top: 175px;
            height: 235px;
            margin-bottom: 0px;
        }
        .auto-style2 {
            width: 384px;
     
        }
        .auto-style3 {
            width: 384px;
            height: 45px;
        }
        .auto-style4 {
            height: 45px;
            width: 988px;
        }
        .auto-style5 {
            width: 988px;
        }
        .auto-style6 {
            margin-bottom: 10px;
        }
        .auto-style7 {
            width: 384px;
            height: 41px;
        }
        .auto-style8 {
            width: 988px;
            height: 41px;
        }
        .auto-style9 {
            width: 384px;
            height: 42px;
        }
        .auto-style10 {
            width: 988px;
            height: 42px;
        }
        .auto-style11 {
            width: 384px;
            height: 40px;
        }
    </style>
</head>
<body style="width: 383px">
    <form id="form1" runat="server">
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11" style="text-align:center;" colspan="2"><strong><h2>Register</h2></strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2">Name :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="name" runat="server" Width="322px" CssClass="auto-style6" Height="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Email :</td>
                <td class="auto-style4">
                    <asp:TextBox ID="email" runat="server" Width="323px" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Contact:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="contact" runat="server" Width="323px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Password:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="password" runat="server" Width="324px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Role:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="role" runat="server" Width="330px">
                        <asp:ListItem>Select your role</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Developer</asp:ListItem>
                        <asp:ListItem>Tester</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
                </td>
               
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
