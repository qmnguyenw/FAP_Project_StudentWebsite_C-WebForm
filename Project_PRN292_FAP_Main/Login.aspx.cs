using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["IsUserLogin"] = false;
            }
            lbErrorCampus.Text = "";
            lbErrorName.Text = "";
            lbErrorPass.Text = "";
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (selectCampus.SelectedIndex == 0)
            {
                lbErrorCampus.Text = "You must select a campus";
                return;
            }
            if (selectCampus.SelectedIndex != 1)
            {
                lbErrorCampus.Text = "Your account not available in this campus";
                return;
            }
            string username = tbUsername.Text.ToString();
            string password = tbPassword.Text.ToString();
            Account temp = null;

            if (validData())
            {
                if (((temp = getA()) != null))
                {
                    if (password.Equals(temp.pass))
                    {
                        Student s = StudentList.getStudentByStudent_Code(temp.code.Trim());
                        Session["IsUserLogin"] = true;
                        Session["OnlineStudent"] = s;
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        lbErrorPass.Text = "Wrong Password";
                    }
                }
                else
                {
                    lbErrorName.Text = "Username not found";
                }
            }
        }


        public Account getA()
        {
            string code = tbUsername.Text.ToString();
            Account a = new Account();
            DataTable dt = DataAccess.Phong_getAccountbyCode(code);
            if (code != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    a.code = dr["student_code"].ToString();
                    a.pass = dr["password"].ToString();
                    return a;
                }

            }
            return null;
        }


        private bool validData()
        {
            bool Valid = true;
            string name = tbUsername.Text.ToString();
            string pass = tbPassword.Text.ToString();
            if (name == string.Empty)
            {
                lbErrorName.Text = "Fill the username you want to sign in";
                Valid = false;
            }
            if (name.Length > 50)
            {
                lbErrorName.Text = "Length of username cannot over 50 characters";
                Valid = false;
            }
            if (pass == string.Empty)
            {
                lbErrorPass.Text = "Cannot blank in pass, please type something";
                Valid = false;
            }
            if (pass.Length > 50)
            {
                lbErrorPass.Text = "Length of password cannot over 50 characters";
                Valid = false;
            }
            return Valid;
        }
    }
}