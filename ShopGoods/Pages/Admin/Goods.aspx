<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="ShopGoods.Pages.Admin.Goods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" ItemType="ShopGoods.Models.Good" DataKeyNames="GoodsId" 
        SelectMethod="GetGoods"
        UpdateMethod="UpdateGood" 
        DeleteMethod="DeleteGood"
        AddMethod="AddGood"
        InsertMethod="InsertGood" 
        InsertItemPosition="LastItem" EnableViewState="false" runat="server">
        <LayoutTemplate>
            <div class="outerContainer">
                <table id="productsTable">
                    <tr>
                        <th>Название товара</th>
                        <th>Артикул</th>
                        <th>Производитель</th>
                        <th>Цена</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.GoodsName %></td>
                <td class="description"><span><%# Item.GoodsArticul %></span></td>
                <td><%# Item.GoodsCompany %></td>
                <td><%# Item.GoodsPrice.ToString("c") %></td>
                <td>
                    <asp:Button ID="Button1" CommandName="Edit" Text="Изменить" runat="server" />
                    <asp:Button ID="Button2" CommandName="Delete" Text="Удалить" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <input name="name" value="<%# Item.GoodsName %>" />
                    <input type="hidden" name="ProductID" value="<%# Item.GoodsID %>" />
                </td>
                <td>
                    <input name="description" value="<%# Item.GoodsArticul %>" /></td>
                <td>
                    <input name="category" value="<%# Item.GoodsCompany %>" /></td>
                <td>
                    <input name="price" value="<%# Item.GoodsPrice %>" /></td>
                <td>
                    <asp:Button ID="Button3" CommandName="Update" Text="Обновить" runat="server" />
                    <asp:Button ID="Button4" CommandName="Cancel" Text="Отмена" runat="server" />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>

            <%--  Ручная вставка товара в бд --%>
            <%--<tr>
                <td>
                    <input name="name" />
                    <input type="hidden" name="ProductID" value="0" />
                </td>
                <td>
                    <input name="description" /></td>
                <td>
                    <input name="category" /></td>
                <td>
                    <input name="price" /></td>
                <td>
                    <asp:Button ID="Button6" CommandName="Add" Text="Вставить" runat="server" />
                </td>
            </tr>--%>

            <asp:Button CssClass="" ID="Button5" CommandName="Insert" Text="Добавить товары в БД" runat="server" />    
            
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
