<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBugAlert.aspx.cs" Inherits="BugTrackingWebApplication.NewBugAlert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 73%;
            height: 212px;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style3 {
            width: 168px;
        }
        .auto-style4 {
            width: 325px;
        }
    </style>
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">Title :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="bugTitle" runat="server" Width="281px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Description :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="description" runat="server" Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Category :</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="category" runat="server" Width="291px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                </td>
                
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="text-align:center;">
                    <asp:Label ID="displayLabel" runat="server"></asp:Label>
                </td>
                
            </tr>
        </table>
    </asp:Content>
