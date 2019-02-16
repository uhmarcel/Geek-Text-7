<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="GeekText.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Current Books in Database</h3>
    <div id ="BookDisplayDetailsDiv">
        <asp:GridView ID ="BookDetailsGridView" runat ="server" CssClass="table table-hover table-striped" AutoGenerateColumns ="false" OnRowDataBound="BookDetailsGridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField ="ISBN" HeaderText="ISBN" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/> <%--Hidden ISBN--%> 
                <asp:BoundField DataField ="bookTitle" HeaderText="Title" />
                <asp:BoundField DataField ="bookAuthor" HeaderText="Author" />
                <asp:BoundField DataField ="bookPrice" HeaderText="Price" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

