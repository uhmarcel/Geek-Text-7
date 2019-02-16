<%@ Page Title="Book page template" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="GeekText.BookPageTemplate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <section class="row">
        <h3>Book [name]<%--retrieve name--%></h3>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam dapibus accumsan orci, sagittis lobortis lacus molestie sit amet. Fusce in diam vitae magna egestas fringilla. Integer in leo rhoncus, feugiat ligula eget, rutrum lorem. Sed ultricies et ante sit amet finibus. Nunc eu blandit velit. Aliquam porta mollis magna volutpat pharetra. Donec diam justo, pellentesque at ipsum eu, ultrices auctor lorem. Suspendisse vitae gravida tellus. Maecenas nec dolor quam.</p>
        <p>Donec auctor mauris sit amet commodo volutpat. Sed semper sagittis neque nec mollis. Aliquam eget est sit amet libero cursus volutpat. Morbi lacinia bibendum metus. Phasellus consequat feugiat felis a interdum. Curabitur venenatis ut sem at vehicula. In ut vestibulum urna. Aliquam facilisis, enim sit amet facilisis vehicula, metus risus ornare sapien, ac egestas metus nisi in augue. Vivamus eu libero nulla. Phasellus finibus interdum nunc.</p>
        <p>Morbi a eros id nisi vehicula ornare lacinia in enim. Cras at tempor diam. Fusce finibus, orci sed vulputate pretium, elit enim posuere diam, vel interdum risus lectus a felis. Integer at ex id metus accumsan rhoncus. Aliquam quam nibh, gravida at faucibus nec, euismod non nisl. Sed congue pulvinar massa, non ultrices elit tempus eu. Nullam interdum nisi id mi pellentesque commodo. Praesent id rhoncus diam. Vivamus non diam diam. Nam justo tellus, mattis at tristique eget, lobortis sed libero. Curabitur placerat purus egestas, iaculis justo sit amet, blandit risus. Nunc vel mi hendrerit, rhoncus turpis a, rhoncus libero.</p>
    </section>

    <section id='commentSection' class="row">
        <div id='commentDiv' class="form-group" >
            <label for="commentTextarea">Write a review of the book</label>
            <textarea id="commentTextarea" class="form-control" rows="5" style="min-width:100%" ></textarea>
        </div>
    </section>

</asp:Content>