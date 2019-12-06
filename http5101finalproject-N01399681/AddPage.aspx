<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="http5101finalproject_N01399681.AddPage" %>
<asp:Content ID="newpage" ContentPlaceHolderID="body" runat="server">
    <%-- To do
        Create an interface to enable the user to add a page title and page body.
        Styling of the page--%>
    <h2>New Page</h2>
    <div class="form-row">
        <label>Page Title:</label>
        <asp:TextBox runat="server" ID="page_title"></asp:TextBox>
    </div>
    <div class="form-row">
        <label>Page Body:</label>
        <asp:TextBox TextMode="multiline" Columns="50" Rows="5" runat="server" ID="page_body"></asp:TextBox>
        <%--<%//Referenced from https://stackoverflow.com/questions/4508051/textarea-control-asp-net-c-sharp/4508107 %>--%>
    </div>

    <asp:Button OnClick="Add_Page" Text="Add Page" runat="server" />
    </asp:Content>
