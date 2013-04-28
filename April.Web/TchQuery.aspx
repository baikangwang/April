<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TchQuery.aspx.cs" Inherits="April.Web.TchQuery" %>
<%@ Import Namespace="April.Entity.Base" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ListCourse">
        <div><asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" Text="刷新" /></div>   
        <asp:GridView ID="gvCourse" runat="server" OnDataBinding="Course_DataBinding" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/TchQuery.aspx?Id={0}" DataTextField="Name" 
                    HeaderText="课程名" />
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Teacher") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Credit" HeaderText="学分" />
                <asp:BoundField DataField="Location" HeaderText="开课学院" />
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
    <div id="ListStudent" runat="server">
        <div><asp:Button ID="btnRefreshStd" runat="server" OnClick="RefreshStd_Click" Text="刷新" /></div>   
        <asp:GridView ID="gvStudent" runat="server" OnDataBinding="Student_DataBinding" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="学号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# ((Gender)Eval("Gender"))==Gender.Female?"女":"男" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Grade" HeaderText="年级" />
            </Columns>
            <EmptyDataTemplate>
                <table>
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
</asp:Content>
