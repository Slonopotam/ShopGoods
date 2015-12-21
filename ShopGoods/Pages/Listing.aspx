<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="ShopGoods.Pages.Listing" MasterPageFile="~/Pages/Shop.Master" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="ShopGoods.Models.Good" SelectMethod="GetGoods" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.GoodsName %></h3>
                    <%# Item.GoodsCompany %>
                    <h4><%# Item.GoodsPrice.ToString("c") %></h4>
                    <button name="add" type="submit" value="<%# Item.GoodsID %>">
                            Добавить в корзину 
                    </button>
                </div>
            </ItemTemplate>
        </asp:Repeater>      
    </div>
    <div class="pager">
        <%
            for(int i = 1; i <= MaxPage; i++)
            {
                string category = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];
                
                string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "page", i } }).VirtualPath;
                Response.Write(String.Format("<a href='{0}' {1}>{2}</a>", path, i== CurrentPage ? "class='selected'": "", i));
            }
             %>
    </div>
</asp:Content>