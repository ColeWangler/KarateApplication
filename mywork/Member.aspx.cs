using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApplication.mywork
{
    public partial class Member : System.Web.UI.Page
    {
        //Our Data Context object and data base connection string
        KarateSchoolDataContext dbcon;
        string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //Initializing the data base connection object
                dbcon = new KarateSchoolDataContext(conString);

                //The instance variables we will use
                string firstName = "";
                string lastName = "";
                int memberID = -1;

                //Getting the current user object that is logged in
                string karUser = User.Identity.Name;
                NetUser myUser = (from x in dbcon.NetUsers
                                  where x.UserName == karUser
                                  select x).First();
                //Getting the current user ID so we can find them in the member table
                memberID = myUser.UserID;




                //Getting the members record from the data base
                var a = (from item in dbcon.Members
                         where item.Member_UserID == memberID
                         select new
                         {
                             FName = item.MemberFirstName,
                             LName = item.MemberLastName
                         }).First();

                firstName = a.FName;
                lastName = a.LName;

                //Showing the users first and last name
                memberLbl.Text = firstName + " " + lastName;


                //Getting all the fees that a specific member has in the database
                var b = from x in dbcon.Sections
                        where x.Member_ID == memberID
                        select new { x.SectionFee };
                decimal count = 0;

                //Totaling up the fees
                foreach (var x in b)
                {
                    count += x.SectionFee;
                }
                //Showing the total to the user
                expenseLbl.Text = count.ToString("C");


                //Getting the record and specific information and showing in the grid view
                var results = from x in dbcon.Instructors
                              from y in dbcon.Members
                              from z in dbcon.Sections
                              where y.Member_UserID == memberID && y.Member_UserID == z.Member_ID && z.Instructor_ID == x.InstructorID
                              select new { z.SectionName, x.InstructorFirstName, x.InstructorLastName, z.SectionStartDate, z.SectionFee };
                memberGV.DataSource = results;
                memberGV.DataBind();
            }
            catch (Exception ex)
            {
                expenseLbl.Text = ex.Message;
            }
        }
    }
}