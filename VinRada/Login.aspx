<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VinRada.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/login.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server"
        RenderOuterTable="false"
        ID="loginFormView"
        DefaultMode="Insert"
        ItemType="VinRada.ViewModel.LoginViewModel"
        InsertMethod="LoginUser">
        <InsertItemTemplate>
            <table>
                <tr>
                    <td>Iм'я:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" Text="<%# BindItem.Username %>" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Пароль:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" TextMode="Password" Text="<%# BindItem.Password %>" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button
                            CommandName="Insert"
                            runat="server"
                            Text="Надiслати" /></td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
     <div id="errors" style="width: 400px; margin: 20px auto 0 auto;">
        <asp:ValidationSummary
            ID="valSummary"
            runat="server"
            ClientIDMode="Static"
            HeaderText="Виправте помилки:"
            ShowModelStateErrors="true"
            DisplayMode="BulletList"
            EnableClientScript="true"
            ForeColor="Red" />
    </div>
</asp:Content>

