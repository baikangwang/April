<%@ Page Title="成绩管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScoreMgr.aspx.cs" Inherits="April.Web.ScoreMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="css/list.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
    <div id="ListCourse" class="list">
        <div class="title"><span>选修课程表</span></div>
        <div class="listcommand"><asp:Button ID="btnRefresh" CssClass="refresh" runat="server" OnClick="Refresh_Click" ToolTip="刷新" /></div>   
        <asp:GridView ID="gvCourse" runat="server" OnDataBinding="Course_DataBinding">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                    DataNavigateUrlFormatString="~/ScoreMgr.aspx?Id={0}" DataTextField="Name" 
                    HeaderText="课程名" />
                <asp:TemplateField HeaderText="教师名">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Teacher") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Credit" HeaderText="学分" />
                <asp:BoundField DataField="Location" HeaderText="上课地点" />
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
    <div id="ListStudent" runat="server" class="list">
        <div class="title"><span>修改选修课成绩</span></div>
        <div class="message"><asp:Label ID="lblMessage" runat="server" Text=""/></div>
        <div class="listcommand"><asp:Button ID="btnRefreshStd" runat="server" CssClass="refresh" OnClick="RefreshStd_Click" ToolTip="刷新" /></div>   
        <asp:GridView ID="gvStudent" runat="server" OnDataBinding="Student_DataBinding" 
            onrowupdated="gvStudent_RowUpdated" onrowupdating="gvStudent_RowUpdating" 
            onrowediting="gvStudent_RowEditing" DataKeyNames="Id" 
            onrowcancelingedit="gvStudent_RowCancelingEdit">
            <Columns>
                <asp:TemplateField HeaderText="学号">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" OnDataBinding="Id_DataBinding"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" OnDataBinding="Id_DataBinding"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" OnDataBinding="Name_DataBinding"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label6" runat="server" OnDataBinding="Name_DataBinding"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" CssClass="gender" OnDataBinding="Gender_DataBinding"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label7" runat="server" CssClass="gender" OnDataBinding="Gender_DataBinding"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年级">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" OnDataBinding="Grade_DataBinding"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label8" runat="server" OnDataBinding="Grade_DataBinding"></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学分">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" OnDataBinding="Credit_DataBinding"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分数">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtScore" runat="server" CssClass="double" Text='<%# Bind("Score") %>'/>
                        <ajaxToolkit:MaskedEditExtender ID="txtScoreEx" runat="server" TargetControlID="txtScore" 
                                                        Mask="999"
                                                        OnFocusCssClass="MaskedEditFocus"
                                                        MaskType="Number"
                                                        InputDirection="RightToLeft"
                                                        AcceptNegative="None"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" OnDataBinding="Score_DataBinding"></asp:Label>
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" CssClass="edit" ToolTip="修改分数" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" 
                                        CommandName="Update" CssClass="save" ToolTip="保存"/>
                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                              CommandName="Cancel" CssClass="cancel" ToolTip="取消"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="empty">
                    <thead>
                        <tr>
                            <th>学号</th>
                            <th>姓名</th>
                            <th>性别</th>
                            <th>年级</th>
                            <th>分数</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td colspan="5">没有成绩记录</td></tr>
                    </tbody>                
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
