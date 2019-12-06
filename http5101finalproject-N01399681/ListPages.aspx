<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="http5101finalproject_N01399681.ListPages" %>
<asp:Content ID="pages_list" ContentPlaceHolderID="body" runat="server">
        <h1>My Pages</h1>
        <div id="page-nav">
            <ul class="flex">
                <li><a href="#">Page 1</a></li>
                <li><a href="#">Page 2</a></li>
                <li><a href="#">Page 3</a></li>
            </ul>
            <asp:label for="page_search" runat="server">Search:</asp:label>
            <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
            <asp:Button runat="server" text="submit"/>
        </div>
        <a href="AddPage.aspx">New Page</a>
        <div class="output" runat="server">
            <div class="output">
                <div class="col">Page Title</div>
                <div class="col">Page Body</div>
            </div>
            <div id="pages_result" runat="server">

            </div>
        </div>
</asp:Content>
