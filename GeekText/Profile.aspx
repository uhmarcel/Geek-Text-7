<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GeekText.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <asp:Panel ID="CredentialsPanel" runat="server" BackColor="#E4E4E4" Height="230px" Width="819px">
                <div style="height:30px;line-height:30px; padding-left:10px;">
                    <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedUserNameLabel" runat="server" Text=""></asp:Label>
                    <div style="height:30px;line-height:30px; ">
                        <asp:Label ID="NickNameLabel" runat="server" Text="Nick Name"></asp:Label>
                        &nbsp;
                        <asp:Label ID="savedNickNameLabel" runat="server" Text=""></asp:Label>                       
                        </div>
                        <div style="height:30px;line-height:30px;">
                            <asp:TextBox ID="newNickNameTextBox" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="NickNameButton" runat="server" Text="Change Nick Name" OnClick="NickNameButton_Click" ></asp:Button>
                            
                        </div>
                        <div style="height:30px;line-height:30px;">
                            <br />
                            <asp:Label ID="oldPasswordLabel" runat="server" Text="Enter Old Password"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="oldPasswordTextBox" runat="server" ></asp:TextBox>    
                            &nbsp;&nbsp;
                            <asp:Label ID="enterNewPassLabel" runat="server" Text="Enter New Password"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="newPasswordTextBox" runat="server" ></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="changePasswordBtn" runat="server" Text="Change Password" OnClick="changePasswordBtn_Click" ></asp:Button>
                            <br />
                            <asp:Label ID="EmailLabel1" runat="server" Text="Email Address"></asp:Label>
                            &nbsp;
                            <asp:Label ID="savedEmailLabel" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:TextBox ID="newEmailTextBox" runat="server" ></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="changeEmailButton" runat="server" Text="Change Email" OnClick="changeEmailButton_Click" ></asp:Button>
                        </div>
                </div>
            </asp:Panel>
</asp:Content>
