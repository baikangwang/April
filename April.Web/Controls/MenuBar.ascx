
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="April.Web.Controls.MenuBar" %>
    <ul runat="server" id="Menu">
        <li runat="server" id="itemLogout" ><asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">[<asp:Label ID="lblUser" runat="server" Text=""></asp:Label>登出]</asp:LinkButton></li>
        <li runat="server" id="itemLogin"><asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click">登录</asp:LinkButton></li>
        <li runat="server" id="itemHome"><asp:LinkButton ID="btnHome" runat="server" OnClick="link_Click">首页</asp:LinkButton></li>
        <!--Administrator-->
        <li runat="server" id="itemStudentMgr"><asp:LinkButton ID="btnStudentMgr" runat="server" OnClick="link_Click">学生管理</asp:LinkButton></li>
        <li runat="server" id="itemTeacherMgr"><asp:LinkButton ID="btnTeacherMgr" runat="server" OnClick="link_Click">教师管理</asp:LinkButton></li>
        <li runat="server" id="itemCourseMgr"><asp:LinkButton ID="btnCourseMgr" runat="server" OnClick="link_Click">课程管理</asp:LinkButton></li>
        <!--Teacher-->
        <li runat="server" id="itemTchProfile"><asp:LinkButton ID="btnTchProfile" runat="server" OnClick="link_Click">个人信息</asp:LinkButton></li>
        <li runat="server" id="itemTchQuery"><asp:LinkButton ID="btnTchQuery" runat="server" OnClick="link_Click">查询</asp:LinkButton></li>
        <!--Student-->
        <li runat="server" id="itemStdProfile"><asp:LinkButton ID="btnStdProfile" runat="server" OnClick="link_Click">个人信息</asp:LinkButton></li>
        <li runat="server" id="itemStdQuery"><asp:LinkButton ID="btnStdQuery" runat="server" OnClick="link_Click">查询</asp:LinkButton></li>
        <li runat="server" id="itemSelect"><asp:LinkButton ID="btnSelect" runat="server" OnClick="link_Click">选课</asp:LinkButton></li>

    </ul>
