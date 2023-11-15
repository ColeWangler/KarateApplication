<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="KarateApplication.mywork.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    This is the Member Page:</p>
<p>
</p>
<p>
    <asp:LoginName ID="LoginName1" runat="server" />
&nbsp;,
    <asp:Label ID="memberLbl" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView ID="memberGV" runat="server">
    </asp:GridView>
</p>
<p>
    Total Expense of Member:
    <asp:Label ID="expenseLbl" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>
