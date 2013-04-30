<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TchProfile.aspx.cs" Inherits="April.Web.TchProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="err"><p><asp:Label ID="lblMessage" runat="server" Text=""/></p></div>
    <div id="viewForm" runat="server" class="form" >
        <div class="topborder">&nbsp;</div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
        </div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="identity" AssociatedControlID="lblvId"/>
                </td>
                <td style="display: inline-block">
                    <asp:Label ID="lblvId" runat="server"/><asp:Label ID="lblvGender" CssClass="gender" runat="server" Text=" "/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="姓名" AssociatedControlID="lblvName"/>
                </td>
                <td>
                    <asp:Label ID="lblvName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="职称" AssociatedControlID="lblvTitle"/>
                </td>
                <td>
                    <asp:Label ID="lblvTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="电话" AssociatedControlID="lblvContactNo"/>
                </td>
                <td>
                    <asp:Label ID="lblvContactNo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="editForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="lblId" runat="server" CssClass="identity" ToolTip="学号" AssociatedControlID="txtId"/>
                </td>
                <td>
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
                <td>
                    <asp:Label ID="lblName" CssClass="label" runat="server" Text="姓名" AssociatedControlID="txtName"/>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitle" CssClass="label" runat="server" Text="职称" AssociatedControlID="txtTitle"/>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContactNo" CssClass="label" runat="server" Text="电话" AssociatedControlID="txtContactNo"/>
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPwd" CssClass="label" runat="server" Text="密码" AssociatedControlID="txtPwd"/>
                </td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server"/>
                </td>
            </tr>
        </table>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" CssClass="save" ToolTip="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server" CssClass="reset" ToolTip="重置"/>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/TchProfile.aspx" CssClass="cancel" ToolTip="取消"/>
        </div>
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
