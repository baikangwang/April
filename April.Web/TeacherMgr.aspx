<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherMgr.aspx.cs" Inherits="April.Web.TeacherMgr" %>
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
            <asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/TeacherMgr.aspx?Mode=Edit" CssClass="edit" ToolTip="添加"/>
            <asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh" />
        </div>   
        <asp:GridView ID="gvTeachers" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvTeachers_DataBinding" 
                onrowcommand="gvTeachers_RowCommand" 
                onrowdeleting="gvTeachers_RowDeleting">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/TeacherMgr.aspx?Id={0}" DataTextField="Id" 
                    HeaderText="工号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text=" " CssClass="gender" OnDataBinding="Gender_DataBinding"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="职称" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandArgument=<%#Eval("Id")%> CommandName="Delete" ToolTip="删除" CssClass="delete" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("Id", "~/TeacherMgr.aspx?Id={0}&Mode=Edit") %>' ToolTip="编辑" CssClass="edit"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="records">
                    <thead>
                        <tr>
                            <th>工号</th>
                            <th>姓名</th>
                            <th>性别</th>
                            <th>职称</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td colspan="4">没有教师记录</td></tr>
                    </tbody>                
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div id="err"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
    <div id="viewForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnEdit" runat="server" CssClass="edit" ToolTip="修改"/>
            <asp:HyperLink ID="btnClose" runat="server" CssClass="close" ToolTip="关闭" NavigateUrl="~/TeacherMgr.aspx"/>
        </div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="Label1" CssClass="identity" runat="server" Text="工号" AssociatedControlID="lblvId"/>
                </td>
                <td>
                    <asp:Label ID="lblvId" runat="server"/>
                    <asp:Label ID="lblvGender" CssClass="gender" runat="server"/>
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
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="职称" AssociatedControlID="lblvTitle"/>
                </td>
                <td>
                    <asp:Label ID="lblvTitle" runat="server"/>
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
                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="密码" AssociatedControlID="txtPwd"/>
                </td>
                <td>
                    <asp:Label ID="lblvPwd" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="editForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="lblId" CssClass="identity" runat="server" Text="工号" AssociatedControlID="txtId"/>
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
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" ToolTip="保存" OnClick="btnSave_Click" CssClass="save" />
            <asp:HyperLink ID="btnReset" runat="server" ToolTip="重置" CssClass="reset"/>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/TeacherMgr.aspx" ToolTip="取消" CssClass="cancel"/>
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
