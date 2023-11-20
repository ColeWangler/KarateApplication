using KarateApplication.mywork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApplication
{
    public partial class Administrator : System.Web.UI.Page
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;

        public void Refresh()
        {
            dbcon = new KarateSchoolDataContext(connString);

            var memberResults = from x in dbcon.Members
                                select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined };
            membersGV.DataSource = memberResults;
            DataBind();


            var instructorResults = from x in dbcon.Instructors
                                    select new { x.InstructorFirstName, x.InstructorLastName };
            instructorGV.DataSource = instructorResults;
            DataBind();

        }



        public void Clear()
        {
            usernameTB.Text = "";
            userPasswordTB.Text = "";
            firstNameTB.Text = "";
            lastNameTB.Text = "";
            phoneNumberTB.Text = "";
            emailTB.Text = "";
            instructorFNTB.Text = "";
            instructorLNTB.Text = "";
            instructorPNTB.Text = "";
            deleteMemberTB.Text = "";
            deleteInstructorTB.Text = "";
            sectionFeeTB.Text = "";
            memberIDTB.Text = "";
            instructorIDTB.Text = "";
            sectionFeeTB.Text = "";
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);

            NetUser user = new NetUser();
            user.UserName = usernameTB.Text;
            user.UserPassword = userPasswordTB.Text;
            user.UserType = "Member";
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();


            Member newMember = new Member
            {
                Member_UserID = user.UserID,
                MemberFirstName = firstNameTB.Text,
                MemberLastName = lastNameTB.Text,
                MemberPhoneNumber = phoneNumberTB.Text,
                MemberEmail = emailTB.Text,
                MemberDateJoined = DateTime.Now
            };

            dbcon.Members.InsertOnSubmit(newMember);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();

            Clear();
        }

        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);

            NetUser user = new NetUser();
            user.UserName = usernameTB.Text;
            user.UserPassword = userPasswordTB.Text;
            user.UserType = "Instructor";
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();


            Instructor newInstructor = new Instructor
            {
                InstructorID = user.UserID,
                InstructorFirstName = instructorFNTB.Text,
                InstructorLastName = instructorLNTB.Text,
                InstructorPhoneNumber = instructorPNTB.Text
            };

            dbcon.Instructors.InsertOnSubmit(newInstructor);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();

            Clear();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Response.Redirect("logon.aspx", true);
        }

        protected void assignBtn_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);




            Section newSection = new Section
            {
                SectionName = sectionNameTB.Text,
                SectionStartDate = DateTime.Now,
                Member_ID = Convert.ToInt32(memberIDTB.Text),
                Instructor_ID = Convert.ToInt32(instructorIDTB.Text),
                SectionFee = Convert.ToDecimal(sectionFeeTB.Text)
            };

            dbcon.Sections.InsertOnSubmit(newSection);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();

            Clear();

        }

        protected void deleteMemberBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Getting the id for which model the user wants to delete
            int selectedId = Convert.ToInt32(deleteMemberTB.Text);

            //select record
            Member selectedMember = (from item in dbcon.Members where item.Member_UserID == selectedId select item).First();

            //delete selected record
            dbcon.Members.DeleteOnSubmit(selectedMember);
            dbcon.SubmitChanges();

            //Refresh the Table
            Refresh();

            Clear();
        }

        protected void deleteInstructorBtn_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);

            //Getting the id for which model the user wants to delete
            int selectedId = Convert.ToInt32(deleteInstructorTB.Text);

            //select record
            Instructor selectedInstructor = (from item in dbcon.Instructors where item.InstructorID == selectedId select item).First();

            //delete selected record
            dbcon.Instructors.DeleteOnSubmit(selectedInstructor);
            dbcon.SubmitChanges();

            //Refresh the Table
            Refresh();

            Clear();

        }
    }
}