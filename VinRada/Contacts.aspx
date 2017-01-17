<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="VinRada.Contacts" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="Content/contacts.css" rel="stylesheet" />
</asp:Content>



<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView
        ItemType="VinRada.ViewModel.ContactsViewModel"
        SelectMethod="GetContacts"
        ID="FormView1"
        runat="server">
        <ItemTemplate>
            <div id="map">
                <br />
                <b>Адреса : </b>
                <asp:Literal ID="Literal1" Text="<%# Item.Address %>" runat="server" /><br />
                <br />
                <b>Електронна пошта : </b>
                <asp:Literal ID="Literal2" Text="<%# Item.Email %>" runat="server" /><br />
                <br />
                <br />
                <b>Телефон : </b>
                <asp:Literal ID="Literal3" Text="<%# Item.PhoneNumber %>" runat="server" /><br />
                <br />
                <br />
                <fieldset>
                    <legend>Карта</legend>
                    <div id="googleMap"></div>
                </fieldset>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>




<asp:Content ContentPlaceHolderID="Script" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyDY0kkJiTPVd2U7aTOAwhc9ySH6oHxOIYM&sensor=false"></script>
    <script>
        function initialize() {
            var myCenter = new google.maps.LatLng(49.23332, 28.44432);
            var mapProp = {
                center: myCenter,
                zoom: 18,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

            var marker = new google.maps.Marker({
                position: myCenter,
            });

            marker.setMap(map);
        }
        if (google)
            google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
