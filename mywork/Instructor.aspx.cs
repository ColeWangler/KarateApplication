using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApplication.mywork
{
    public partial class Instructor : System.Web.UI.Page
    {
        //Our Data Context object and data base connection string
        KarateSchoolDataContext dbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Initializing the data base connection object
                dbcon = new KarateSchoolDataContext(connString);
                int instructorID = -1;

                //Getting the current user object that is logged in
                string karUser = User.Identity.Name;
                NetUser myUser = (from x in dbcon.NetUsers
                                  where x.UserName == karUser
                                  select x).First();

                //Getting the users ID
                instructorID = myUser.UserID;

                //Getting the instructor record from the data base in the instructor table
                var instructor = from x in dbcon.Instructors
                                 where x.InstructorID == instructorID
                                 select new { x.InstructorFirstName, x.InstructorLastName };

                string instructorFirstName = instructor.First().InstructorFirstName;
                string instructorLastName = instructor.First().InstructorLastName;

                //Showing the instructors first and last name
                instructorLbl.Text = instructorFirstName + " " + instructorLastName;

                //Getting the appropriate information from the tables and updating the grid view to show them to the user
                var results = from item in dbcon.Instructors
                              from a in dbcon.Sections
                              from b in dbcon.Members
                              where item.InstructorID == instructorID && a.Instructor_ID == instructorID && a.Member_ID == b.Member_UserID
                              select new { a.SectionName, b.MemberFirstName, b.MemberLastName };
                instructorGV.DataSource = results;
                DataBind();
            }
            catch (Exception ex)
            {
                //Show an error if something went wrong.
                instructorLbl.Text = ex.Message;
            }
        }
    }
}