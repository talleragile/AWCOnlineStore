<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_PopularItems.ascx.cs" Inherits="AWCOnlineStore._PopularItems" %>
<%@ outputcache Duration="3600" VaryByParam="None" %>

<%--

    This user control displays a list of the most popular items this week.

--%>

<table border="0" cellpadding="0" cellspacing="0" width="95%">
   <asp:Repeater ID="productList" runat="server" 
        DataSourceID="productListDataSource">
        <HeaderTemplate>
            <tr>
                <td class="MostPopularHead">
                    &nbsp;Our most popular items this week
                </td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td bgcolor="#d3d3d3">
                    &nbsp;
                    <asp:HyperLink runat="server" class="MostPopularItemText" 
                        NavigateUrl='<%# "ProductDetails.aspx?ProductID=" + Eval("ProductID")%>' 
                        Text='<%#Eval("ModelName")%>' />
                    
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td bgcolor="#d3d3d3">
                    &nbsp;
                </td>
            </tr>
        </FooterTemplate>
    </asp:Repeater>
</table>
<asp:ObjectDataSource ID="productListDataSource" runat="server" 
    SelectMethod="GetMostPopularProductsOfWeek" 
    TypeName="AWC.BusinessLayer.Products" >
    </asp:ObjectDataSource>

