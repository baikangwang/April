<%@ Page Title="成绩查询" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScoreQuery.aspx.cs" Inherits="April.Web.ScoreQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/list.css" rel="stylesheet" type="text/css" />
    <link href="css/form.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ListCourse" class="list">
    <div class="title"><span>已选修课程</span></div>
        <div class="listcommand"><asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" CssClass="refresh"/></div>   
        <asp:GridView ID="gvCourses" runat="server" AutoGenerateColumns="False" 
            OnDataBinding="gvCourses_DataBinding">
            <Columns>
                <asp:TemplateField HeaderText="课程名">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" OnDataBinding="Id_DataBinding"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" OnDataBinding="Teacher_DataBinding"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学分">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" OnDataBinding="Credit_DataBinding"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开课学院">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" OnDataBinding="Location_DataBinding"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分数">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" OnDataBinding="Score_DataBinding"></asp:Label>
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
                            <th>分数</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td colspan="5">没有课程记录</td></tr>
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
</asp:Content>
