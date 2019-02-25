<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBooks.aspx.cs" Inherits="GeekText.SearchBooks" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    


   
    <style type="text/css">
        #form1 {
            width: 1132px;
            height: 518px;
        }
    </style>


    <div class="row" >
    <div id="form1" runat="server">
        <div style="float:left; width: 530px;">
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
                <asp:BoundField DataField ="genre" HeaderText="Genre"  />
                <asp:BoundField DataField ="bookRating" HeaderText="Rating" />
                <asp:BoundField DataField ="price" HeaderText="Price" />
                <asp:BoundField DataField ="bestSeller" HeaderText="Best Seller" />
                <asp:BoundField DataField ="description" HeaderText="Description" />
                <asp:TemplateField headertext="Cart" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Literal id="Literal1" runat="server" text='<a href="/Shopping_Cart"><span class="glyphicon glyphicon-shopping-cart"></span></a>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
        <div style="float:right; height: 366px;">
            <h3 style="width: 280px">Filter</h3>
            <div>
                <asp:Label ID="Label2" runat="server" Text="By Genre"></asp:Label>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="GeekTextBookGenre1" DataTextField="bookGenre" DataValueField="bookGenre" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"></asp:CheckBoxList>
                <asp:SqlDataSource ID="GeekTextBookGenre1" runat="server" ConnectionString="<%$ ConnectionStrings:GeekTextConnectionString %>" SelectCommand="SELECT DISTINCT [bookGenre] FROM [Book] ORDER BY [bookGenre]"></asp:SqlDataSource>
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="By Best Seller"></asp:Label>
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Only Best Sellers" />
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="By Rating"></asp:Label>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                    <asp:ListItem Value="1">1 star</asp:ListItem>
                    <asp:ListItem Value="2">2 stars</asp:ListItem>
                    <asp:ListItem Value="3">3 stars</asp:ListItem>
                    <asp:ListItem Value="4">4 stars</asp:ListItem>
                    <asp:ListItem Value="5">5 stars</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
