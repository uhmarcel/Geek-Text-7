<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorDetailsPage.aspx.cs" Inherits="GeekText.AuthorDetailsPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="AuthorInfoDiv" runat="server">
        <h2>
            <asp:Label ID="AuthorName_lbl" runat="server" Text ="AuthorName"></asp:Label></h2>
        <p>
            <asp:Label ID="AuthorShortBio_lbl" runat="server" Text ="ShortBio"></asp:Label></p>
    </div>

    <div id ="BooksByAuthorDiv" runat="server">
        <h2> Other Books By This Author</h2>
        <asp:GridView ID ="BookDetailsGridView" runat ="server" CssClass="table table-hover table-striped" AutoGenerateColumns ="false" DataKeyNames="ISBN,title,price" DataMember="ISBN"  >
            <Columns>
                <asp:BoundField DataField ="ISBN" HeaderText="ISBN" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/> <%--Hidden ISBN--%> 
                <asp:BoundField DataField ="title" HeaderText="Title"  />
                <asp:BoundField DataField ="bookAuthor.authorName" HeaderText="Author" />
                <asp:BoundField DataField ="price" HeaderText="Price" />
                <asp:TemplateField ShowHeader ="false" ItemStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Button ID ="ViewButton" runat ="server" Text="View Book Details" OnClick ="ViewButton_Click"  />
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>