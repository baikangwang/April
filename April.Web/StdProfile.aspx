<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StdProfile.aspx.cs" Inherits="April.Web.StdProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="err"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
    <div id="viewForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
        </div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" CssClass="identity" AssociatedControlID="lblvId"/>
                </td>
                <td>
                    <asp:Label ID="lblvId" runat="server"/><asp:Label ID="lblvGender" CssClass="gender" runat="server" Text=" "/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="姓名" AssociatedControlID="lblvName"/>
                </td>
                <td>
                    <asp:Label ID="lblvName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="年级" AssociatedControlID="lblvGrade"/>
                </td>
                <td>
                    <asp:Label ID="lblvGrade" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="出生年月" AssociatedControlID="lblvBirthday"/>
                </td>
                <td>
                    <asp:Label ID="lblvBirthday" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="电话" AssociatedControlID="lblvContactNo"/>
                </td>
                <td>
                    <asp:Label ID="lblvContactNo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="地址" AssociatedControlID="lblvAddress"/>
                </td>
                <td>
                    <asp:Label ID="lblvAddress" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="editForm" runat="server" class="form">
    <div class="topborder">&nbsp;</div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="lblId" CssClass="identity" runat="server" ToolTip="学号" Text=" " AssociatedControlID="txtId"/>
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server"/><asp:CheckBox ID="ckbGender" Checked="true" CssClass="gender" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblName" CssClass="label" runat="server" Text="姓名" AssociatedControlID="txtName"/>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGrade" CssClass="label" runat="server" Text="年级" AssociatedControlID="txtGrade"/>
                </td>
                <td>
                    <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBirthday" CssClass="label" runat="server" Text="出生年月" AssociatedControlID="txtBirthday"/>
                </td>
                <td>
                    <asp:TextBox ID="txtBirthday" runat="server" Width="130px" MaxLength="1" style="text-align:justify" /><asp:ImageButton ID="ImgBntCalc" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContactNo" CssClass="label" runat="server" Text="电话" AssociatedControlID="txtContactNo"/>
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" CssClass="label" runat="server" Text="地址" AssociatedControlID="txtAddress"/>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" ToolTip="保存" OnClick="btnSave_Click" CssClass="save" />
            <asp:HyperLink ID="btnReset" runat="server" ToolTip="重置" CssClass="reset"/>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/StdProfile.aspx" ToolTip="取消" CssClass="cancel"/>
        </div>
        <ajaxToolkit:ToggleButtonExtender ID="ckbToggle" runat="server"
            TargetControlID="ckbGender"
            ImageWidth="40"
            ImageHeight="40"
            CheckedImageUrl="images/icons/male.png"
            UncheckedImageUrl="images/icons/female.png"
            CheckedImageAlternateText="男"
            UncheckedImageAlternateText="女" />
        <asp:RequiredFieldValidator runat="server" ID="ReqId"
                                    ControlToValidate="txtId"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请填写学号" ValidationGroup="save" />
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
        <ajaxToolkit:MaskedEditExtender ID="txtBirthdayEx" runat="server"
                                        TargetControlID="txtBirthday"  
                                        Mask="9999年99月99日"
                                        MessageValidatorTip="true"
                                        OnFocusCssClass="MaskedEditFocus"
                                        OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date"
                                        DisplayMoney="Left"
                                        AcceptNegative="Left"
                                        ErrorTooltipEnabled="True" />
        <ajaxToolkit:CalendarExtender ID="txtBirthdayCalEx" runat="server" 
                                        TargetControlID="txtBirthday"
                                        Format="yyyy年MM月dd日"
                                        PopupButtonID="ImgBntCalc" />
    </div>
</asp:Content>
