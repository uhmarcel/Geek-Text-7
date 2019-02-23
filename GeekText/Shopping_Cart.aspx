<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shopping_Car.aspx.cs" Inherits="GeekText.WebForm1" %>--%>

<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shopping_Cart.aspx.cs" Inherits="GeekText.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div id ="BookDisplayDetailsDiv">
        <asp:GridView ID ="CartGridView" runat ="server" AutoGenerateColumns ="false">
            <Columns>
                <asp:BoundField DataField ="bookId" HeaderText="Book" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="qty" HeaderText="QTY" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="Price" HeaderText="Price" ItemStyle-Width="150px" />
                

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
