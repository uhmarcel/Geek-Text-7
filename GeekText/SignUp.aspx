<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="GeekText.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:ValidationSummary runat=server 
        HeaderText="There were errors on the page:" />

        
        <asp:Panel ID="CredentialsPanel" runat="server" BackColor="#E4E4E4" HorizontalAlign="Center" Width="450px">
            <div style="height:30px;line-height:30px; text-align:left; padding-top:10px;padding-left:10px;padding-right:10px">
                <asp:Label ID="UserNameLabel" runat="server" Text="Username"></asp:Label>
            </div>
            <br />
            <div style="height:30px;line-height:30px; float:left; padding-left:10px;">                
                <asp:TextBox ID="UserNameTextBox" runat="server"  CausesValidation="true" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="UserNameTextBox" 
                    ErrorMessage="User name is required."> *
                </asp:RequiredFieldValidator>
            </div>
            <div style="float: right; text-align:right; padding-right:10px">
                <asp:RegularExpressionValidator runat="server" 
                    ControlToValidate="UserNameTextBox" 
                    ErrorMessage="User name must be 3-10 letters." 
                    ValidationExpression="[a-zA-Z]{3,10}" />
                <br />
                <asp:CustomValidator runat="server"
                    OnServerValidate="CheckUsernameClient"
                    ClientValidationFunction="CheckUsernameClient"
                    ControlToValidate="UserNameTextBox"
                    Display="Dynamic"
                    ValidateEmptyText="True"
                    ErrorMessage="Username is already in use."
                    ToolTip="Please select a different username."
                    />                        
            </div>
            <br />
            <br />
            <div style="height:30px;line-height:30px; text-align:left; padding-left:10px;padding-right:10px;">
                <asp:Label ID="NickNameLabel" runat="server" Text="Nick Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; text-align:left;padding-left:10px;">
                <asp:TextBox ID="NickNameTextBox" runat="server"></asp:TextBox>
            </div>
            <div style="height:30px;line-height:30px; text-align:left;padding-left:10px;padding-right:10px"">
                <asp:Label ID="PasswordLabel1" runat="server" Text="Password"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; vertical-align:middle; float:left; padding-left:10px;">
                <asp:TextBox ID="PasswordTextBox1" runat="server"></asp:TextBox>
            
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="PasswordTextBox1"
                    ErrorMessage="A password is required."> *
                </asp:RequiredFieldValidator>
            </div>
            <div style="float: right; text-align:right; padding-right:10px;">
                    <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="PasswordTextBox1" 
                        Display="dynamic" 
                        ErrorMessage="Password must be 8-12 nonblank characters." 
                        ValidationExpression="[^\s]{8,12}" />                
                    <br />
                    <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="PasswordTextBox1" 
                        Display="dynamic" 
                        ErrorMessage="Password must contain one of @#$%^&amp;*/." 
                        ValidationExpression=".*[@#$%^&amp;*].*" />
                <br />
                <asp:RegularExpressionValidator runat="server" 
                        ControlToValidate="PasswordTextBox1" 
                        Display="dynamic" 
                        ErrorMessage="Password must contain at least one number." 
                        ValidationExpression=".*[0123456789].*" />
            </div>
            <br />
            <br />
            <div style="height:30px;line-height:30px; text-align:left;padding-left:10px;padding-right:10px"">
                <asp:Label ID="PasswordLabel2" runat="server" Text="Re-enter Password"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; float:left; padding-left:10px;">
                <asp:TextBox ID="PasswordTextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="PasswordTextBox2"
                    ErrorMessage="Re-enter password is required."> *
                </asp:RequiredFieldValidator>
            </div>
            <div style="float:right; padding-right:10px"">
                <asp:CompareValidator runat="server" 
                    ControlToCompare="PasswordTextBox2" 
                    ControlToValidate="PasswordTextBox1" 
                    ErrorMessage="Passwords do not match." />
            </div>
            <br />
            <br />
            <div style="height:30px;line-height:30px; text-align:left;padding-left:10px;padding-right:10px">
                <asp:Label ID="EmailLabel1" runat="server" Text="Email Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; float:left;padding-left:10px;">
                <asp:TextBox ID="EmailTextBox1" runat="server"  CausesValidation="true" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="EmailTextBox1"
                    ErrorMessage="Email is required."> *
                </asp:RequiredFieldValidator>
            </div>
            <div style="float: right; text-align:right;padding-right:10px">
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                    ControlToValidate="EmailTextBox1" 
                    ErrorMessage="Invalid Email Format." 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
                <br />
                <asp:CustomValidator runat="server" 
                    OnServerValidate="CheckEmailClient"
                    ClientValidationFunction="CheckEmailClient"
                    ControlToValidate="EmailTextBox1"
                    Display="Dynamic"
                    ErrorMessage="Email is already in use."
                    ValidateEmptyText="True" />
            </div> 
            <br />
            <br />
            <div style="height:30px;line-height:30px; text-align:left;padding-left:10px;padding-right:10px">
                <asp:Label ID="EmailLabel2" runat="server" Text="Re-enter Email Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; float:left;padding-left:10px">
                <asp:TextBox ID="EmailTextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" 
                    ControlToValidate="EmailTextBox2"
                    ErrorMessage="Re-enter email is required."> *
                </asp:RequiredFieldValidator>
            </div>
            <div style="float:right;padding-right:10px">
                <asp:CompareValidator runat="server" 
                    ControlToCompare="EmailTextBox2" 
                    ControlToValidate="EmailTextBox1" 
                    ErrorMessage="Emails do not match." />
            </div> 
        </asp:Panel>
        <asp:Panel ID="PersonalInfoPanel" runat="server" BackColor="#E4E4E4" HorizontalAlign="left" Width="450px">
            <br />
            <br />
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="FirstNameTextBox" 
                        ErrorMessage="A first name is required."> *
                    </asp:RequiredFieldValidator>
            </div>
            <br />
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="LastNameTextBox" 
                        ErrorMessage="A last name is required."> *
                    </asp:RequiredFieldValidator>
            </div>
        </asp:Panel>
        <asp:Panel ID="AddressesPanel" runat="server" BackColor="#E4E4E4" HorizontalAlign="left" Width="450px">
            <br />
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="StreetAddressLabel" runat="server" Text="Street Address"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:TextBox ID="StreetAddressTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="StreetAddressTextBox" 
                        ErrorMessage="A street address is required."> *
                    </asp:RequiredFieldValidator>
            </div>
            <br />
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="CityTextBox" 
                        ErrorMessage="A city is required."> *
                    </asp:RequiredFieldValidator>
            </div>
            <br />
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
              
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
                <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="DropDownList" 
                        InitialValue="none" 
                        ErrorMessage="A state is required. "> *
            </asp:RequiredFieldValidator>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:Label ID="ZipLabel" runat="server" Text="Zip Code"></asp:Label>
            </div>
            <div style="height:30px;line-height:30px; padding-left:10px;padding-right:10px">
                <asp:TextBox ID="ZipTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="ZipTextBox" 
                        ErrorMessage="A zipcode is required."> *
                    </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" 
                    ControlToValidate="ZipTextBox" 
                    ErrorMessage="Zipcode must be numbers only." 
                    ValidationExpression="^\d+$" />
            </div>
            <br />
            <div style="height:30px;line-height:30px; padding-bottom:10px;padding-right:10px; text-align:center;">
                <asp:Button ID="SubmitButton" Text="Submit" runat="server" OnClick="SubmitButton_Click" />
            </div>
            <br />
        </asp:Panel>
        <!--<asp:Panel ID="CreditCardsPanel" runat="server" BackColor="#E4E4E4"  HorizontalAlign="Center" Width="500">
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