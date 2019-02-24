<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GeekText.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <asp:Panel ID="CredentialsPanel" runat="server" BackColor="LightBlue">
                <div style="height:30px;line-height:30px; text-align:left;">
                    <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedUserNameLabel" runat="server" Text=""></asp:Label>
                </div>
                <asp:Panel ID="NickNamePanel" runat="server" BackColor="LightBlue"  Width="400">
                    <div style="height:30px;line-height:30px; text-align:left;">
                        <asp:Label ID="NickNameLabel" runat="server" Text="Nick Name"></asp:Label>
                        &nbsp;
                        <asp:Label ID="savedNickNameLabel" runat="server" Text=""></asp:Label>                       
                        </div>
                        <div style="height:30px;line-height:30px; text-align:left;">
                            <asp:TextBox ID="TextBox1" runat="server" align ="left"></asp:TextBox>
                            <asp:Button ID="NickNameButton" runat="server" align="right" Text="Change Nick Name" ></asp:Button>
                        </div>
                </asp:Panel>
                <asp:Panel ID="ChangePassPanel" runat="server" BackColor="LightBlue"  Width="400">
                        <div style="height:30px;line-height:30px; text-align:left;">
                            <asp:Label ID="oldPasswordLabel" runat="server" Text="Enter Old Password"></asp:Label>
                        </div>
                        <div style="height:30px;line-height:30px; text-align:left;">
                            <asp:TextBox ID="oldPasswordTextBox" runat="server" align="left"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="changePasswordBtn" runat="server" align="right" Text="Change Password" ></asp:Button>
                        </div>
                    </asp:Panel>
                <div style="height:30px;line-height:30px; text-align:left;">
                    <asp:Label ID="EmailLabel1" runat="server" Text="Email Address"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedEmailLabel" runat="server" Text=""></asp:Label>
                </div>
            </asp:Panel>
</asp:Content>
