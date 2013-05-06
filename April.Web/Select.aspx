<%@ Page Title="学生选课" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="April.Web.Select" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/list.css" rel="stylesheet" type="text/css" />
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="ListCourse" class="list">
        <div class="title"><span>选择课程</span></div>
        <div class="listcommand"><asp:Button ID="btnRefresh" CssClass="refresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" /></div>   
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvCourses_DataBinding">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/Select.aspx?Id={0}" DataTextField="Name" 
                    HeaderText="课程名" />
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Teacher") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Credit" HeaderText="学分" />
                <asp:BoundField DataField="Location" HeaderText="上课地点" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# Eval("Id", "~/Select.aspx?Id={0}") %>' ToolTip="选择" CssClass="select"></asp:HyperLink>
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
        <div class="title"><span>选择课程确认</span></div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:Button ID="btnSave" runat="server" CssClass="select" ToolTip="选择" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" CssClass="cancel" ToolTip="取消" OnClick="btnCancel_Click" />
        </div>
        <table class="fields">
            <tr>
                <td class="field">
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="课程名" AssociatedControlID="lblvName"/>
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
                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="教师名" AssociatedControlID="lblvTeacher"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvTeacher" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="学分" AssociatedControlID="lblvCredit"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvCredit" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="总学时" AssociatedControlID="lblvPeriod"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvPeriod" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="课内学时" AssociatedControlID="lblvHours"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvHours" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="最大人数" AssociatedControlID="lblvMax"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvMax" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="field">
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="上课地点" AssociatedControlID="lblvLocation"/>
                </td>
                <td class="field">
                    <asp:Label ID="lblvLocation" runat="server"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
