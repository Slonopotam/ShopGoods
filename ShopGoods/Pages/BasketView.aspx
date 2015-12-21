<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasketView.aspx.cs" Inherits="ShopGoods.Pages.BasketView" MasterPageFile="~/Pages/Shop.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Ваша корзина</h2>
        <table id="BasketTable">
            <thead>
                <tr>
                    <th>Кол-во товаров</th>
                    <th>Наименование</th>
                    <th>Фирма производитель</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="ShopGoods.Models.BasketLine"
                    SelectMethod="GetBasketLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Good.GoodsName %></td>
                            <td><%# Item.Good.GoodsCompany %></td>
                            <td><%# Item.Good.GoodsPrice.ToString("c")%></td>
                            <td><%# ((Item.Quantity * Item.Good.GoodsPrice).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Good.GoodsID %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= BasketTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
            <a href="<%= CheckoutUrl %>">Оформить заказ</a>
        </p>
    </div>
</asp:Content>
