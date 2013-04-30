<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Theme="April" CodeBehind="Select.aspx.cs" Inherits="April.Web.Select" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/list.css" rel="stylesheet" type="text/css" />
    <link href="css/form.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .body .form .editcommand .cancel
        {
            cursor:pointer;
            margin:2px;
            line-height:32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="ListCourse" class="list">
        <div class="topborder">&nbsp;</div>
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
                <asp:BoundField DataField="Location" HeaderText="开课学院" />
                <asp:HyperLinkField Text="选择" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Select.aspx?Id={0}" />
            </Columns>
            <EmptyDataTemplate>
                <table>
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
    <div id="err"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
    <div id="viewForm" runat="server" class="form">
        <div class="topborder">&nbsp;</div>
        <table class="fields">
            <tr>
                <td>
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="课程名" AssociatedControlID="lblvName"/>
                </td>
                <td>
                    <asp:Label ID="lblvName" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="教师名" AssociatedControlID="lblvTeacher"/>
                </td>
                <td>
                    <asp:Label ID="lblvTeacher" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="学分" AssociatedControlID="lblvCredit"/>
                </td>
                <td>
                    <asp:Label ID="lblvCredit" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="总学时" AssociatedControlID="lblvPeriod"/>
                </td>
                <td>
                    <asp:Label ID="lblvPeriod" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="课内学时" AssociatedControlID="lblvHours"/>
                </td>
                <td>
                    <asp:Label ID="lblvHours" runat="server"/>小时
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="最大人数" AssociatedControlID="lblvMax"/>
                </td>
                <td>
                    <asp:Label ID="lblvMax" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="开课学院" AssociatedControlID="lblvLocation"/>
                </td>
                <td>
                    <asp:Label ID="lblvLocation" runat="server"/>
                </td>
            </tr>
        
        </table>
        <div id="editCommand" runat="server" class="editcommand">
            <asp:Button ID="btnSave" runat="server" CssClass="save" ToolTip="选择" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" CssClass="cancel" ToolTip="取消" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>
