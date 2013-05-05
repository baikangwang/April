<%@ Page Title="首页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="April.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home">
        <div id="admin" runat="server" class="admin" Visible="False"/>
        <div id ="teacher" runat="server" class="teacher" Visible="False"/>
        <div id="student" runat="server" class="student" Visible="False"/>
        <div id="default" runat="server" class="default" Visible="False"/>
    </div>
</asp:Content>
