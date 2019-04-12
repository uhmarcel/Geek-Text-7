<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shopping_Car.aspx.cs" Inherits="GeekText.WebForm1" %>--%>

<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shopping_Cart.aspx.cs" Inherits="GeekText.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div id="BookDisplayDetailsDiv">
        <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ISBN,quantity,price" OnRowDataBound="CartGridView_RowDataBound" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%-- <asp:BoundField DataField ="bookId" HeaderText="Book" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="qty" HeaderText="QTY" ItemStyle-Width="150px" />
                <asp:BoundField DataField ="Price" HeaderText="Price" ItemStyle-Width="150px" />--%>


                <asp:BoundField DataField="title" HeaderText="Title" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="quantity" HeaderText="QTY" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="price" HeaderText="Price" ItemStyle-Width="150px">


                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>


                <asp:TemplateField ItemStyle-Width="50px">
                    <ItemTemplate>

                        <asp:Button ID="AddItem" runat="server" CausesValidation="false" Text="+" OnClick="AddItem_OnClick" />
                    </ItemTemplate>

                    <ItemStyle Width="50px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="50px">
                    <ItemTemplate>

                        <asp:Button ID="RemoveItem" runat="server" CausesValidation="false" Text="-" OnClick="RemoveItem_OnClick" />
                    </ItemTemplate>

                    <ItemStyle Width="50px"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="50px">
                    <ItemTemplate>

                        <asp:Button ID="SaveItem" runat="server" CausesValidation="false" Text="Save for Later" OnClick="SaveItem_OnClick" />
                    </ItemTemplate>

                    <ItemStyle Width="50px"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Total" SortExpression="total">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotals" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <%--<asp:Label ID="Label7" runat="server"></asp:Label>--%>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />

                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Wich List" Font-Size="18pt"></asp:Label>
        <br />


        <asp:GridView ID="WishGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ISBN">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" ItemStyle-Width="150px">
                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="price" HeaderText="Price" ItemStyle-Width="150px">


                    <ItemStyle Width="150px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ItemStyle-Width="50px">
                    <ItemTemplate>

                        <asp:Button ID="AddItemtoCar" runat="server" CausesValidation="false" Text="Add to Car" OnClick="AddItemtoCar_OnClick" />
                    </ItemTemplate>

                    <ItemStyle Width="50px"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
