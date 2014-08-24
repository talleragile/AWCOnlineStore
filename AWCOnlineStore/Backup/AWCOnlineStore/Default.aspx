<%@ Page Title="" Language="C#" MasterPageFile="~/AWCTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AWCOnlineStore.Default" %>
<%@ Register tagname="_PopularItems" tagprefix="uc1" src="_PopularItems.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr valign="top">
							<td nowrap>
								<br>
								<img align="left" width="24" SRC="images/1x1.gif">
								<table cellspacing="0" cellpadding="0" width="100%">
									<tr>
										<td>
											<table cellspacing="0" cellpadding="0" width="100%">
												<tr>
													<td class="HomeHead">
														<asp:Label id="WelcomeMsg" runat="server">Welcome to the AWC Online Store</asp:Label>
													</td>
												</tr>
											</table>
											<table cellspacing="0" cellpadding="2" width="600" border="0">
												<tr valign="top">
													<td>
														<table width="300">
															<tr valign="top">
																<td>
																	<span class="NormalDouble">                                                                        
                                                                        The Commerce Starter Kit demonstrates how extraordinarily simple
                                                                        it is to create powerful, scalable applications and services for the
                                                                        .NET platform. IBuySpy.com is a fictitious "click and mortar" retailer
                                                                        whose online presence is based on the ASP.NET Commerce Starter Kit.
                                                                        IBuySpy.com is a lighthearted look at the Starter Kit code and capabilities.
                                                                        <br>
                                                                        <br>
                                                                    </span>
																</td>
															</tr>
														</table>
													</td>
													<td align="left">
														<img border="0" width="309" src="ProductImages/bycicle.jpg">
														<br>
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="NormalDouble"><i>Blast off in a <a href='ProductDetails.aspx?productID=373'>
																	<b>Pocket Protector Rocket Pack</b></i></A></span>
													</td>
													<td>
														&nbsp;
													</td>
												</tr>
												<tr valign="top">
													<td>
                                                        <uc1:_PopularItems ID="_PopularItems1" runat="server" />
													    <br />
													</td>
													<td>
														<br>
														<span class="NormalDouble">To give the Commerce Starter Kit a test spin, simply starting
                                                            browsing and add any items you want to your shopping cart. Click the <b>Documentation</b>
                                                            link (left) at any point to learn what's going on under the hood.</span>
													</td>
													<td>
														&nbsp;
													</td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
</asp:Content>
