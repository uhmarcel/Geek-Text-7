<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeekText._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>GeekText</h1>
        <p class="lead">GeekText is an online web application which targets a particular niche in technology. </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>View Books</h2>
            <p>
                View our catalog of books and their details including genre author cover isbn and other stuff.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Create a Profile</h2>
            <p>
                Create a User profile to enjoy the benefits of having a user profile.
            </p>
            <p>
                <a class="btn btn-default" href="SignUp.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>View Cart</h2>
            <p>
                View your shopping cart where you put items and other stuff and things and thing related to stuff.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Search Books</h2>
            <p>
                Look for the books you want. You can search by title, genre, rating, or just the best sellers.
            </p>
            <p>
                <a class="btn btn-default" href="searchbooks">Search now &raquo;</a>
            </p>
        </div>
    </div>



</asp:Content>
