<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="http5101finalproject_N01399681.ListPages" %>
<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">
        <h1>My Pages</h1>
        <div id="page-nav">
            
            <asp:label for="page_search" runat="server">Search:</asp:label>
            <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
            <asp:Button runat="server" text="submit"/>
        </div>
        <%--Create a link to add a new Page--%>
        <a href="AddPage.aspx">New Page</a>
        <div class="table" runat="server">
            <div class="listitem">
                <div class="col2">Page Title</div>
                <div class="col2last">Page Body</div>
            </div>
            <div id="pages_result" runat="server">

            </div>
        </div>
</asp:Content>
