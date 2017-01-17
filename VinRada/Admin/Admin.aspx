<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.cs" Inherits="VinRada.Admin.Admin" %>

<%@ Import Namespace="System.Web.Optimization" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="adminPages">
        Сторінка адмінiстратора  
    </div>
    <link href="/Content/admin.css" rel="stylesheet" />

    <%: Scripts.Render("~/bundles/angular")%>

   <%-- <script src="/Scripts/angular.min.js"></script>
    <script src="/Scripts/angular-ui-router.min.js"></script>
    <script src="/Scripts/angular-sanitize.min.js"></script>
    <script src="/Scripts/angular-css.min.js"></script>
    <script src="/app/admin.app/admin.app.js"></script>
    <script src="/app/admin.app/admin.route.js"></script>
    <script src="/app/admin.app/articles/article.service.js"></script>
    <script src="/app/admin.app/articles/create.article/create.article.controller.js"></script>
    <script src="/app/admin.app/articles/create.gallery/create.gallery.controller.js"></script>
    <script src="/app/admin.app/articles/edit.articles/edit.articles.controller.js"></script>
    <script src="/app/admin.app/articles/edit.galleries/edit.galleries.controller.js"></script>
    <script src="/app/admin.app/contacts/contacts.service.js"></script>
    <script src="/app/admin.app/contacts/contacts.controller.js"></script>
    <script src="/app/admin.app/main/images.service.js"></script>
    <script src="/app/admin.app/main/add.image/add.image.controller.js"></script>
    <script src="/app/admin.app/main/delete.images/delete.images.controller.js"></script>
    <script src="/app/admin.app/news/news.service.js"></script>
    <script src="/app/admin.app/news/create.news/create.news.controller.js"></script>
    <script src="/app/admin.app/news/edit.news/edit.news.controller.js"></script>--%>

    <div ng-app="admin.app">
        <div id="editedContent">
            <ui-view></ui-view>
        </div>
    </div>
</asp:Content>
