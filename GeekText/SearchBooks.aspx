<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBooks.aspx.cs" Inherits="GeekText.SearchBooks" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    


   
    <style type="text/css">
        #form1 {
            width: 998px;
            height: 518px;
        }
    </style>


    <div class="row" >
    <div id="form1" runat="server">
        <div style="float:left">
            <h1 style="width: 496px">Search Books</h1>
            <p style="width: 496px">
                <asp:TextBox ID="TextBox1" runat="server" Font-Italic="True" ForeColor="#666666" Width="423px">book title</asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
            </p>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="false">
                <Columns>
                <asp:BoundField DataField ="ISBN" HeaderText="ISBN" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"/> <%--Hidden ISBN--%> 
                <asp:BoundField DataField ="title" HeaderText="Title"  />
                <asp:BoundField DataField ="bookAuthor.authorName" HeaderText="Author" />
                <asp:BoundField DataField ="price" HeaderText="Price" />
                    <asp:BoundField DataField ="description" HeaderText="Description" />
                <asp:TemplateField headertext="Cart" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Literal id="Literal1" runat="server" text='<a href="/Shopping_Cart"><span class="glyphicon glyphicon-shopping-cart"></span></a>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </div>
    </div>

</asp:Content>
