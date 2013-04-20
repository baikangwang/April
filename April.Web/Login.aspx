<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="April.Web.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="css/login.css" type="text/css"/>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        登&nbsp;&nbsp;&nbsp;&nbsp;录
    </h2>
    
    <div class="login">
            <p>
            <asp:Label runat="server" ID="Label1" CssClass="label" AssociatedControlID="txtId" Text="学（工）号:"></asp:Label>
        <input type="text" class="text" id="txtId" runat="server" />
        <asp:RequiredFieldValidator ID="reqId" runat="server" ControlToValidate="txtId" CssClass="failureNotification"
            ErrorMessage="学（工）号不能为空" ToolTip="请输入学（工）号" ValidationGroup="LoginVal">*</asp:RequiredFieldValidator></p>
            <p><asp:Label ID="Label2" runat="server" CssClass="label" AssociatedControlID="txtPwd" Text="密码:"></asp:Label>
        <input type="text" class="text" id="txtPwd" runat="server" />
        <asp:RequiredFieldValidator ID="reqPwd" runat="server" ControlToValidate="txtPwd"
            CssClass="failureNotification" ErrorMessage="密码不能为空" ToolTip="请输入密码" ValidationGroup="LoginVal">*</asp:RequiredFieldValidator></p>
            <p><asp:Label ID="Label3" runat="server" CssClass="label" AssociatedControlID="dllRole" Text="身份："></asp:Label>
        <asp:DropDownList ID="dllRole" CssClass="text" runat="server">
            <Items>
            <asp:ListItem Value="0">管理员</asp:ListItem>
<asp:ListItem Value="1">教师</asp:ListItem><asp:ListItem Value="2">学生</asp:ListItem>        
        </Items></asp:DropDownList></p>
        <p>
            <asp:CheckBox ID="ckbRememder" runat="server" Text="一月内免登录" />
        </p>
        <p>
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" ValidationGroup="LoginVal" /></p>
            <p><asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>
            </p>
    </div>
</asp:Content>
