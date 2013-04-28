<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="April.Web.Select" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div>
        <div><asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" Text="刷新" /></div>   
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
    <div id="viewForm" runat="server">
        <asp:Label ID="Label2" runat="server" Text="课程名" AssociatedControlID="lblvName"/>
        <asp:Label ID="lblvName" runat="server"/>
        <asp:Label ID="Label3" runat="server" Text="教师名" AssociatedControlID="lblvTeacher"/>
        <asp:Label ID="lblvTeacher" runat="server"/>
        <asp:Label ID="Label8" runat="server" Text="学分" AssociatedControlID="lblvCredit"/>
        <asp:Label ID="lblvCredit" runat="server"/>
        <asp:Label ID="Label4" runat="server" Text="总学时" AssociatedControlID="lblvPeriod"/>
        <asp:Label ID="lblvPeriod" runat="server"/>小时
        <asp:Label ID="Label6" runat="server" Text="课内学时" AssociatedControlID="lblvHours"/>
        <asp:Label ID="lblvHours" runat="server"/>小时
        <asp:Label ID="Label7" runat="server" Text="最大人数" AssociatedControlID="lblvMax"/>
        <asp:Label ID="lblvMax" runat="server"/>
        <asp:Label ID="Label5" runat="server" Text="开课学院" AssociatedControlID="lblvLocation"/>
        <asp:Label ID="lblvLocation" runat="server"/>
        <div id="editCommand" runat="server">
            <asp:Button ID="btnSave" runat="server" Text="选择" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>
