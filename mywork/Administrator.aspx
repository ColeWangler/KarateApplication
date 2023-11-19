<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateApplication.mywork.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    This is the Administrator Page:</p>
    <p>
        Members:</p>
    <p>
        <asp:GridView ID="membersGV" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Instructors:</p>
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
