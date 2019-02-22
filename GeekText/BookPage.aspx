<%@ Page Title="Book page template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="GeekText.BookPageTemplate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">

    <style>
        .imageContainer > img:hover {
            width: 400px;
            height: 600px;
        }
    </style>
    <section class="row">
        <h1>
            <asp:Label ID="Book_Name" runat="server" Text="Sample"> </asp:Label></h1>
        <h3>Author:
            <asp:Label ID="Book_Author" runat="server" Text="Sample"> </asp:Label></h3>

        <div class="imageContainer">
            <asp:Image ID="Book_Cover" CssClass="img" runat="server"  />
        </div>

        <p>
            Description: 
            <asp:Label ID="Book_description" runat="server" Text="sample"></asp:Label>
        </p>
        <p>
            Genre(s):
            <asp:Label ID="Book_Genre" runat="server" Text="Sample"></asp:Label>
        </p>
        <p>
            Copyright Year:
            <asp:Label ID="Publishing_Year" runat="server" Text="Sample"></asp:Label>
        </p>
        <p>
            Publishing Company:
            <asp:Label ID="Publishing_Company" runat="server" Text="Sample"></asp:Label>
        </p>
        <p>
            Publishing Location:
         <asp:Label ID="Publishing_Location" runat="server" Text="Sample"></asp:Label>
        </p>

    </section>

    <section class="row">
        <div id="BookDetailDiv">
            <asp:GridView ID="BookDetailsGridView" runat="server" CssClass="table table-hover table-striped">
                <Columns>
                    <asp:BoundField DataField="bookTitle" HeaderText="Title" />
                    <asp:BoundField DataField="bookAuthor" HeaderText="Author" />
                    <asp:BoundField DataField="bookPrice" HeaderText="Price" />
                    <asp:BoundField DataField="publishingLocation" HeaderText="Title" />
                    <asp:BoundField DataField="publishingYear" HeaderText="Author" />
                    <asp:BoundField DataField="publishingCompany" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </div>
    </section>

    <section id='reviewsSection' class="row">
        <h3>User Reviews</h3>

        <asp:Repeater ID="reviewsRepeater" runat="server">
            <ItemTemplate>
                 <div class="alert alert-primary">
                    <h4><asp:Label ID ="Review_Nickname" runat ="server" Text ='<%#Eval("userChosenDisplay")%>'></asp:Label> - <asp:Label ID ="Review_Rating" runat="server" Text='<%#Eval("reviewRating") + "/5 rating"%>'></asp:Label></h4>
                    <p><asp:Label ID ="Review_Text" runat ="server" Text ='<%#Eval("reviewText")%>'> </asp:Label></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        
        <% if (currentUserOwnsBook) { %>
            <p>You own this book!</p>
            <button class="btn btn-default" type="button" data-toggle="collapse" data-target="#createReviewDiv" aria-expanded="false" aria-controls="createReviewDiv">Add a review for this book</button>
            <h1></h1> <%--Replace later with spacing--%>
            <div id='createReviewDiv' class="collapse">
                <div class="card card-body">
                    <label for="createReviewTextarea" class="inline">Write a review of the book</label>
                    <span id="reviewRatingSpan" class="pull-right">
                        <label>Rating:</label>
                        <i id='ratingStar1' class="far fa-star"></i>
                        <i id='ratingStar2' class="far fa-star"></i>
        	            <i id='ratingStar3' class="far fa-star"></i>
        	            <i id='ratingStar4' class="far fa-star"></i>
        	            <i id='ratingStar5' class="far fa-star"></i>
                    </span>
                    <textarea id="createReviewTextarea" runat="server" class="form-control" rows="5" style="min-width: 100%" placeholder="Share your thoughts about this book"></textarea>
                    <input id="createReviewRating" class="hidden" type="text" runat="server" />
                    <input id="createReviewDisplay" class="hidden" type="text" runat="server" value="3"/>
                    <label class="inline">Submit as: </label>
                    <label class="radio-inline"><input type="radio" onclick="setUserDisplay(1)" runat="server" checked><span id="radioFullname" runat="server">Full name</span></label>
                    <label class="radio-inline"><input type="radio" onclick="setUserDisplay(2)" runat="server"><span id="radioNickname" runat="server">Nickname</span></label>
                    <label class="radio-inline"><input type="radio" onclick="setUserDisplay(3)" runat="server" >Anonymous</label> 
                    <asp:Button ID="createReviewSubmitBtn" Text="Submit" OnClick="submitUserReview" UseSubmitBehavior="false" runat="server" CssClass="btn btn-link pull-right"/>
                </div>
            </div>
        <% } else {%>
            <p>Reviews are reserved for users who own this book.</p>
        <% } %>

    </section>

    <script type="text/javascript" src="BookPage.js"></script>

</asp:Content>
