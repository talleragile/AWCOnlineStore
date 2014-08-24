<%@ Page Title="" Language="C#" MasterPageFile="~/AWCTemplate.Master" AutoEventWireup="true" CodeBehind="ReviewAdd.aspx.cs" Inherits="AWCOnlineStore.ReviewAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr valign="top">
                            <td nowrap>
                                <br>
                                <form id="Form1" runat="server">
                                    <img align="left" width="24" src="images/1x1.gif">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="ContentHead">
                                                <img align="left" height="32" width="60" src="images/1x1.gif">Add Review -
                                                <asp:label id="ModelName" runat="server" />
                                                <br>
                                            </td>
                                        </tr>
                                    </table>
                                    <br>
                                    <img align="left" width="92" src="Images/1x1.gif">
                                    <table width="500" border="0">
                                        <tr valign="top">
                                            <td>
                                                <table border="0">
                                                    <tr>
                                                        <td valign="top" width="550">
                                                            <span class="NormalBold">Name</span>
                                                            <br>
                                                            <asp:TextBox size="20" id="Name" runat="server" />
                                                            <asp:RequiredFieldValidator ControlToValidate="Name" Display="Dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Name' must not be left blank." runat="server" id=RequiredFieldValidator1></asp:RequiredFieldValidator>
                                                            <br>
                                                            <br>
                                                            <span class="NormalBold">Email</span>
                                                            <br>
                                                            <asp:TextBox id="Email" size="20" runat="server" />
                                                            <asp:RequiredFieldValidator ControlToValidate="Email" Display="Dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Email' must not be left blank." runat="server" id=RequiredFieldValidator2></asp:RequiredFieldValidator>
                                                            <br>
                                                            <br>
                                                            <span class="NormalBold">Rating</span>
                                                            <br>
                                                            <br>
                                                            <asp:RadioButtonList ID="Rating" runat="server">
                                                                <asp:ListItem text="Five" value="5" selected="True">
                                                                    <img src="Images/reviewrating5.gif"></asp:ListItem>
                                                                <asp:ListItem text="Four" value="4">
                                                                    <img src="Images/reviewrating4.gif"></asp:ListItem>
                                                                <asp:ListItem text="Three" value="3">
                                                                    <img src="Images/reviewrating3.gif"></asp:ListItem>
                                                                <asp:ListItem text="Two" value="2">
                                                                    <img src="Images/reviewrating2.gif"></asp:ListItem>
                                                                <asp:ListItem text="One" value="1">
                                                                    <img src="Images/reviewrating1.gif"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br>
                                                <br>
                                                <span class="NormalBold">Comments</span>
                                                <br>
                                                <asp:TextBox id="Comment" textmode="multiline" rows="7" columns="60" runat="server" />
                                                <asp:RequiredFieldValidator ControlToValidate="Comment" Display="Dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Comment' must not be left blank." runat="server" id=RequiredFieldValidator3></asp:RequiredFieldValidator>
                                                <br>
                                                <br>
                                                <asp:ImageButton ImageURL="images/submit.gif" runat="server" id=ReviewAddBtn 
                                                    onclick="ReviewAddBtn_Click" />
                                                <br>
                                                <br>
                                                <br>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </td>
                        </tr>
                    </table>
</asp:Content>
