<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="GeekText.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Current Books in Inventory</h1>
        <br />
        <div id="LeftDivision" style="float: left; width: 900px;">
            <asp:Panel ID="SearchByTitle" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" Font-Italic="True" ForeColor="#666666" Width="529px" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" Height="25px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Width="91px" Text="Search" />
            </asp:Panel>
            <asp:Panel ID="BooksSorting" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Sort by:" Font-Bold="true" Font-Size="Smaller"></asp:Label>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="559px" Height="23px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True">Default</asp:ListItem>
                    <asp:ListItem>Title</asp:ListItem>
                    <asp:ListItem>Author</asp:ListItem>
                    <asp:ListItem>Price</asp:ListItem>
                    <asp:ListItem>Rating</asp:ListItem>
                    <asp:ListItem>Release Date</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" Width="261px" Visible="False">
                    <asp:ListItem>Ascending</asp:ListItem>
                    <asp:ListItem>Descending</asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
            <asp:Panel ID="Pagination2" runat="server" Style="float: right;" Width="214px">
                <asp:Button ID="Button4" runat="server" Text="Previous" OnClick="Button2_Click" Enabled="False" />
                <asp:Label ID="Label11" runat="server" Text="1"></asp:Label>
                <asp:Label ID="Label12" runat="server" Text="-"></asp:Label>
                <asp:Label ID="Label13" runat="server" Text="2"></asp:Label>
                <asp:Label ID="Label14" runat="server" Text="|"></asp:Label>
                <asp:Label ID="Label15" runat="server" Text="3"></asp:Label>
                <asp:Button ID="Button5" runat="server" Text="Next" OnClick="Button3_Click" Enabled="False" Width="83px" />
                <br />
                <br />
            </asp:Panel>
            <asp:Panel ID="BookDisplayDetailsDiv" runat="server">
                <asp:GridView ID="BookDetailsGridView" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="ISBN,title,price" DataMember="ISBN">
                    <Columns>
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                            <HeaderStyle CssClass="hidden"></HeaderStyle>

                            <ItemStyle CssClass="hidden"></ItemStyle>
                        </asp:BoundField>
                        <%--Hidden ISBN--%>
                        <asp:BoundField DataField="title" HeaderText="Title" />
                        <asp:BoundField DataField="bookAuthor.authorName" HeaderText="Author" />
                        <asp:BoundField DataField="genre" HeaderText="Genre" />
                        <asp:BoundField DataField="bestSeller" HeaderText="Best Seller" />
                        <asp:BoundField DataField="price" HeaderText="Price" />
                        <asp:BoundField DataField="bookRating" HeaderText="Rating" />
                        <asp:TemplateField HeaderText="Cover" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"
                                    ImageUrl='<%#"data:Image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("bookCover"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="false" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <asp:Button ID="ViewButton" runat="server" CausesValidation="false" Text="View Book Details" OnClick="ViewButton_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="80px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<a href="/Shopping_Cart"><span class="glyphicon glyphicon-shopping-cart"></span></a>' ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Button ID="AddButton" runat="server" CausesValidation="false" Text="Add to cart" OnClick="AddButton_OnClick" />
                            </ItemTemplate>

                            <ItemStyle Width="50px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="Pagination1" runat="server" Style="float: right;" Width="214px">
                <asp:Button ID="Button2" runat="server" Text="Previous" OnClick="Button2_Click" Enabled="False" />
                <asp:Label ID="Label5" runat="server" Text="1"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="-"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="2"></asp:Label>
                <asp:Label ID="Label8" runat="server" Text="|"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="3"></asp:Label>
                <asp:Button ID="Button3" runat="server" Text="Next" OnClick="Button3_Click" Enabled="False" Width="83px" />
            </asp:Panel>
        </div>
        <div id="RightDivision" style="float: right; width: 178px;">
            <asp:Label ID="Label10" runat="server" Text="Filter by:" Font-Bold="true" Font-Size="Smaller"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="FilterByGenre" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Genre"></asp:Label>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="GeekTextBookGenre1" DataTextField="bookGenre" DataValueField="bookGenre" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" Height="21px"></asp:CheckBoxList>
                <asp:SqlDataSource ID="GeekTextBookGenre1" runat="server" ConnectionString="<%$ ConnectionStrings:GeekTextConnectionString %>" SelectCommand="SELECT DISTINCT [bookGenre] FROM [Book] ORDER BY [bookGenre]"></asp:SqlDataSource>
                <br />
            </asp:Panel>
            <asp:Panel ID="FilterByBestSeller" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Best Seller"></asp:Label>
                <br />
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Only Best Sellers" />
                <br />
                <br />
            </asp:Panel>
            <asp:Panel ID="FilterByRating" runat="server">
                <asp:Label ID="Label3" runat="server" Text="Rating"></asp:Label>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                    <asp:ListItem Value="1">1 star</asp:ListItem>
                    <asp:ListItem Value="2">2 stars</asp:ListItem>
                    <asp:ListItem Value="3">3 stars</asp:ListItem>
                    <asp:ListItem Value="4">4 stars</asp:ListItem>
                    <asp:ListItem Value="5">5 stars</asp:ListItem>
                </asp:CheckBoxList>
            </asp:Panel>
        </div>
    </div>
</asp:Content>


