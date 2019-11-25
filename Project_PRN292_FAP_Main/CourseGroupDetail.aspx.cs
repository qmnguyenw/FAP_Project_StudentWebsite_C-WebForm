using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class CourseGroupDetail : System.Web.UI.Page
    {
        public string termID = null;
        public string currentDep = null;
        List<string> depList = new List<string>();
        Student onlineStudent;
        public string cdID;

        protected void Page_Load(object sender, EventArgs e)
        {
            onlineStudent = StudentList.getStudentByStudent_Code("he130022");
            Session["onlineStudent"] = onlineStudent;
            Session["IsUserLogIn"] = true;
            IsUserLogedIn();
            onlineStudent = (Student)Session["onlineStudent"];
            if (!IsPostBack)
            {
                btnStudent.Text = onlineStudent.StudentShortName.ToLower();


                termID = Request.QueryString["term"];
                if (termID == null)
                {
                    termID = DataAccess.GetDataBySql("Select top 1 * from Term order by end_date desc").Rows[0]["term_id"].ToString();
                }
                LoadRpTerm();
                depList = GetAllDep();
                string depQuery = Request.QueryString["dep"];
                if (depQuery == null)
                {
                    if (depList.Count > 0) currentDep = depList[0];
                }
                else
                {
                    currentDep = depQuery;
                }
                LoadRpDep();
                string cdIDQuery = Request.QueryString["course"];
                if (cdIDQuery == null)
                {
                    cdID = "0";
                }else
                {
                    cdID = cdIDQuery;
                }
                LoadRpSList();
            }
        }

        private void LoadRpSList()
        {
            rpStudentList.DataSource = GetAllStudentOfCoureDetail();
            rpStudentList.DataBind();
        }

        private void LoadRpTerm()
        {
            rpTerm.DataSource = GetAllTerm();
            rpTerm.DataBind();
        }

        private void LoadRpDep()
        {
            rpDep.DataSource = depList;
            rpDep.DataBind();
        }

        List<Student> GetAllStudentOfCoureDetail()
        {
            DataTable dt = DataAccess.GetDataBySql("select s.* from Student s, CourseStudent cs where s.student_code = cs.student_code and cs.course_detail_id = "+cdID+" order by cs.student_code asc");
            List<Student> list = new List<Student>();
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                Student s = new Student();
                s.No = i+"";
                s.Image = "Image/" + dr["img"].ToString();
                s.StudentCode = dr["student_code"].ToString();
                s.StudentName = dr["student_name"].ToString();
                list.Add(s);
            }
            return list;
        }

        List<Term> GetAllTerm()
        {
            DataTable dt = DataAccess.GetDataBySql("select * from Term order by end_date asc");
            List<Term> list = new List<Term>();
            foreach (DataRow dr in dt.Rows)
            {
                Term t = new Term();
                t.TID = Convert.ToInt32(dr["term_id"]);
                t.TName = dr["name"].ToString();
                t.Start = Convert.ToDateTime(dr["start_date"]);
                t.End = Convert.ToDateTime(dr["end_date"]);
                list.Add(t);
            }
            return list;
        }

        List<string> GetAllDep()
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select distinct department from Course c, CourseDetail cd where c.course_code = cd.course_code and cd.term_id = {0}", termID));
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string t = dr["department"].ToString();
                list.Add(t);
            }
            return list;
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

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetail.aspx");
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}