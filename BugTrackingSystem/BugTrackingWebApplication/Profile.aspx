<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BugTrackingWebApplication.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style11" style="text-align:center;" colspan="2"><strong><h2>Your Profile</h2></strong></td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="btnView" runat="server" Text="Click to View" OnClick="btnView_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">ID :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="perId" runat="server" Width="322px"></asp:TextBox>
                </td>
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
                    <asp:TextBox ID="contact" runat="server" Width="323px"></asp:TextBox>
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
                        <asp:ListItem Value="admin">Admin</asp:ListItem>
                        <asp:ListItem Value="dev">Developer</asp:ListItem>
                        <asp:ListItem Value="tester">Tester</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Created by :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="creater" runat="server" Width="322px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Visible="false"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Label ID="successLabel" runat="server" ForeColor="Green" Visible="false" Text="User Updated Successsfully."/>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>

