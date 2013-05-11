<%@ Page Title="已选课程查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StdQuery.aspx.cs" Inherits="April.Web.StdQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/list.css" rel="stylesheet" type="text/css" />
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="ListCourse" class="list">
        <div class="title"><span>已选修课程</span></div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div class="listcommand"><asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh"/></div>   
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvCourses_DataBinding" 
                onrowcommand="gvCourses_RowCommand" 
                onrowdeleting="gvCourses_RowDeleting">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/StdQuery.aspx?Id={0}" DataTextField="Name" 
                    HeaderText="课程名" />
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Teacher") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Credit" HeaderText="学分" />
                <asp:BoundField DataField="Location" HeaderText="上课地点" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandArgument=<%#Eval("Id")%> CommandName="Delete" ToolTip="删除" CssClass="delete" />
                        <ajaxToolkit:ConfirmButtonExtender ID="confirmBtnExt" runat="server"
                                                           TargetControlID="LinkButton1"
                                                           DisplayModalPopupID="modalPopupExt1"/>
                        <ajaxToolkit:ModalPopupExtender ID="modalPopupExt1" runat="server" TargetControlID="LinkButton1" PopupControlID="pnlContent" OkControlID="btnOK" CancelControlID="btnCancel" BackgroundCssClass="windowBg" />
                        <asp:Panel ID="pnlContent" runat="server" CssClass="confirmpanel">
                            确定删除已选修课程吗？
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
                            <th>课程名</th>
                            <th>教师名</th>
                            <th>学分</th>
                            <th>上课地点</th>
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
        <div class="title"><span>课程信息</span></div>
        <div id="viewCommand" class="viewcommand">
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/StdQuery.aspx" ToolTip="关闭" CssClass="close"/>
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
                <td class="field" colspan="2">
                    <asp:Label CssClass="label" ID="Label9" runat="server" Text="课程介绍" AssociatedControlID="lblvName"/>
                    <br/>
                    <br/>
                    <asp:Label ID="lblvDescription" CssClass="description" runat="server"/>
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
                    <asp:Label CssClass="label" ID="Label5" runat="server" Text="上课地点" AssociatedControlID="lblvLocation"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvLocation" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
