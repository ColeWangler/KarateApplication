using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApplication.mywork
{
    public partial class Administrator : System.Web.UI.Page
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
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






    }
}