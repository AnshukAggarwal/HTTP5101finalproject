<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="http5101finalproject_N01399681.ShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <%--To do:Create an interface to assist the user to view a particular student and also give the option to edit and delete.
    This takes care of Read, Update and delete in CRUD--%>
    <a href="ListPages.aspx">Go Back To Full List</a>
    <div id="page" runat="server">
        <h2>Below are the details of the page you selected</h2>
        Title: <span id="page_title" runat="server"></span><br />
        Body: <span id="page_body" runat="server"></span><br />
    </div>
    <asp:Button onClick="Update_Page" runat="server" Text="Edit" />
    <asp:Button OnClick="Delete_Page" runat="server" Text="Delete"/>
</asp:Content>
