<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateApplication.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    This is the Administrator Page:</p>
    <p>
        &nbsp;</p>
    <p>
        New User:</p>
    <p>
        User Name:<asp:TextBox ID="usernameTB" runat="server"></asp:TextBox>
    </p>
    <p>
        User Password:<asp:TextBox ID="userPasswordTB" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 342px; height: 451px">
                    <p>
                        Members:</p>
                    <p>
                        <asp:GridView ID="membersGV" runat="server">
                        </asp:GridView>
                    </p>
                    <p>
                        First Name:<asp:TextBox ID="firstNameTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Last Name:<asp:TextBox ID="lastNameTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Phone Number:<asp:TextBox ID="phoneNumberTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Email:<asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="addMemberBtn" runat="server" OnClick="addMemberBtn_Click" Text="Add Member" />
                    </p>
                    <p>
                        &nbsp;</p>
                </td>
                <td style="width: 654px; height: 451px">
                    <p>
                        Delete Member:</p>
                    <p>
                        Member ID:<asp:TextBox ID="deleteMemberTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
    &nbsp;<asp:Button ID="deleteMemberBtn" runat="server" OnClick="deleteMemberBtn_Click" Text="Delete " />
                    </p>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 362px">
                    <p>
                        Instructors:</p>
                    <p>
                        <asp:GridView ID="instructorGV" runat="server">
                        </asp:GridView>
                    </p>
                    <p>
                        First Name:<asp:TextBox ID="instructorFNTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Last Name:<asp:TextBox ID="instructorLNTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        Phone Number:<asp:TextBox ID="instructorPNTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="addInstructorBtn" runat="server" OnClick="addInstructorBtn_Click" Text="Add Instructor" />
                    </p>
                </td>
                <td>
                    <p>
                        Delete Instructor:</p>
                    <p>
                        Instructor ID:
                        <asp:TextBox ID="deleteInstructorTB" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="deleteInstructorBtn" runat="server" OnClick="deleteInstructorBtn_Click" Text="Delete" />
                    </p>
                </td>
                <td>
                    <br />
                </td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Assign a Member To Section:</p>
    <p>
        Possible Sections: Karate Age-Uke, Karate Chudan-Uke</p>
    <p>
        Section Name:<asp:TextBox ID="sectionNameTB" runat="server"></asp:TextBox>
    </p>
    <p>
        Member_ID:<asp:TextBox ID="memberIDTB" runat="server"></asp:TextBox>
    </p>
    <p>
        Instructor_ID:<asp:TextBox ID="instructorIDTB" runat="server"></asp:TextBox>
    </p>
    <p>
        Section Fee:<asp:TextBox ID="sectionFeeTB" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="assignBtn" runat="server" OnClick="assignBtn_Click" Text="Assign" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut1" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <br />
    </p>
</asp:Content>
