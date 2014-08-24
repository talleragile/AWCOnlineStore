<%@ Page Title="" Language="C#" MasterPageFile="~/AWCTemplate.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="AWCOnlineStore.ProductDetails" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="AlsoBought" Src="_AlsoBought.ascx" %>
<%@ Register TagPrefix="ASPNETCommerce" TagName="ReviewList" Src="_ReviewList.ascx" %>
<%@ OutputCache Duration="60" VaryByParam="ProductID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table height="100%" cellSpacing="0" cellPadding="0" width="620" align="left" border="0">
                        <tr vAlign="top">
                            <td>
                                <br>
                                <img src="images/1x1.gif" width="24" align="left">
                                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="ContentHead">
                                            <img height="32" src="images/1x1.gif" width="60" align="left"><asp:label id="ModelName" runat="server" />
                                            <br>
                                        </td>
                                    </tr>
                                </table>
                                <table cellSpacing="0" cellPadding="0" width="100%" border="0" valign="top">
                                    <tr vAlign="top">
                                        <td>
                                            <img height="1" width="24" src="images/1x1.gif">
                                        </td>
                                        <td width="309">
                                            <img height="15" src="images/1x1.gif">
                                            <br>
                                            <asp:image id="ProductImage" runat="server" height="185" width="309" border="0" />
                                            <br>
                                            <br>
                                            <img height="20" src="images/1x1.gif" width="72"><span class="UnitCost"><b>Your Price:</b>&nbsp;<asp:label id="UnitCost" runat="server" /></span>
                                            <br>
                                            <img height="20" src="images/1x1.gif" width="72"><span class="ModelNumber"><b>Model Number:</b>&nbsp;<asp:label id="ModelNumber" runat="server" /></span>
                                            <br>
                                            <img height="30" src="images/1x1.gif" width="72"><asp:hyperlink id="addToCart" runat="server" ImageUrl="images/add_to_cart.gif" />
                                        </td>
                                        <td>
                                            <table width="300" border="0">
                                                <tr>
                                                    <td vAlign="top">
                                                        <asp:label class="NormalDouble" id="desc" runat="server"></asp:label>
                                                        <br>
                                                    </td>
                                                </tr>
                                            </table>
                                            <img height="30" src="images/1x1.gif">
                                            <ASPNETCommerce:AlsoBought id="AlsoBoughtList" runat="server" />
                                        </td>
                                    </tr>
                                    </table>
                                <table border="0">
                                    <tr>
                                        <td>
                                            <img src="images/1x1.gif" width="89" height="20">
                                        </td>
                                        <td width="100%">
                                            <ASPNETCommerce:ReviewList id="ReviewList" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
</asp:Content>
