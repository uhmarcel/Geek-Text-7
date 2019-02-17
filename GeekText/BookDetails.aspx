<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="GeekText.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Current Books in Database</h1>
    <div id ="BookDisplayDetailsDiv">
        <asp:GridView ID ="BookDetailsGridView" runat ="server" CssClass="table table-hover table-striped" AutoGenerateColumns ="false" >
            <Columns>
                <asp:BoundField DataField ="ISBN" HeaderText="ISBN" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/> <%--Hidden ISBN--%> 
                <asp:BoundField DataField ="title" HeaderText="Title"  />
                <asp:BoundField DataField ="bookAuthor.authorName" HeaderText="Author" />
                <asp:BoundField DataField ="price" HeaderText="Price" />
                <asp:TemplateField ShowHeader ="false" >
                    <ItemTemplate>
                        <asp:Button ID ="ViewButton" runat ="server" CausesValidation="false" Text="View Book Details" OnClick="ViewButton_Click"  />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

