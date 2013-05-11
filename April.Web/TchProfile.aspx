<%@ Page Title="教师个人信息" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TchProfile.aspx.cs" Inherits="April.Web.TchProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="viewForm" runat="server" class="form" >
        <div class="title"><span>查看个人信息</span></div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="Label1" runat="server" CssClass="identity" AssociatedControlID="lblvId"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvId" runat="server"/>
                    <asp:Label ID="lblvGender" CssClass="gender" runat="server" Text=" "/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="姓名" AssociatedControlID="lblvName"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="职称" AssociatedControlID="lblvTitle"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="电话" AssociatedControlID="lblvContactNo"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvContactNo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlResetPwd" runat="server" CssClass="form" Visible="False">
        <div class="title"><span>重置密码</span></div>
        <div class="message"><asp:Label ID="lblRestPwdMessage" runat="server" Text=""/></div>
        <div class="resetPwdCommand">
            <asp:LinkButton ID="btnRestPwdSave" runat="server" CssClass="save" ToolTip="保存" ValidationGroup="resetPwd" OnClick="btnRestPwdSave_Click" />
            <asp:LinkButton ID="btnRestPwdCancel" runat="server" CssClass="cancel" ToolTip="取消" OnClick="btnRestPwdCancel_Click" />
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="新密码" AssociatedControlID="txtNewPwd"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtNewPwd" runat="server" ValidationGroup="resetPwd"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="确认新密码" AssociatedControlID="txtcfmNewPwd"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtcfmNewPwd" runat="server" ValidationGroup="resetPwd"/>
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator runat="server" ID="ReqNewPwd"
                                    ControlToValidate="txtNewPwd"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请填新密码" ValidationGroup="resetPwd" />
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqNewPwdExt"
                                              TargetControlID="ReqNewPwd"
                                              HighlightCssClass="validatorCalloutHighlight" />
        <asp:CompareValidator ID="cmpPwd" ControlToValidate="txtcfmNewPwd"
                              runat="server" ErrorMessage="与新密码不一致"
                              Display="None" ValidationGroup="resetPwd"
                              ControlToCompare="txtNewPwd" Type="String"/>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="cmpPwdExt"
                                              TargetControlID="cmpPwd"
                                              HighlightCssClass="validatorCalloutHighlight" />
    </asp:Panel>
    <div id="editForm" runat="server" class="form">
        <div class="title"><span>修改个人信息</span></div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:LinkButton ID="btnResetPwd" runat="server" CssClass="resetPwd" ToolTip="重置密码" OnClick="btnRestPwd_Click" />
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" CssClass="save" ToolTip="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server" CssClass="reset" ToolTip="重置"/>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/TchProfile.aspx" CssClass="cancel" ToolTip="取消"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="lblId" runat="server" CssClass="identity" ToolTip="学号" AssociatedControlID="txtId"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtId" runat="server" Enabled="False"/>
                    <asp:CheckBox ID="ckbGender" Checked="true" CssClass="gender" runat="server"/>
                    <ajaxToolkit:ToggleButtonExtender ID="ckbToggle" runat="server"
                                                        TargetControlID="ckbGender"
                                                        ImageWidth="40"
                                                        ImageHeight="40"
                                                        CheckedImageUrl="images/icons/male.png"
                                                        UncheckedImageUrl="images/icons/female.png"
                                                        CheckedImageAlternateText="男"
                                                        UncheckedImageAlternateText="女" />
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="lblName" CssClass="label" runat="server" Text="姓名" AssociatedControlID="txtName"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="lblTitle" CssClass="label" runat="server" Text="职称" AssociatedControlID="txtTitle"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtTitle" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="lblContactNo" CssClass="label" runat="server" Text="电话" AssociatedControlID="txtContactNo"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtContactNo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="lblPwd" CssClass="label" runat="server" Text="密码" AssociatedControlID="txtPwd"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtPwd" runat="server"/>
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator runat="server" ID="ReqId"
                                    ControlToValidate="txtId"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请填写工号" 
                                    ValidationGroup="save" />
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqIdEx"
                                                TargetControlID="ReqId"
                                                HighlightCssClass="validatorCalloutHighlight" />
        <asp:RequiredFieldValidator runat="server" ID="ReqName"
                                    ControlToValidate="txtName"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请填写姓名" 
                                    ValidationGroup="save" />
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqNameEx"
                                                TargetControlID="ReqName"
                                                HighlightCssClass="validatorCalloutHighlight" />
        <asp:RequiredFieldValidator runat="server" ID="ReqPwd"
                                    ControlToValidate="txtPwd"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请设置初始密码"
                                    ValidationGroup="save"/>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqPwdEx"
                                                TargetControlID="ReqPwd"
                                                HighlightCssClass="validatorCalloutHighlight" />
    </div>
</asp:Content>
