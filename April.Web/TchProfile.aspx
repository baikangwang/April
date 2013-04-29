<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TchProfile.aspx.cs" Inherits="April.Web.TchProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true" />
    <div id="err"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></div>
    <div id="viewForm" runat="server">
        <div id="viewCommand">
            <asp:HyperLink ID="btnEdit" runat="server">修改</asp:HyperLink>
            <asp:HyperLink ID="btnClose" runat="server" NavigateUrl="~/TchProfile.aspx">关闭</asp:HyperLink>
        </div>
        <asp:Label ID="Label1" runat="server" Text="工号" AssociatedControlID="lblvId"></asp:Label>
        <asp:Label ID="lblvId" runat="server"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="姓名" AssociatedControlID="lblvName"></asp:Label>
        <asp:Label ID="lblvName" runat="server"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="性别" AssociatedControlID="lblvGender"></asp:Label>
        <asp:Label ID="lblvGender" runat="server"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="职称" AssociatedControlID="lblvTitle"></asp:Label>
        <asp:Label ID="lblvTitle" runat="server"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="电话" AssociatedControlID="lblvContactNo"></asp:Label>
        <asp:Label ID="lblvContactNo" runat="server"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="密码" AssociatedControlID="txtPwd"></asp:Label>
        <asp:Label ID="lblvPwd" runat="server"></asp:Label>
    </div>
    <div id="editForm" runat="server">
        <asp:Label ID="lblId" runat="server" Text="工号" AssociatedControlID="txtId"></asp:Label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
        <asp:Label ID="lblName" runat="server" Text="姓名" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <asp:CheckBox ID="ckbGender" Checked="true" runat="server"/>
                <ajaxToolkit:ToggleButtonExtender ID="ckbToggle" runat="server"
                                                  TargetControlID="ckbGender"
                                                  ImageWidth="40"
                                                  ImageHeight="40"
                                                  CheckedImageUrl="images/icons/male.gif"
                                                  UncheckedImageUrl="images/icons/female.gif"
                                                  CheckedImageAlternateText="男"
                                                  UncheckedImageAlternateText="女" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="lblTitle" runat="server" Text="职称" AssociatedControlID="txtTitle"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <asp:Label ID="lblContactNo" runat="server" Text="电话" AssociatedControlID="txtContactNo"></asp:Label>
        <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
        <asp:Label ID="lblPwd" runat="server" Text="密码" AssociatedControlID="txtPwd"></asp:Label>
        <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
        <div id="editCommand" runat="server">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="save" Text="保存" OnClick="btnSave_Click" />
            <asp:HyperLink ID="btnReset" runat="server">重置</asp:HyperLink>
            <asp:HyperLink ID="btnCancel" runat="server" NavigateUrl="~/TchProfile.aspx">取消</asp:HyperLink>
        </div>
        
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
