<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasketSummary.ascx.cs" Inherits="ShopGoods.Controls.BasketSummary" %>

<div id="basketSummary">
    <span class="caption">
        <b>В корзине:</b>
        <span id="csQantity" runat="server"></span> товаров,
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Корзина</a>
</div>