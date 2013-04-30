<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Theme="April" CodeBehind="StudentMgr.aspx.cs" Inherits="April.Web.StudentMgr" %>
<%@ Import Namespace="April.Entity.Base" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
    <link href="css/list.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div class="list">
        <div class="topborder">&nbsp;</div>
        <div class="listcommand">
            <asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/StudentMgr.aspx?Mode=Edit" ToolTip="添加" CssClass="add"/>
            <asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh" />
        </div>   
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvStudents_DataBinding" 
                onrowcommand="gvStudents_RowCommand" 
                onrowdeleting="gvStudents_RowDeleting">
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
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandArgument=<%#Eval("Id")%> CommandName="Delete" CssClass="delete" ToolTip="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("Id", "~/StudentMgr.aspx?Id={0}&Mode=Edit") %>' CssClass="edit" ToolTip="编辑"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="records">
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
    <div id="err"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
    <div id="viewForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/StudentMgr.aspx" ToolTip="关闭" CssClass="close"/>
        </div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="identity" runat="server" ToolTip="学号" AssociatedControlID="lblvId"/>
                </td>
                <td>
                    <asp:Label ID="lblvId" runat="server"/>
                    <asp:Label ID="lblvGender" CssClass="gender" runat="server" Text=" "/>
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
            <tr>
                <td>
                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="密码" AssociatedControlID="txtPwd"/>
                </td>
                <td>
                    <asp:Label ID="lblvPwd" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="editForm" runat="server" class="form">
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="lblId" CssClass="label" runat="server" Text="学号" AssociatedControlID="txtId"/>
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server"/>
                    <asp:CheckBox ID="ckbGender" Checked="true" runat="server" CssClass="gender"/>
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
                    <asp:Label ID="lblGrade" CssClass="label" runat="server" Text="年级" AssociatedControlID="txtGrade"/>
                </td>
                <td>
                    <asp:TextBox ID="txtGrade" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBirthday" CssClass="label" runat="server" Text="出生年月" AssociatedControlID="txtBirthday"/>
                </td>
                <td>
                    <asp:TextBox ID="txtBirthday" runat="server" Width="130px" MaxLength="1" style="text-align:justify" />
                    <asp:ImageButton ID="ImgBntCalc" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" CausesValidation="False" />
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
                    <asp:Label ID="lblAddress" CssClass="label" runat="server" Text="地址" AssociatedControlID="txtAddress"/>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"/>
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
            <asp:Button ID="btnSave" runat="server" CssClass="save" ValidationGroup="save" ToolTip="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server" CssClass="reset" ToolTip="重置"/>
            <asp:HyperLink ID="btnCancel" runat="server" CssClass="cancel" NavigateUrl="~/StudentMgr.aspx" ToolTip="取消"/>
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
        <asp:RequiredFieldValidator runat="server" ID="ReqPwd"
                                    ControlToValidate="txtPwd"
                                    Display="None"
                                    ErrorMessage="<b>必填项</b><br />请设置初始密码"  
                                    ValidationGroup="save"/>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqPwdEx"
                                              TargetControlID="ReqPwd"
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
