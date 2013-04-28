<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseMgr.aspx.cs" Inherits="April.Web.CourseMgr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div>
        <div><asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/CourseMgr.aspx?Mode=Edit">添加</asp:HyperLink></div>
        <div><asp:Button ID="btnRefresh" runat="server" OnClick="Refresh_Click" Text="刷新" /></div>   
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
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandArgument=<%#Eval("Id")%> CommandName="Delete" Text="删除" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField Text="编辑" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/CourseMgr.aspx?Id={0}&Mode=Edit" />
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
        <div id="viewCommand">
            <asp:HyperLink ID="btnEdit" runat="server">修改</asp:HyperLink>
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/CourseMgr.aspx">关闭</asp:HyperLink>
        </div>
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
    </div>
    <div id="editForm" runat="server">
        <asp:Label ID="lblName" runat="server" Text="课程名" AssociatedControlID="txtName"/>
        <asp:TextBox ID="txtName" runat="server"/>
        <asp:Label ID="lblTeacher" runat="server" Text="教师名" AssociatedControlID="cmbTeacher"/>
        <ajaxToolkit:ComboBox ID="cmbTeacher" runat="server" OnDataBinding="cmbTeacher_DataBinding" OnDataBound="cmbTeacher_DataBound"/>
        
        <asp:Label ID="lblCredit" runat="server" Text="学分" AssociatedControlID="txtCredit"/>
        <asp:TextBox ID="txtCredit" runat="server"/>
        <asp:Label ID="lblPeriod" runat="server" Text="总学时" AssociatedControlID="txtPeriod"/>
        <asp:TextBox ID="txtPeriod" runat="server"/>小时
        <asp:Label ID="lblHours" runat="server" Text="课内学时" AssociatedControlID="txtHours"/>
        <asp:TextBox ID="txtHours" runat="server"/>小时
        <asp:Label ID="lblMax" runat="server" Text="最大人数" AssociatedControlID="txtMax"/>
        <asp:TextBox ID="txtMax" runat="server"/>
        <asp:Label ID="lblLocation" runat="server" Text="开课学院" AssociatedControlID="txtLocation"/>
        <asp:TextBox ID="txtLocation" runat="server"/>
        <div id="editCommand" runat="server">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" Text="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server">重置</asp:HyperLink>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/CourseMgr.aspx">取消</asp:HyperLink>
        </div>
    </div>
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
    
</asp:Content>

