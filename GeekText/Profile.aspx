<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GeekText.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <asp:Panel ID="ProfilePanel" runat="server" BackColor="#E4E4E4" Height="280px" Width="1000px">
                <div style="height:30px;line-height:30px; padding-left:10px; padding-top:10px; float:left">
                    <asp:Label ID="UserNameLabel" runat="server" Text="Username:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedUserNameLabel" runat="server" Text=""></asp:Label>
                </div>
                <div style="height:30px;line-height:30px; padding-top:10px; padding-left:10px; padding-right:10px; float:right">
                    <asp:Button ID="EditProfileBtn" runat="server" Text="Edit Profile" OnClick="EditProfileBtn_Click"></asp:Button>
                </div>
                <br />
                <br />
                <div style="height:30px;line-height:30px; padding-left:10px;">
                    <asp:Label ID="NickNameLabel" runat="server" Text="Nick name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedNickNameLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="FirstNameLabel" runat="server" Text="First name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedFirstNameLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="LastNameLabel" runat="server" Text="Last name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedLastNameLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedEmailLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="savedAddressLabel" runat="server" Text="Address"></asp:Label>
                    <br />
                    <asp:Label ID="StreetAddressLabel" runat="server" Text="Street Address:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedStreetAddressLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="CityLabel" runat="server" Text="City:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedCityLabel" runat="server" Text=""></asp:Label>
                     &nbsp; &nbsp;
                    <asp:Label ID="StateLabel" runat="server" Text="State:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedStateLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="ZipLabel" runat="server" Text="Zip Code:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedZipCodeLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <!--
                    <asp:Label ID="CardLabel" runat="server" Text="Card Information"></asp:Label>
                    <br />
                    <asp:Label ID="CardNumberLabel" runat="server" Text="Card Number:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedCardNum" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="ExpirationLabel" runat="server" Text="Expiration Date:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedExpLabel" runat="server" Text=""></asp:Label>
                     &nbsp; &nbsp;
                    <asp:Label ID="CardCCV" runat="server" Text="CCV:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="savedCCVLabel" runat="server" Text=""></asp:Label>-->
                </div>
                <br />

            </asp:Panel>
            <asp:Panel ID="EditPanel" runat="server" BackColor="#E4E4E4"  Height="700px" Width="1000px">
                <div style="height:30px;line-height:30px; padding-left:10px; padding-top:10px; float:left;">
                    <asp:Label ID="CurrNickName" runat="server" Text="Current Nick name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currNickNameLabel" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="EditNickNameLabel" runat="server" Text="New nick name:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newNickNameTextBox" runat="server" Text=""></asp:TextBox>
                </div>
                <div style="height:30px; line-height:30px; padding-right:10px; padding-top:10px; float:right">
                    <asp:Button ID="BackToProfile" runat="server" padding-bottom="10px"  padding-right="10px" Text="Back To Profile" OnClick="BackToProfile_Click" />
                </div>
                <br />
                <br />
                <div style="height:30px;line-height:30px; padding-left:10px;">
                    <asp:Label ID="CurrFirstName" runat="server" Text="Current first name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currFirstNameLabel" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="EditFirstNameLabel" runat="server" Text="New first name:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newFirstNameTextBox" runat="server" Text=""></asp:TextBox>
                    <br />
                    <asp:Label ID="CurrLastName" runat="server" Text="Current last name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currLastNameLabel" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="EditLastNameLabel" runat="server" Text="New last name:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newLastNameTextBox" runat="server" Text=""></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="CurrEmail" runat="server" Text="Current Email:"></asp:Label>
                    <asp:Label ID="currEmailLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="EditEmailLabel" runat="server" Text="Email:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newEmailTextBox" runat="server" Text=""></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="EditOldPassLabel" runat="server" Text="Enter current password:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="oldPasswordTextBox" runat="server" Text=""></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="EditNewPassLabel" runat="server" Text="Enter New Password:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newPasswordTextBox" runat="server" Text=""></asp:TextBox>
                    &nbsp;
                    <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="newPasswordTextBox" 
                        Display="dynamic" 
                        ErrorMessage="Password must be 8-12 nonblank characters." 
                        ValidationExpression="[^\s]{8,12}" />                
                    &nbsp;
                    <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="newPasswordTextBox" 
                        Display="dynamic" 
                        ErrorMessage="Password must contain one of @#$%^&amp;*/." 
                        ValidationExpression=".*[@#$%^&amp;*].*" />
                &nbsp;
                <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="newPasswordTextBox" 
                        Display="dynamic" 
                        ErrorMessage="Password must contain at least one number." 
                        ValidationExpression=".*[0123456789].*" />
                    <br />
                    <asp:Label ID="EditNewPassLabel2" runat="server" Text="Re-enter New Password:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newPasswordTextBox2" runat="server" Text=""></asp:TextBox>
                    <br />
                    <asp:CompareValidator runat="server" 
                        ControlToCompare="newPasswordTextBox" 
                        ControlToValidate="newPasswordTextBox2" 
                        ErrorMessage="Passwords do not match." />
                    <br />
                    <br />
                    <asp:Label ID="EditAddress" runat="server" Text="Address"></asp:Label>
                    <br />
                    <asp:Label ID="CurrStreetAddress" runat="server" Text="Current Street Address:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currStreetAddresLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="CurrCity" runat="server" Text="Current City:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currCityLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID= "CurrState" runat="server" Text="State: "></asp:Label>
                    &nbsp;
                    <asp:Label ID="currStateLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="CurrZip" runat="server" Text="Current Zip Code:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currZipCodeLabel" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="EditStreetAddressLabel" runat="server" Text="Street Address:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newStreetAddressTextBox" runat="server" Text=""></asp:TextBox>
                    &nbsp; &nbsp;
                    <asp:Label ID="EditCityLabel" runat="server" Text="City:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newCityTextBox" runat="server" Text=""></asp:TextBox>
                     &nbsp; &nbsp;
                    <asp:Label ID= "EditStateLabel" runat="server" Text="State: "></asp:Label>
                     <asp:DropDownList ID="DropDownList" runat="server">
                    <asp:ListItem Value="none">Select a State</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AK</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>GA</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NH</asp:ListItem>
                    <asp:ListItem>NJ</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>TX</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                </asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Label ID="EditZipCodeLabel" runat="server" Text="Zip Code:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newZipCodeTextBox" runat="server" Text=""></asp:TextBox>
                    &nbsp;
                    <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="newZipCodeTextBox" 
                        ErrorMessage="Zipcode must be numbers only." 
                        ValidationExpression="^\d+$" />
                    <br />
                    <br />
                    <!--
                    <asp:Label ID="EditCard" runat="server" Text="Card Information"></asp:Label>
                    <br />
                    <asp:Label ID="EditCardLabel" runat="server" Text="Card Number:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newCardNumTextBox" runat="server" Text=""></asp:TextBox>
                    &nbsp; &nbsp;
                    <asp:Label ID="EditExpDateLabel" runat="server" Text="Expiration Date:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newExpDateTextBox" runat="server" Text=""></asp:TextBox>
                     &nbsp; &nbsp;
                    <asp:Label ID="EditCCVLabel" runat="server" Text="CCV:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newCCVTextboxTextBox" runat="server" Text=""></asp:TextBox>
                    <br />
                    <br />-->
                    <div style="text-align:center;">
                        <asp:Button ID="SubmitEditBtn" runat="server" Text="Submit" OnClick="SubmitEditBtn_Click"></asp:Button>
                        <br />
                        <asp:Label ID="SuccesLabel" runat="server" padding-bottom="10px" Text=""></asp:Label>
                    </div>                    
                </div>
            </asp:Panel>
</asp:Content>
