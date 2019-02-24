<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="GeekText.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:ValidationSummary runat=server 
        HeaderText="There were errors on the page:" />

        
        <asp:Panel ID="CredentialsPanel" runat="server" BackColor="LightBlue" HorizontalAlign="Center" Width="500">
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="UserNameLabel" runat="server" Text="User Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">                
                <asp:TextBox ID="UserNameTextBox" runat="server" ></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="UserNameTextBox"
                ErrorMessage="User name is required."> *
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat=server 
                    ControlToValidate="UserNameTextBox" 
                    ErrorMessage="User name must be 3-10 letters." 
                    ValidationExpression="[a-zA-Z]{3,10}" />            
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="NickNameLabel" runat="server" Text="Nick Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="NickNameTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="PasswordLabel1" runat="server" Text="Password"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="PasswordTextBox1" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="PasswordTextBox1"
                ErrorMessage="A password is required."> *
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" Display="dynamic"
                ControlToValidate="PasswordTextBox1"
                ErrorMessage="Password must contain one of @#$%^&*/."
                ValidationExpression=".*[@#$%^&*/].*" />
            <asp:RegularExpressionValidator runat=server display=dynamic
                ControlToValidate="PasswordTextBox1" 
                ErrorMessage="Password must be 8-12 nonblank characters." 
                ValidationExpression="[^\s]{8,12}" />
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="PasswordLabel2" runat="server" Text="Re-enter Password"></asp:Label>
            </div>
            
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="PasswordTextBox2" runat="server"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="PasswordTextBox2"
                ErrorMessage="Re-enter password is required."> *
            </asp:RequiredFieldValidator>
            <asp:CompareValidator runat=server
                ControlToValidate=PasswordTextBox1
                ControlToCompare=PasswordTextBox2 
                ErrorMessage="Passwords do not match." />
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="EmailLabel1" runat="server" Text="Email Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="EmailTextBox1" runat="server"></asp:TextBox>
            </div>
            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ControlToValidate="EmailTextBox1" 
                ErrorMessage="Invalid Email Format.">
            </asp:RegularExpressionValidator>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="EmailLabel2" runat="server" Text="Re-enter Email Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="EmailTextBox2" runat="server"></asp:TextBox>
            </div>
            <asp:CompareValidator runat=server
                ControlToValidate=EmailTextBox1
                ControlToCompare=EmailTextBox2 
                ErrorMessage="Emails do not match." />
        </asp:Panel>
        <asp:Panel ID="PersonalInfoPanel" runat="server" BackColor="LightBlue" HorizontalAlign="Center" Width="500">
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            </div>
        </asp:Panel>
        <asp:Panel ID="AddressesPanel" runat="server" BackColor="LightBlue" HorizontalAlign="Center" Width="500">
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="StreetAddressLabel" runat="server" Text="Street Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="StreetAddressTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="StateTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="ZipLabel" runat="server" Text="Zip Code"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox>
            </div>
            <br />
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="SubmitButton_Click" />
            </div>
            <br />
        </asp:Panel>
        <!--<asp:Panel ID="CreditCardsPanel" runat="server" BackColor="LightBlue" HorizontalAlign="Center" Width="500">
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="CreditCardLabel" runat="server" Text="Credit Card Number"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="CreditCardTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="CcvLabel" runat="server" Text="CCV"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="CcvTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="ExpirationDateLabel" runat="server" Text="Expiration Date"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="ExpirationDateTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:Label ID="CcZipLabel" runat="server" Text="Zip Code"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:center;">
                <asp:TextBox ID="CcZipTextBox" runat="server"></asp:TextBox>
            </div>
            <br />
        </asp:Panel></-->
    </asp:Content>