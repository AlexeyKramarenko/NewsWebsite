<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="VinRada.Main" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="/Content/main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView
        ID="images"
        ItemType="VinRada.ViewModel.MainPageViewModel"
        SelectMethod="GetMainPhotos"
        runat="server">
        <LayoutTemplate>
            <div id="rondellCarousel" class="hidden">
                <asp:PlaceHolder runat="server" ID="ItemPlaceholder"></asp:PlaceHolder>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <img src="<%# Item.Image %>" />
        </ItemTemplate>
    </asp:ListView>


    <div class="body">
        <h1>Вінницька районна рада жінок України</h1>
    </div>

</asp:Content>


<asp:Content ContentPlaceHolderID="Script" runat="server">

    <script src="../Scripts/libs/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/libs/jquery.mousewheel-3.0.6.min.js"></script>
    <script src="../Scripts/dist/jquery.rondell.js"></script>

    <script type="text/javascript">
        (function () {
            if ($("#rondellCarousel").length > 0)
                $("#rondellCarousel").rondell({
                    preset: "carousel",
                    strings: {
                        prev: '<<',
                        next: '>>'
                    },
                    radius: { x: 360, y: 90 }, size: { width: 1000, height: 500 }, center: { left: 500, top: 250 }, itemProperties: {
                        delay: 5,
                        size: {
                            width: 250,
                            height: 250
                        },
                        sizeFocused: {
                            width: 0,
                            height: 0
                        }
                    }
                });
        })();
    </script>
</asp:Content>
