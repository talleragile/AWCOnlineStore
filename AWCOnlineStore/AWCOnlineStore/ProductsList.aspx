<%@ Page Title="" Language="C#" MasterPageFile="~/AWCTemplate.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="AWCOnlineStore.ProductsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr valign="top">
                            <td nowrap>
                                <br>
                              								<img align="left" width="24" SRC="images/1x1.gif">
  
                                <asp:DataList id="MyList" RepeatColumns="2" runat="server">
                                    <ItemTemplate>
                                        <table border="0" width="300">
                                            <tr>
                                                <td width="25">
                                                    &nbsp
                                                </td>
                                                <td width="100" valign="middle" align="right">
                                                    <a href='ProductDetails.aspx?productID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>
                                                        <img src='ProductImages/thumbs/<%# DataBinder.Eval(Container.DataItem, "ProductImage") %>' width="100" height="75" border="0">
                                                    </a>
                                                </td>
                                                <td width="200" valign="middle">
                                                    <a href='ProductDetails.aspx?productID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>
                                                        <span class="ProductListHead">
                                                            <%# DataBinder.Eval(Container.DataItem, "ModelName") %>
                                                        </span>
                                                        <br>
                                                    </a><span class="ProductListItem"><b>Special Price: </b>
                                                        <%# DataBinder.Eval(Container.DataItem, "UnitCost", "{0:c}") %>
                                                    </span>
                                                    <br>
                                                    <a href='AddToCart.aspx?productID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>
                                                        <span class="ProductListItem"><font color="#9D0000"><b>Add To Cart<b></font></span>
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
</asp:Content>
