<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_Menu.ascx.cs" Inherits="AWCOnlineStore._Menu" %>
<%@ OutputCache Duration="3600" VaryByParam="selection" %>

<table cellspacing="0" cellpadding="0" width="145" border="0">
    <tr valign="top">
        <td colspan="2">       
            <a href="default.aspx"><img src="images/onlinestore.jpg" border="0"/></a>
        </td>
    </tr>
    <tr valign="top">
        <td colspan="2">
        <asp:DataList id="MyList" runat="server" DataSourceID="MyListDataSource" 
                cellpadding="3" cellspacing="0" width="145" 
                SelectedItemStyle-BackColor="dimgray" EnableViewState="false">
                <ItemTemplate>
                    <asp:HyperLink cssclass="MenuUnselected" id="HyperLink1" Text='<%# Eval("CategoryName") %>' NavigateUrl='<%# "productslist.aspx?CategoryID=" + Eval("CategoryID") + "&selection=" + Container.ItemIndex %>' runat="server" />
                </ItemTemplate>
<SelectedItemStyle BackColor="DimGray"></SelectedItemStyle>
                <SelectedItemTemplate>
                    <asp:HyperLink cssclass="MenuSelected" id="HyperLink2" Text='<%# Eval("CategoryName") %>' NavigateUrl='<%# "productslist.aspx?CategoryID=" + Eval("CategoryID") + "&selection=" + Container.ItemIndex %>' runat="server" />
                </SelectedItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="MyListDataSource" runat="server" 
    SelectMethod="GetProductCategories" TypeName="AWC.BusinessLayer.Products">
</asp:ObjectDataSource>           
        </td>
    </tr>
    <tr>
        <td width="10">
            &nbsp;
        </td>
        <td>
                        
        </td>
    </tr>
</table>

