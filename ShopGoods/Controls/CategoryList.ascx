<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="ShopGoods.Controls.CategoryList" %>

<%= CreateHomeLinkHtml() %>

<%= CreateAdminLinkHtml() %>

<% foreach (string category in GetCategories())
   {
       Response.Write(CreateLinkHtml(category));
   }%>