<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContentPage.aspx.cs" Inherits="http5101finalproject_N01399681.ContentPage" %>
<asp:Content ID="ContentPage" ContentPlaceHolderID="body" runat="server">
    <div id="httppage" runat="server">
        <h2>Page Details</h2>
        Page Title: <asp:TextBox ID="page_title" runat="server"></asp:TextBox><br />
        Page Body: <asp:TextBox id="page_body" runat="server"></asp:TextBox><br />
    </div>
    <div>
        <%--<asp:Button runat="server" text="Done" OnClick="Done_Update"/>--%>
    </div>
</asp:Content>
