<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="KarateApplication.mywork.Instructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    Hello Instructor,</p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="instructorLbl" runat="server" Text="Label"></asp:Label>
&nbsp;,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LoginName ID="LoginName1" runat="server" />
</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView ID="instructorGV" runat="server">
    </asp:GridView>
</p>
<p>
    &nbsp;</p>
<p>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
</p>
<p>
    &nbsp;</p>
</asp:Content>
