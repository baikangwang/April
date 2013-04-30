<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Theme="April" CodeBehind="CourseMgr.aspx.cs" Inherits="April.Web.CourseMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/form.css" rel="stylesheet" type="text/css" />
    <link href="css/list.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div class="list">
        <div class="topborder">&nbsp;</div>
        <div class="listcommand">
            <asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/CourseMgr.aspx?Mode=Edit" ToolTip="添加" CssClass="add"/>
            <asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh"/>
        </div>   
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvCourses_DataBinding" 
                onrowcommand="gvCourses_RowCommand" 
                onrowdeleting="gvCourses_RowDeleting">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/CourseMgr.aspx?Id={0}" DataTextField="Name" 
                    HeaderText="课程名" />
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" OnDataBinding="lblTeacher_DataBinding"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Credit" HeaderText="学分" />
                <asp:BoundField DataField="Location" HeaderText="开课学院" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("Id", "~/CourseMgr.aspx?Id={0}&Mode=Edit") %>' ToolTip="编辑" CssClass="edit"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandArgument=<%#Eval("Id")%> CommandName="Delete" ToolTip="删除" CssClass="delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="empty">
                    <thead>
                        <tr>
                            <th>课程名</th>
                            <th>教师名</th>
                            <th>学分</th>
                            <th>开课学院</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td colspan="4">没有课程记录</td></tr>
                    </tbody>                
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div id="viewForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" ToolTip="修改" CssClass="edit"/>
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/CourseMgr.aspx" ToolTip="关闭" CssClass="close"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label2" runat="server" Text="课程名" AssociatedControlID="lblvName"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label3" runat="server" Text="教师名" AssociatedControlID="lblvTeacher"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvTeacher" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label8" runat="server" Text="学分" AssociatedControlID="lblvCredit"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvCredit" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label4" runat="server" Text="总学时" AssociatedControlID="lblvPeriod"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvPeriod" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label6" runat="server" Text="课内学时" AssociatedControlID="lblvHours"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvHours" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label7" runat="server" Text="最大人数" AssociatedControlID="lblvMax"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvMax" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="Label5" runat="server" Text="开课学院" AssociatedControlID="lblvLocation"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvLocation" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="editForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" ToolTip="保存" OnClick="btnSave_Click" CssClass="save" />
            <asp:HyperLink ID="btnReset" runat="server" ToolTip="重置" CssClass="reset"/>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/CourseMgr.aspx" ToolTip="取消" CssClass="cancel"/>
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblName" runat="server" Text="课程名" AssociatedControlID="txtName"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblTeacher" runat="server" Text="教师名" AssociatedControlID="cmbTeacher"/>
                </td>
                <td class="field">
                    <asp:DropDownList ID="cmbTeacher" runat="server" OnDataBinding="cmbTeacher_DataBinding" OnDataBound="cmbTeacher_DataBound"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblCredit" runat="server" Text="学分" AssociatedControlID="txtCredit"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtCredit" CssClass="double" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblPeriod" runat="server" Text="总学时" AssociatedControlID="txtPeriod"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtPeriod" CssClass="double" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblHours" runat="server" Text="课内学时" AssociatedControlID="txtHours"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtHours" CssClass="double" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblMax" runat="server" Text="最大人数" AssociatedControlID="txtMax"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtMax" CssClass="double" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label CssClass="label" ID="lblLocation" runat="server" Text="开课学院" AssociatedControlID="txtLocation"/>
                </td>
                <td class="field">
                    <asp:TextBox ID="txtLocation" runat="server"/>
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator runat="server" ID="ReqName"
            ControlToValidate="txtName"
            Display="None"
            ErrorMessage="<b>必填项</b><br />请填写课程名" ValidationGroup="save" />
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ReqNameEx"
            TargetControlID="ReqName"
            HighlightCssClass="validatorCalloutHighlight" />
        <ajaxToolkit:MaskedEditExtender ID="txtCreditEx" runat="server" TargetControlID="txtCredit" 
                                        Mask="99"
                                        OnFocusCssClass="MaskedEditFocus"
                                        MaskType="Number"
                                        InputDirection="RightToLeft"
                                        AcceptNegative="None"/>
        <ajaxToolkit:MaskedEditExtender ID="txtHoursEx" runat="server" TargetControlID="txtHours" 
                                        Mask="99"
                                        OnFocusCssClass="MaskedEditFocus"
                                        MaskType="Number"
                                        InputDirection="RightToLeft"
                                        AcceptNegative="None"/>
        <ajaxToolkit:MaskedEditExtender ID="txtPeriodEx" runat="server" TargetControlID="txtPeriod" 
                                        Mask="99"
                                        OnFocusCssClass="MaskedEditFocus"
                                        MaskType="Number"
                                        InputDirection="RightToLeft"
                                        AcceptNegative="None"/>
        <ajaxToolkit:MaskedEditExtender ID="txtMaxEx" runat="server" TargetControlID="txtMax" 
                                        Mask="99"
                                        OnFocusCssClass="MaskedEditFocus"
                                        MaskType="Number"
                                        InputDirection="RightToLeft"
                                        AcceptNegative="None"/>

    </div>
    
</asp:Content>

