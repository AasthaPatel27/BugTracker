<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BugTrackingWebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Our Project: Bug Tracking System</h3>
    <p>In this project, we have implemented a system which can be used in the software indusrtry to to track the bug status alert which are found and reported by testers and then resolved by developers.</p>
    <h3>Below are the points which can be performed using this application.</h3>
    <ul>
        <li>Admin
            <ul>
                <li>Can register new users i.e. Testers and Develpers.</li>
                <li>Can view his/her profile.</li>
                <li>Can update his/her profile.</li>
                <li>Can delete his/her profile.</li>
            </ul>
        </li>
        <li>Developer
            <ul>
                <li>Can view all the unresolved bugs list.</li>
                <li>Can claim the bug s/he is intrested to resolve.</li>
                <li>Can view the bug alert details s/he is working on.</li>
                <li>Can resolve the bug s/he is currently working on.</li>
                <li>Can view his/her profile.</li>
                <li>Can update his/her profile.</li>
                <li>Can delete his/her profile.</li>
            </ul>
        </li>
        <li>Tester
            <ul>
                <li>Can view all the bug alerts s/he has created earlier.</li>
                <li>Can view anybug alert details s/he has created previously.</li>
                <li>Can create a new bug alert whenever s/he detencts it.</li>
                <li>Can delete any bug alert which is created previosly.</li>
                <li>Can view his/her profile.</li>
                <li>Can update his/her profile.</li>
                <li>Can delete his/her profile.</li>
            </ul>
        </li>
    </ul>
</asp:Content>
