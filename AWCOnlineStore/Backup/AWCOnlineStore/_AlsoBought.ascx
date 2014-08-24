<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_AlsoBought.ascx.cs" Inherits="AWCOnlineStore._AlsoBought" %>

<%--
        This user controls lists other products that
        customers who purchased a product "also bought".
--%>
<table width="95%" cellpadding="0" cellspacing="0" border="0">
	<tr>
		<td>
			<asp:Repeater ID="alsoBoughtList" runat="server" 
                DataSourceID="alsoBoughtDataSource">
				<HeaderTemplate>
					<tr>
						<td class="MostPopularHead">
							&nbsp;Customers who bought this also bought
						</td>
					</tr>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td bgcolor="#d3d3d3">
							&nbsp;
							<asp:HyperLink ID="HyperLink1" class="MostPopularItemText" NavigateUrl='<%# "ProductDetails.aspx?ProductID=" + DataBinder.Eval(Container.DataItem, "ProductID")%>' Text='<%#DataBinder.Eval(Container.DataItem, "ModelName")%>' runat="server" />
							<br>
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
		</td>
	</tr>
</table>
<asp:ObjectDataSource ID="alsoBoughtDataSource" runat="server" 
    SelectMethod="GetProductsAlsoPurchased" TypeName="AWC.BusinessLayer.Products">
    <SelectParameters>
        <asp:Parameter DefaultValue="0" Name="productID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

