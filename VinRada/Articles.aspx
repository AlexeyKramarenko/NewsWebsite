<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="VinRada.Articles" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/css/jquery-ui.css" rel="stylesheet" />
    <link href="/Content/articles.css" rel="stylesheet" />
</asp:Content>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">


    <div id="accordion"> 
        <asp:Repeater
            ID="Repeater1"
            SelectMethod="GetArticles"
            ItemType="VinRada.ViewModel.ArticleViewModel"
            runat="server"> 
            <ItemTemplate> 
                <h2>
                    <a href="#" class="title">
                        <b>
                            <i>
                                <asp:Literal ID="litTitle" Text='<%# Item.Title %>' runat="server" />
                            </i>
                        </b>
                    </a>
                </h2> 
                <div>
                <asp:ListView
                    ID="images"
                    DataSource='<%# Item.ImagesContent %>'
                    ItemType="VinRada.ViewModel.ImagesContentViewModel"
                    runat="server"> 
                    <LayoutTemplate>
                        <div class="rondellThumbnails">
                            <asp:PlaceHolder runat="server" ID="ItemPlaceholder"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <asp:Image ImageUrl='<%# Item.ImageSource %>' title='<%# Item.Description %>' runat="server" />
                    </ItemTemplate>
                </asp:ListView>
                <div class="textContent"><%# Item.TextContent %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>


<asp:Content ContentPlaceHolderID="Script" runat="server">
    <script src="../../Scripts/jquery-2.1.1.js"></script>
    <script src="../../Scripts/libs/jquery.mousewheel-3.0.6.min.js"></script>
    <script src="../../Scripts/dist/jquery.rondell.js"></script>
    <script src="../../Scripts/libs/modernizr-2.0.6.min.js"></script>

    <script type="text/javascript">
        (function () {
            $(".rondellThumbnails").each(function () {
                $(this).rondell({
                    preset: "thumbGallery"
                });
            });

        })();
    </script>


    <script src="../../Scripts/jquery-ui-1.11.1.js"></script>

    <script type="text/javascript">
        (function () {
            $("#accordion").accordion({
                active: -1,
                autoHeight: false,
                collapsible: true
            });
        })();
    </script>
</asp:Content>
