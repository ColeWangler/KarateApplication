using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApplication
{
    public partial class logon : System.Web.UI.Page
    {
        //The karate data context and database connection string.
        KarateSchoolDataContext dbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Cole Wangler\\OneDrive - North Dakota University System\\Desktop\\KarateApplication\\App_Data\\KarateSchool.mdf\";Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Our data base connection object
            dbcon = new KarateSchoolDataContext(connString);

            try
            {
                //Getting the inputed username and password
                string userName = Login1.UserName;
                string pass = Login1.Password;

                //Getting the first record from the data base table that is associated with the password and username
                NetUser result = (from x in dbcon.NetUsers
                                  where x.UserPassword == pass && x.UserName == userName
                                  select x).First();

                //If we find a record in the NetUser Table we will redirect them
                if (result != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(userName, true);

                    //Our specific pages to send the user
                    if (result.UserType == "Administrator")
                        Response.Redirect("~/mywork/Administrator.aspx");
                    if (result.UserType == "Instructor")
                        Response.Redirect("~/mywork/Instructor.aspx");
                    if (result.UserType == "Member")
                        Response.Redirect("~/mywork/Member.aspx");
                }
                else
                {
                    Response.Redirect("logon.aspx", true);
                }

            }
            catch (Exception ex)
            {
                //We should get an error if something went wrong
                errorLbl.Text = ex.Message;
            }
        }
    }
}