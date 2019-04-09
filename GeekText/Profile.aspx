<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GeekText.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
            <asp:Panel ID="ProfilePanel" runat="server" BackColor="#E4E4E4" Height="300px" Width="1000px">
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
                </div>
                 <br />
                <br />
                <br />
                  <br />
                <br />
                <br />              
                
                <div style="height:30px;line-height:30px; padding-bottom:10px; padding-right:10px; text-align:right;">
                    <asp:Button ID ="viewCreditCardBttn" runat="server" Text="View Credit Cards" OnClick="viewCreditCardBttn_Click"></asp:Button>                    
                <br />
                </div>
                <div style="height:30px;line-height:30px; padding-bottom:10px; padding-right:10px; text-align:right; ">
                    <asp:Button ID ="viewShipAddBttn" runat="server" Text="View Shipping Addresses" OnClick="viewShipAddBttn_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="EditPanel" runat="server" BackColor="#E4E4E4"  Height="680px" Width="1000px" Visible="False">
                <div style="height:30px;line-height:30px; padding-left:10px; padding-top:10px; float:left;">
                    <asp:Label ID="CurrNickName" runat="server" Text="Current Nick name:"></asp:Label>
                    &nbsp;
                    <asp:Label ID="currNickNameLabel" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="EditNickNameLabel" runat="server" Text="New nick name:"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="newNickNameTextBox" runat="server" Text=""></asp:TextBox>
                </div>
                <br />
                <div style="height:30px; line-height:30px; padding-right:10px; float:right">
                    <asp:Button ID="BackToProfile" runat="server" padding-right="10px" Text="Back To Profile" OnClick="BackToProfile_Click" />
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
                    &nbsp;<asp:Label ID="currEmailLabel" runat="server" Text=""></asp:Label>
                    &nbsp; &nbsp;
                    <asp:Label ID="EditEmailLabel" runat="server" Text="New Email:"></asp:Label>
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
                    <asp:Label ID="currStreetAddressLabel" runat="server" Text=""></asp:Label>
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
                        ErrorMessage="Zipcode must be five numbers only." 
                        ValidationExpression="^\d{5}$" />
                    
                    <div style="text-align:center;">
                        <asp:Button ID="SubmitEditBtn" runat="server" Text="Submit" OnClick="SubmitEditBtn_Click"></asp:Button>
                        <br />
                        <asp:Label ID="SuccessLabel" runat="server" padding-bottom="10px" Text=""></asp:Label>
                    </div>                    
                </div>
            </asp:Panel>
            <asp:Panel ID="ShippingPanel" runat="server" BackColor="#E4E4E4" Width="1000px" Visible="False">
                <div style="height:30px; line-height:30px; padding-top:10px; padding-right:10px; float:right">
                    <asp:Button ID="backAddBttn" runat="server" padding-right="10px" Text="Back To Profile" OnClick="backAddBttn_Click" />
                </div>
                <br />
                <br />
                <br />
                <asp:Label ID ="listOfAddresses" runat="server" Text="Current Shipping Addresses"></asp:Label>
                <br />
                <br />
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" InsertItemPosition="LastItem">
                    <AlternatingItemTemplate>
                        
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                            </td>
                            <td>
                                <asp:TextBox ID="streetAddressTextBox" runat="server" Text='<%# Bind("streetAddress") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="stateTextBox" runat="server" Text='<%# Bind("state") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="zipCodeTextBox" runat="server" Text='<%# Bind("zipCode") %>' />
                            </td>
                            <td>
                                <asp:TextBox ID="indexTextBox" runat="server" Text='<%# Bind("index") %>' />
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>No data was returned.</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Button ID="InsertButton" runat="server" ValidationGroup="INSERT" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                            </td>
                            <td>
                                <asp:TextBox ID="streetAddressTextBox" runat="server" Text='<%# Bind("streetAddress") %>' />
                                <asp:RequiredFieldValidator  runat="server" 
                                    ID="rfvInsertStreet"
                                    ValidationGroup="INSERT"
                                    ControlToValidate="streetAddressTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A street address is required. "> *
                                    </asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator runat="server"
                                    ValidationGroup="INSERT"
                                    ControlToValidate="streetAddressTextBox" 
                                    ErrorMessage="Must be alphanumeric." 
                                    ValidationExpression="^[a-zA-Z0-9\s]+$" />
                            </td>
                            <td>
                                <asp:DropDownList ID="stateInsertDropDownList" runat="server"
                                    SelectedValue = '<%# Bind("state") %>'>
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
                                    ID="rfvInsertStateddl"
                                    ControlToValidate="stateInsertDropDownList"
                                    ValidationGroup="INSERT"
                                    InitialValue="none" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A state is required. "> *
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />                                
                                 <asp:RequiredFieldValidator   runat="server" 
                                    ValidationGroup="INSERT"
                                    ID="rfvInsertCityTxt"
                                    ControlToValidate="cityTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A city is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator runat="server"
                                    ValidationGroup="INSERT"
                                    ControlToValidate="cityTextBox" 
                                    ErrorMessage="Must be letters only." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </td>
                            <td>
                                <asp:TextBox ID="zipCodeTextBox" runat="server" Text='<%# Bind("zipCode") %>' />
                                <asp:RequiredFieldValidator  runat="server" 
                                    ValidationGroup="INSERT"
                                    ID="rfvInsertZipTxt"
                                    ControlToValidate="zipCodeTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A zipcode is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator runat="server"
                                    ValidationGroup="INSERT"
                                    ControlToValidate="zipCodeTextBox" 
                                    ErrorMessage="Must be numbers only." 
                                    ValidationExpression="^\d{5}$" />  
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        
                    </ItemTemplate>
                    <LayoutTemplate>
                        <table runat="server">
                            <tr runat="server">
                                <td runat="server">
                                    <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                        <tr runat="server" style="">
                                            <th runat="server"></th>
                                            <th runat="server">Street Address</th>
                                            <th runat="server">State</th>
                                            <th runat="server">City</th>
                                            <th runat="server">Zipcode</th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" style=""></td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <tr style="">
                            <td></td>
                            <td>
                                <asp:Label ID="streetAddressLabel" runat="server" Text='<%# Eval("streetAddress") %>' />
                            </td>
                            <td>
                                <asp:Label ID="stateLabel" runat="server" Text='<%# Eval("state") %>' />
                            </td>
                            <td>
                                <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                            </td>
                            <td>
                                <asp:Label ID="zipCodeLabel" runat="server" Text='<%# Eval("zipCode") %>' />
                            </td>
                            <td>
                                <asp:Label ID="indexLabel" runat="server" Text='<%# Eval("index") %>' />
                            </td>
                        </tr>
                    </SelectedItemTemplate>
                </asp:ListView>
                <br />
                <asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowUpdated="GridView3_RowUpdated" OnRowEditing="GridView3_RowEditing" ShowFooter="True" DataKeyNames="index" Height="16px" Width="664px">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>                         
                            <ItemTemplate>
                            
                                <asp:LinkButton ID="EditLinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="DeleteLinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Index" SortExpression="index" >
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" Text='<%# Bind("index") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("index") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Street Address" SortExpression="streetAddress">
                            <EditItemTemplate>
                                <asp:TextBox ID="shipStreetTextBox" runat="server" Text='<%# Bind("streetAddress") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ID="rfvEditStreetTxt"
                                    ControlToValidate="shipStreetTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A street address is required. "> *
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="shipStreetTextBox" 
                                    ErrorMessage="Street Addresses must be alphanumeric only." 
                                    ValidationExpression="^[a-zA-Z0-9\s]+$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("streetAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State" SortExpression="state">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ShipDropDownList" runat="server"
                                    SelectedValue = '<%# Bind("state") %>'>
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
                                    ID="rfvEditStateTxt"
                                    ControlToValidate="ShipDropDownList" 
                                    InitialValue="none" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A state is required. "> *
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="City" SortExpression="city">
                            <EditItemTemplate>
                                <asp:TextBox ID="shipCityTextBox" runat="server" Text='<%# Bind("city") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ID="rfvEditCityTxt"
                                    ControlToValidate="shipCityTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A city is required. "> *
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="shipCityTextBox" 
                                    ErrorMessage="A city must be letters only." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("city") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Zipcode" SortExpression="zipCode">
                            <EditItemTemplate>
                                <asp:TextBox ID="shipZipTextBox" runat="server" Text='<%# Bind("zipCode") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="shipZipTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A zipcode is required. "> *
                                </asp:RequiredFieldValidator>
                                
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="shipZipTextBox" 
                                    ErrorMessage="Zipcode must be five numbers only." 
                                    ValidationExpression="^\d{5}$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("zipCode") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                    </Columns>                    
                </asp:GridView>
                <br />
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getAddressByID" TypeName="GeekTextLibrary.UserManager" UpdateMethod="updateShipAddress" OnUpdated="ObjectDataSource1_Updated" DeleteMethod="deleteAddress" InsertMethod="addUserAddress">
                    <DeleteParameters>
                        <asp:Parameter Name="index" Type="Int32" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="city" Type="String" />
                        <asp:Parameter Name="state" Type="String" />
                        <asp:Parameter Name="zipCode" Type="String" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                        <asp:Parameter Name="streetAddress" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="streetAddress" Type="String" />
                        <asp:Parameter Name="city" Type="String" />
                        <asp:Parameter Name="state" Type="String" />
                        <asp:Parameter Name="zipCode" Type="String" />
                        <asp:Parameter Name="index" Type="Int32" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary3" ForeColor="Red" runat="server" ValidationGroup="INSERT"/>
                <br />
                <br />
                <asp:Label ID="savedShipLabel" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </asp:Panel>
            <asp:Panel ID="CreditCardPanel" runat="server" BackColor="#E4E4E4" Width="1000px" Visible="False">
               
                <div style="height:30px; line-height:30px; padding-top:10px; padding-right:10px; float:right">
                    <asp:Button ID="backCardBttn" runat="server" padding-right="10px" Text="Back To Profile" OnClick="backCardBttn_Click" />
                </div>
                <br />
                <br />
                <br />               
                <asp:Label ID ="currCreditCardLabel" runat="server" Text="Current Credit Cards"></asp:Label>
                <br />
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" OnRowUpdated="GridView4_RowUpdated" OnRowEditing="GridView4_RowEditing" ShowFooter="True" DataKeyNames="cardIndex" ShowFooterWhenEmpty="true" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="insertCardLinkButton" OnClick="insertcardLinkButton_Click" ValidationGroup="INSERTCARD" runat="server">Insert</asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Card Number" SortExpression="CreditCardNumber">
                            <EditItemTemplate>
                                <asp:TextBox ID="cardTextBox" runat="server" Text='<%# Bind("CreditCardNumber") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="cardTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A Card Number is required. "> *
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="cardTextBox" 
                                    ErrorMessage="Card Number must be numbers only." 
                                    ValidationExpression="^\d+$" />
                            </EditItemTemplate>
                            
                            <ItemTemplate>
                                <asp:Label ID="cardLabel" runat="server" Text='<%# Bind("CreditCardNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ccTextBox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ValidationGroup="INSERTCARD"
                                    ControlToValidate="ccTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A Card Number is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server"
                                     ValidationGroup="INSERTCARD"
                                    ControlToValidate="ccTextBox" 
                                    ErrorMessage="Card Number must be numbers only." 
                                    ValidationExpression="^\d+$" />
                                                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiration Date" SortExpression="expirationDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="expTextBox" runat="server" Text='<%# Bind("expirationDate") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="expTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="expTextBox" 
                                    ErrorMessage="Expiration must be in MM/YYYY format." 
                                    ValidationExpression="^((0[1-9])|(1[0-2]))\/(20[1-2][0-9])$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="expLabel" runat="server" Text='<%# Bind("expirationDate") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="expTxtBox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ValidationGroup="INSERTCARD"
                                    ControlToValidate="expTxtBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="expTxtBox" 
                                    ErrorMessage="Expiration must be in MM/YYYY format." 
                                    ValidationExpression="^((0[1-9])|(1[0-2]))\/(20[1-2][0-9])$" />
                                                                
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CCV" SortExpression="cvv">
                            <EditItemTemplate>
                                <asp:TextBox ID="ccvTextBox" runat="server" Text='<%# Bind("cvv") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="ccvTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A CCV is required. "> *
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="ccvTextBox" 
                                    ErrorMessage="CCV must be numbers only." 
                                    ValidationExpression="^\d+$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="ccvLabel" runat="server" Text='<%# Bind("cvv") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="ccvTxtBox" runat="server" Text='<%# Bind("cvv") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ValidationGroup="INSERTCARD"
                                    ControlToValidate="ccvTxtBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A CCV is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="ccvTxtBox" 
                                    ErrorMessage="CCV must be numbers only." 
                                    ValidationExpression="^\d+$" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name" SortExpression="cardFirstName">
                            <EditItemTemplate>
                                <asp:TextBox ID="firstTextBox" runat="server" Text='<%# Bind("cardFirstName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="firstTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A first name is required. "> *
                                </asp:RequiredFieldValidator>                                
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="firstTextBox" 
                                    ErrorMessage="A first name must be letters." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="firstLabel" runat="server" Text='<%# Bind("cardFirstName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="firstTxtBox" runat="server" Text='<%# Bind("cardFirstName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ValidationGroup="INSERTCARD"
                                    ControlToValidate="firstTxtBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A first name is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="firstTxtBox" 
                                    ErrorMessage="A first name must be letters." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name" SortExpression="cardLastName">
                            <EditItemTemplate>
                                <asp:TextBox ID="lastTextBox" runat="server" Text='<%# Bind("cardLastName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="lastTextBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A last name is required. "> *
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="lastTextBox" 
                                    ErrorMessage="A last name must be letters." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lastLabel" runat="server" Text='<%# Bind("cardLastName") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="lastTxtBox" runat="server" Text='<%# Bind("cardFirstName") %>'></asp:TextBox>                                    
                                <asp:RequiredFieldValidator runat="server"
                                    ValidationGroup="INSERTCARD"
                                    ControlToValidate="lastTxtBox" 
                                    InitialValue="" 
                                    Text="*"
                                    ForeColor ="Red"
                                    ErrorMessage="A last name is required. "> *
                                </asp:RequiredFieldValidator>
                                <br />
                                 <asp:RegularExpressionValidator runat="server" 
                                    ControlToValidate="lastTxtBox" 
                                    ErrorMessage="A last name must be letters." 
                                    ValidationExpression="^[a-zA-Z]+$" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getCardsByID" TypeName="GeekTextLibrary.UserManager" UpdateMethod="updateCreditcard" OnUpdated="ObjectDataSource2_Updated" DeleteMethod="deleteCard" InsertMethod="addUserCard">
                    <DeleteParameters>
                        <asp:Parameter Name="cardIndex" Type="Int32" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="cardFirstName" Type="String" />
                        <asp:Parameter Name="cardLastName" Type="String" />
                        <asp:Parameter Name="creditCardNumber" Type="String" />
                        <asp:Parameter Name="cvv" Type="Int32" />
                        <asp:Parameter Name="expirationDate" Type="String" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="cardFirstName" Type="String" />
                        <asp:Parameter Name="cardLastName" Type="String" />
                        <asp:Parameter Name="CreditCardNumber" Type="String" />
                        <asp:Parameter Name="cvv" Type="Int32" />
                        <asp:Parameter Name="expirationDate" Type="String" />
                        <asp:Parameter Name="cardIndex" Type="Int32" />
                        <asp:SessionParameter Name="userID" SessionField="UserID" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:ValidationSummary ID="ValidationSummary2" ForeColor="Red" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary4" ValidationGroup="INSERTCARD" ForeColor="Red" runat="server" />
                <br />
                <asp:Label ID="savedCardLabel" runat="server" Text=""></asp:Label>
                <br />
            </asp:Panel>
            </asp:Content>
