<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BugTrackingWebApplication.Registration" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 111%;
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
    <asp:Label ID="notAdminErrorLabel" runat="server" ForeColor="Red" Text="Only admin can do registration."/>
    <asp:Panel ID="regPanel" runat="server" Visible="false">
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11" colspan="2"><strong><h2>Register</h2></strong></td>
                
            </tr>
            <tr>
                <td class="auto-style2">Name :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="name" runat="server" Width="322px"></asp:TextBox>
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
                        <asp:ListItem Value="any">Select your role</asp:ListItem>
                        <asp:ListItem Value="dev">Developer</asp:ListItem>
                        <asp:ListItem Value="tester">Tester</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </td>
               
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Visible="false"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Visible="false" Text="User Added Successsfully."/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btnNewReg" runat="server" Text="Register New Entry" Visible="false" OnClick="btnNewReg_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btnGoProfile" runat="server" Text="Go to Profile" OnClick="btnGoProfile_Click" />
                </td>
            </tr>
        </table>
        </div>
        </asp:Panel>

</asp:Content>