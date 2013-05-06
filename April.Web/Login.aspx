<%@ Page Title="登录" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="April.Web.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="login">
        <ul>
            <li>
                <h2><span>登录</span></h2>
                <p class="message"><asp:Label ID="lblError" runat="server" /></p>
                <p>
                    <asp:Image ID="imgId" runat="server" ImageUrl="images/icons/identity.png" AlternateText="学（工）号" />  
                    <input type="text" id="txtId" runat="server" />
                </p>
                <p>
                    <asp:Image ID="imgPwd" runat="server" ImageUrl="images/icons/lock.png" AlternateText="密码" />  
                    <input type="password" id="txtPwd" runat="server" />
                </p>
                <p>
                    <asp:Image ID="imgRole" runat="server" ImageUrl="images/icons/role.png" AlternateText="身份" />  
                    <asp:DropDownList ID="dllRole" runat="server">
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
                <asp:Button CssClass="btnlogin" ID="btnLogin" runat="server" ToolTip="登录" OnClick="btnLogin_Click" ValidationGroup="LoginVal" />
                <p></p>
            </li>
        </ul>
        <asp:RequiredFieldValidator runat="server" ID="reqId"
                                    ControlToValidate="txtId"
                                    Display="None"
                                    ErrorMessage="学(工)号不能为空" ToolTip="请填写学(工)号" ValidationGroup="LoginVal" />
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqIdEx"
                                              TargetControlID="ReqId"
                                              HighlightCssClass="validatorCalloutHighlight" />
        <asp:RequiredFieldValidator runat="server" ID="reqPwd"
                                    ControlToValidate="txtPwd"
                                    Display="None"
                                    ErrorMessage="密码不能为空" ToolTip="请输入密码" 
                                    ValidationGroup="LoginVal"/>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqPwdEx"
                                              TargetControlID="ReqPwd"/>
    </div>
</asp:Content>
