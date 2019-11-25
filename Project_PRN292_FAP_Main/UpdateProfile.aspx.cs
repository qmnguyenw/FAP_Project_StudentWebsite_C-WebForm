using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        Student onlineStudent;
        protected void Page_Load(object sender, EventArgs e)
        {

            IsUserLogedIn();
            //reading value from session
            onlineStudent = (Student)(Session["OnlineStudent"]);
            btnStudent.Text = onlineStudent.StudentShortName.ToLower();
            if (!IsPostBack)
            {
                loadTheText();
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

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetail.aspx");
        }


        public void loadTheText()
        {

            PhuHuynh p = getA();
            if (p == null)
            {
                return;
            }
            tbPhoneStudent.Text = p.phone;
            tbNameParent.Text = p.namePhuHuynh;
            tbPhoneParent.Text = p.phonePhuHuynh;
            taAddress.InnerText = p.DiaChiPhuHuynh;
        }


        public PhuHuynh getA()
        {

            PhuHuynh p = new PhuHuynh();
            DataTable dt = DataAccess.Phong_getPhuHuynhInforbyCode(onlineStudent.StudentCode);
            foreach (DataRow dr in dt.Rows)
            {
                p.phone = dr["phone"].ToString();
                p.namePhuHuynh = dr["parent_name"].ToString();
                p.phonePhuHuynh = dr["PhuHuynhPhone"].ToString();
                p.DiaChiPhuHuynh = dr["address"].ToString();
                return p;
            }
            return null;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                PhuHuynh p = new PhuHuynh();
                p.phone = tbPhoneStudent.Text.Trim();
                p.namePhuHuynh = tbNameParent.Text.Trim();
                p.phonePhuHuynh = tbPhoneParent.Text.Trim();
                p.DiaChiPhuHuynh = taAddress.InnerText.Trim();
                DataAccess.Phong_UpdateInfor(p, onlineStudent.StudentCode);
                loadTheText();
                success.Text = "Cập nhật thông tin thành công";
            }

        }



        public bool Valid()
        {
            Error1.Text = "";
            Error2.Text = "";
            Error3.Text = "";
            Error4.Text = "";
            Regex re = new Regex("^[0-9]{1,}$");
            Regex re2 = new Regex("^[A-Z a-zÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝàáâãèéêìíòóôõùúýĂăĐđĨĩŨũƠơƯưẠ-ỹ]+$");
            string studentPhone = tbPhoneStudent.Text.Trim();
            string nameParent = tbNameParent.Text.Trim();
            string sdtParent = tbPhoneParent.Text.Trim();
            string addParent = taAddress.InnerText.Trim();

            if (studentPhone == string.Empty)
            {
                Error1.Text = "this cannot be blank, pls enter a hi hi";
                return false;
            }
            if (nameParent == string.Empty)
            {
                Error2.Text = "this cannot be blank, pls enter a hi hi";
                return false;
            }
            if (sdtParent == string.Empty)
            {
                Error3.Text = "this cannot be blank, pls enter a hi hi";
                return false;
            }
            if (addParent == string.Empty)
            {
                Error4.Text = "this cannot be blank, pls enter a hi hi";
                return false;
            }
            if (studentPhone.Length > 50)
            {
                Error1.Text = "phone number cannot over 50 char ahi hi hi hi";
                return false;
            }
            if (!re.IsMatch(studentPhone))
            {
                Error1.Text = "dont enter string a hi hi hi";
                return false;
            }
            if (sdtParent.Length > 50)
            {
                Error3.Text = "phone number cannot over 50 char ahi hi hi hi";
                return false;
            }
            if (!re.IsMatch(sdtParent))
            {
                Error3.Text = "dont enter string a hi hi hi";
                return false;
            }
            if (nameParent.Length > 50)
            {
                Error2.Text = "name cannot over 50 characters a hi hi hi";
                return false;
            }
            if (!re2.IsMatch(nameParent))
            {
                Error2.Text = "name cannot contain number a hi hi hi";
                return false;
            }
            if (addParent.Length > 500)
            {
                Error4.Text = "over the limit of this field!!!";
                return false;
            }
            return true;
        }

    }
}