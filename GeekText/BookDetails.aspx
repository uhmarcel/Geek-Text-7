<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="GeekText.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Current Books in Database</h3>
    <div id ="BookDisplayDetailsDiv">
        <asp:GridView ID ="BookDetailsGridView" runat ="server" AutoGenerateColumns ="false">
            <Columns>
                <asp:BoundField DataField ="Name" HeaderText="BookName" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="Author" HeaderText="Author" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="Genre" HeaderText="Genre" ItemStyle-Width="150px" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
