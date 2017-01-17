<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="VinRada.News" %>
<%@ Import Namespace="System.Web.Optimization" %>

<asp:Content ContentPlaceHolderID="head" runat="server">    
    <%: Scripts.Render("~/bundles/angular_newsApp")%>
    <link href="/Content/news.css" rel="stylesheet" />
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
     
    <div ng-app="news.app" ng-controller="NewsController as vm" id="content">
        <div id="news" class="list-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:ListView
                        ID="imagesListView"
                        ItemType="VinRada.ViewModel.LinkViewModel"
                        runat="server"
                        SelectMethod="GetNewsLinks">

                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="ItemPlaceholder"></asp:PlaceHolder>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <a href="#" ng-click='vm.getNewsById(<%# Item.ID %>)' class="list-group-item link"><%# Item.Title %></a>
                        </ItemTemplate>

                    </asp:ListView>

                    <asp:DataPager
                        ClientIDMode="Static"
                        ID="pager"
                        PagedControlID="imagesListView"
                        PageSize="20"
                        runat="server">
                        <Fields>
                            <asp:NumericPagerField ButtonCount="10" ButtonType="Link" />
                        </Fields>
                    </asp:DataPager>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="article">
            <div id="articleTitle" ng-bind="vm.NewsPageViewModel.Title"></div>
            <div id="articleDate" ng-bind="vm.NewsPageViewModel.Date"></div>
            <div id="articleContent" ng-bind="vm.NewsPageViewModel.Content"></div>
        </div>
    </div>

</asp:Content>


<asp:Content ContentPlaceHolderID="Script" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     
</asp:Content>
