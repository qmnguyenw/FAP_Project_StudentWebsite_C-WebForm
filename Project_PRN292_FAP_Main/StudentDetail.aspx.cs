using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    

    public partial class StudentDetail : System.Web.UI.Page
    {
        public string imgPath;
        Student onlineStudent;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsUserLogedIn();

            onlineStudent = (Student)Session["onlineStudent"];

            btnStudent.Text = onlineStudent.StudentShortName.ToLower();

            if (!IsPostBack)
            {
                lbLogin.Text = onlineStudent.StudentShortName;
                lbName.Text = onlineStudent.StudentName;
                imgPath = onlineStudent.Image;
                lbEmail.Text = onlineStudent.Email;
            }
        }

        private void IsUserLogedIn()
        {
            if (Session["IsUserLogIn"] == null || !Convert.ToBoolean(Session["IsUserLogIn"]))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void linkAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("Attendance.aspx");
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetail.aspx");
        }
    }
}