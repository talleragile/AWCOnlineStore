<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_ReviewList.ascx.cs" Inherits="AWCOnlineStore._ReviewList" %>


<%--

    This user control display a list of review for a specific product.

--%>

<br>
<br>

<table cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td class="SubContentHead">
            &nbsp;Reviews
            <br>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Hyperlink id="AddReview" runat="server">
                <img align="absbottom" src="images/review_this_product.gif" border="0">
            </asp:Hyperlink>
            <br>
            <br>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList ID="MyList" runat="server" width="500px" cellpadding="0" 
                DataSourceID="MyListDataSource">
                <ItemTemplate>
                    <asp:Label ID="Label1" class="NormalBold" Text='<%# Eval("CustomerName") %>' runat="server" />
                    <span class="Normal">says... </span><img src='images/ReviewRating<%# Eval("Rating") %>.gif'>
                    <br>
                    <asp:Label ID="Label2" class="Normal" Text='<%# Eval("Comments") %>' runat="server" />
                </ItemTemplate>
                <SeparatorTemplate>
                    <br>
                </SeparatorTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="MyListDataSource" runat="server" 
    SelectMethod="GetReviews" TypeName="AWC.BusinessLayer.Reviews">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="productID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

