<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekText._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>GeekText</h1>
        <asp:Label ID="Label" runat="server" Text="GeekText is an online web store that is the one stop shopping experience for all your book needs." Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Font-Italic="True" ForeColor="#666666" Width="277px" AutoPostBack="True" Height="25px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Width="91px" Text="Search" />
    </div>
    <h2>BestSellers</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSeller_One" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorLabelOneBS" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="Book_Name_One" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Button ID="View_Book_one" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="View_Book_one_Click" />
                <asp:HiddenField ID="Book_one_ISBN" runat="server" />
            </div>
            <br />
        </div>
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSeller_Two" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorLabelTwoBS" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="Book_Name_Two" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Button ID="View_Book_two" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="View_Book_two_Click" />
                <asp:HiddenField ID="Book_two_ISBN" runat="server" />
            </div>
            <br />
        </div>
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSeller_Three" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorLabelThreeBS" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="Book_Name_Three" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Button ID="View_Book_three" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="View_Book_three_Click" />
                <asp:HiddenField ID="Book_three_ISBN" runat="server" />
            </div>
            <br />
        </div>

    </div>
    <h2>Top Rated</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSellerOneImg" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorNameTROne" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="BestSellerOnePrice" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Button ID="ViewBSOne" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="ViewBSOne_Click" />
                <asp:HiddenField ID="BSOneHF" runat="server" />
            </div>
            <br />
        </div>
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSellerTwoImg" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorNameTRTwo" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="BestSellerTwoPrice" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />

                <asp:Button ID="ViewBSTwo" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="ViewBSTwo_Click" />
                <asp:HiddenField ID="BSTwoHF" runat="server" />
            </div>
            <br />
        </div>
        <div class="col-md-4">
            <div class="imageContainer">
                <asp:Image ID="BestSellerThreeImg" CssClass="img" runat="server" />
                <br />
                <asp:Label ID="AuthorNameTRThree" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Label ID="BestSellerThreePrice" runat="server" Text="Sample" Font-Size="Large"> </asp:Label>
                <br />
                <asp:Button ID="ViewBSThree" runat="server" Text="View Book" CssClass="btn btn-default" OnClick="ViewBSThree_Click" />
                <asp:HiddenField ID="BSThreeHF" runat="server" />
            </div>
            <br />
        </div>

    </div>


</asp:Content>
