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
        //Our data context and connection to database string
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;

        //The refresh method that will refresh the grid views
        public void Refresh()
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Get the appropriate Member information
            var memberResults = from x in dbcon.Members
                                select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined };
            //Update the grid view information
            membersGV.DataSource = memberResults;
            DataBind();

            //Get the appropriate Instructor information
            var instructorResults = from x in dbcon.Instructors
                                    select new { x.InstructorFirstName, x.InstructorLastName };
            //Update the Instructor grid view information
            instructorGV.DataSource = instructorResults;
            DataBind();
        }

        //The Clear method which will clear all text boxes
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

        //Once we log into the page the page will load the grid view information
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Creating a NetUser object in order to submit the new member record into the database
            NetUser user = new NetUser();
            user.UserName = usernameTB.Text;
            user.UserPassword = userPasswordTB.Text;
            user.UserType = "Member";
            //Inserting the NetUser into the database
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();

            //Creating a new Member object to submit into the database with the above user ID
            Member newMember = new Member
            {
                Member_UserID = user.UserID,
                MemberFirstName = firstNameTB.Text,
                MemberLastName = lastNameTB.Text,
                MemberPhoneNumber = phoneNumberTB.Text,
                MemberEmail = emailTB.Text,
                MemberDateJoined = DateTime.Now
            };

            //Inserting the member into the database
            dbcon.Members.InsertOnSubmit(newMember);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();
            //Clear all text boxes
            Clear();
        }


        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Creating a NetUser object in order to submit the new instructor record into the database
            NetUser user = new NetUser();
            user.UserName = usernameTB.Text;
            user.UserPassword = userPasswordTB.Text;
            user.UserType = "Instructor";
            //Inserting the NetUser into the database
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();

            //Creating a new Instructor object to submit into the database with the above user ID
            Instructor newInstructor = new Instructor
            {
                InstructorID = user.UserID,
                InstructorFirstName = instructorFNTB.Text,
                InstructorLastName = instructorLNTB.Text,
                InstructorPhoneNumber = instructorPNTB.Text
            };

            //Inserting the new instructor record into the database
            dbcon.Instructors.InsertOnSubmit(newInstructor);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();
            //Clear all current text in textboxes
            Clear();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //Redirect the user to the logon page
            Response.Redirect("logon.aspx", true);
        }

        protected void assignBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Creating a new Section object inorder to insert it into the database
            Section newSection = new Section
            {
                SectionName = sectionNameTB.Text,
                SectionStartDate = DateTime.Now,
                Member_ID = Convert.ToInt32(memberIDTB.Text),
                Instructor_ID = Convert.ToInt32(instructorIDTB.Text),
                SectionFee = Convert.ToDecimal(sectionFeeTB.Text)
            };

            //Inserting the new Section record into the database
            dbcon.Sections.InsertOnSubmit(newSection);
            dbcon.SubmitChanges();

            //Refresh the grid view to show current items
            Refresh();
            //Clear all text in the text boxes
            Clear();
        }

        protected void deleteMemberBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Getting the id for which Member record the administrator wants to delete
            int selectedId = Convert.ToInt32(deleteMemberTB.Text);

            //select record
            Member selectedMember = (from item in dbcon.Members where item.Member_UserID == selectedId select item).First();

            //delete selected record
            dbcon.Members.DeleteOnSubmit(selectedMember);
            dbcon.SubmitChanges();

            //Refresh the Table
            Refresh();
            //Clear all text in the current text boxes
            Clear();
        }

        protected void deleteInstructorBtn_Click(object sender, EventArgs e)
        {
            //initialize our data context variable
            dbcon = new KarateSchoolDataContext(connString);

            //Getting the id for which Instructor record the administrator wants to delete
            int selectedId = Convert.ToInt32(deleteInstructorTB.Text);

            //select record
            Instructor selectedInstructor = (from item in dbcon.Instructors where item.InstructorID == selectedId select item).First();

            //delete selected record
            dbcon.Instructors.DeleteOnSubmit(selectedInstructor);
            dbcon.SubmitChanges();

            //Refresh the Table
            Refresh();
            //Clear the current text in all text boxes
            Clear();
        }
    }
}