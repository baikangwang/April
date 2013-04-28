<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="April.Web.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="css/services.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="services">
        <h2>登录</h2>
        <ul>
            <li>
                <h3>&nbsp;</h3>
            <p>
                <asp:Image ID="imgId" runat="server" ImageUrl="images/icons/identity.png" AlternateText="学（工）号" />  
                <input type="text" class="text" id="txtId" runat="server" />
                <asp:RequiredFieldValidator ID="reqId" runat="server" ControlToValidate="txtId" CssClass="failureNotification"
                    ErrorMessage="学（工）号不能为空" ToolTip="请输入学（工）号" ValidationGroup="LoginVal">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Image ID="imgPwd" runat="server" ImageUrl="images/icons/lock.png" AlternateText="密码" />  
                <input type="text" class="text" id="txtPwd" runat="server" />
                <asp:RequiredFieldValidator ID="reqPwd" runat="server" ControlToValidate="txtPwd"
                    CssClass="failureNotification" ErrorMessage="密码不能为空" ToolTip="请输入密码" ValidationGroup="LoginVal">*</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Image ID="imgRole" runat="server" ImageUrl="images/icons/role.png" AlternateText="身份" />  
                <asp:DropDownList ID="dllRole" CssClass="text" runat="server">
                    <Items>
                        <asp:ListItem Value="0" Text="管理员"/>
                        <asp:ListItem Value="1" Text="教师"/>
                        <asp:ListItem Value="2" Text="学生"/>
                    </Items>
                </asp:DropDownList>
            </p>
            <p>
                <asp:CheckBox ID="ckbRememder" runat="server" Text="一月内免登录" />
            </p>
            <p>
                <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" ValidationGroup="LoginVal" />
            </p>
            <p><asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label></p>
            </li>
        </ul>
    </div>
</asp:Content>
