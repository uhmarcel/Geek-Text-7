<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GeekText.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Panel ID="Panel1" runat="server" BackColor="Wheat">
        <asp:Login ID="Login1" runat="server"></asp:Login>
    </asp:Panel>
</asp:Content>
