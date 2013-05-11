<%@ Page Title="学生管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentMgr.aspx.cs" Inherits="April.Web.StudentMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
    <link href="css/list.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div class="list">
        <div class="title"><span>学生管理</span></div>
        <div class="listcommand">
            <asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/StudentMgr.aspx?Mode=Edit" ToolTip="添加" CssClass="add"/>
            <asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh" />
        </div>   
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvStudents_DataBinding" 
                onrowcommand="gvStudents_RowCommand" 
                onrowdeleting="gvStudents_RowDeleting" AllowPaging="True" 
            onpageindexchanging="gvStudents_PageIndexChanging" PageSize="8">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/StudentMgr.aspx?Id={0}" DataTextField="Id" 
                    HeaderText="学号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text=" " CssClass="gender" OnDataBinding="Gender_DataBinding"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Grade" HeaderText="年级" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("Id", "~/StudentMgr.aspx?Id={0}&Mode=Edit") %>' CssClass="edit" ToolTip="编辑"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandArgument=<%#Eval("Id")%> CommandName="Delete" CssClass="delete" ToolTip="删除" />
                        <ajaxToolkit:ConfirmButtonExtender ID="confirmBtnExt" runat="server"
                                                           TargetControlID="LinkButton1"
                                                           DisplayModalPopupID="modalPopupExt1"/>
                        <ajaxToolkit:ModalPopupExtender ID="modalPopupExt1" runat="server" TargetControlID="LinkButton1" PopupControlID="pnlContent" OkControlID="btnOK" CancelControlID="btnCancel" BackgroundCssClass="windowBg" />
                        <asp:Panel ID="pnlContent" runat="server" CssClass="confirmpanel">
                            确定删除该学生吗？
                            <br /><br />
                            <div class="confirmcommand">
                                <asp:Button ID="btnOK" runat="server" Text="确定" />
                                <asp:Button ID="btnCancel" runat="server" Text="取消" />
                            </div>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="empty">
                    <thead>
                        <tr>
                            <th>学号</th>
                            <th>姓名</th>
                            <th>性别</th>
                            <th>年级</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td colspan="4">没有学生记录</td></tr>
                    </tbody>                
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div id="viewForm" runat="server" class="form">
        <div class="title"><span>查看学生信息</span></div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/StudentMgr.aspx" ToolTip="关闭" CssClass="close"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="Label1" CssClass="identity" runat="server" ToolTip="学号" AssociatedControlID="lblvId"/>
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
                    <asp:Label ID="lblvName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="年级" AssociatedControlID="lblvGrade"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvGrade" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="出生年月" AssociatedControlID="lblvBirthday"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvBirthday" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="电话" AssociatedControlID="lblvContactNo"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvContactNo" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="地址" AssociatedControlID="lblvAddress"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvAddress" runat="server"/>
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
        <div class="title"><span id="lblSubject" runat="server"></span></div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div id="editCommand" runat="server" class="editcommand">
            <%--<asp:Button runat="server" ID="btnPopHandle" CssClass="hidden" />--%>
            <asp:LinkButton ID="btnResetPwd" runat="server" CssClass="resetPwd" ToolTip="重置密码" OnClick="btnRestPwd_Click" />
            <asp:Button ID="btnSave" runat="server" CssClass="save" ValidationGroup="save" ToolTip="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server" CssClass="reset" ToolTip="重置"/>
            <asp:HyperLink ID="btnCancel" runat="server" CssClass="cancel" NavigateUrl="~/StudentMgr.aspx" ToolTip="取消"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="lblId" CssClass="label" runat="server" Text="学号" AssociatedControlID="txtId"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtId" runat="server"/>
                    <asp:CheckBox ID="ckbGender" Checked="true" runat="server" CssClass="gender"/>
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
                    <asp:Label ID="lblGrade" CssClass="label" runat="server" Text="年级" AssociatedControlID="txtGrade"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtGrade" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="lblBirthday" CssClass="label" runat="server" Text="出生年月" AssociatedControlID="txtBirthday"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtBirthday" runat="server" Width="130px" MaxLength="1" style="text-align:justify" />
                    <asp:ImageButton ID="ImgBntCalc" runat="server" ImageUrl="~/images/calendar.png" CausesValidation="False" />
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
                    <asp:Label ID="lblAddress" CssClass="label" runat="server" Text="地址" AssociatedControlID="txtAddress"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtAddress" runat="server"/>
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
                                              TargetControlID="ReqName"/>
        <asp:RequiredFieldValidator runat="server" ID="ReqPwd"
                                    ControlToValidate="txtPwd"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请设置初始密码"  
                                    ValidationGroup="save"/>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqPwdEx"
                                              TargetControlID="ReqPwd"/>
        <ajaxToolkit:MaskedEditExtender ID="txtBirthdayEx" runat="server"
         TargetControlID="txtBirthday" MaskType="None" Mask="9999年99月99日" ClearMaskOnLostFocus="False"/>
        <ajaxToolkit:CalendarExtender ID="txtBirthdayCalEx" runat="server" 
                                      TargetControlID="txtBirthday"
                                      Format="yyyy年MM月dd日"
                                      PopupButtonID="ImgBntCalc" />
    </div>
</asp:Content>
