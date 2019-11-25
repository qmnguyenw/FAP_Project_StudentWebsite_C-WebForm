using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class UniversityCourses : System.Web.UI.Page
    {

        public string termID = null;
        public string currentDep = null;
        List<string> depList = new List<string>();
        Student onlineStudent;
        public List<CourseTableUniversity> recList;


        protected void Page_Load(object sender, EventArgs e)
        {
            //onlineStudent = StudentList.getStudentByStudent_Code("he130022");
            //Session["onlineStudent"] = onlineStudent;
            //Session["IsUserLogIn"] = true;
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
                recList = GetAllRecords();
            }
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

        List<CourseTableUniversity> GetAllRecords()
        {
            DataTable dt1 = DataAccess.GetDataBySql(string.Format(@"select distinct c.course_code, c.course_name from Course c, CourseDetail cd where c.course_code = cd.course_code and c.department = '{0}' and cd.term_id = {1}",currentDep,termID));
            List<CourseTableUniversity> list = new List<CourseTableUniversity>();
            foreach (DataRow dr in dt1.Rows)
            {
                CourseTableUniversity record = new CourseTableUniversity();
                record.CourseCode = dr["course_code"].ToString();
                record.CourseName = dr["course_name"].ToString();
                record.Teachers = new List<string>();
                record.CouresDetailGroup = new List<CourseDetail>();
                DataTable dtTeacher = DataAccess.GetDataBySql(string.Format("select distinct l.short_name from Lecturer l, Course c, CourseDetail cd where l.short_name = cd.lecturer_shortname and cd.course_code = c.course_code and c.department = '{0}' and cd.term_id = {1} and cd.course_code = '{2}'", currentDep,termID,record.CourseCode));
                foreach(DataRow dr2 in dtTeacher.Rows)
                {
                    record.Teachers.Add(dr2["short_name"].ToString());
                }

                DataTable dtCd = DataAccess.GetDataBySql(string.Format("select distinct cd.id, l.short_name, cd.class, COUNT(cs.student_code) as student_num from Lecturer l, Course c, CourseDetail cd, CourseStudent cs where l.short_name = cd.lecturer_shortname and cd.course_code = c.course_code and cd.id = cs.course_detail_id and c.department = '{0}' and cd.term_id = {1} and cd.course_code = '{2}' group by cd.id, l.short_name, cd.class", currentDep, termID, record.CourseCode));
                foreach (DataRow dr2 in dtCd.Rows)
                {
                    CourseDetail courseDe = new CourseDetail();
                    courseDe.CdID = Convert.ToInt32(dr2["id"]);
                    courseDe.LecturerShort = dr2["short_name"].ToString();
                    courseDe.Classname = dr2["class"].ToString();
                    courseDe.StudentNum = Convert.ToInt32(dr2["student_num"]);
                    record.CouresDetailGroup.Add(courseDe);
                }

                list.Add(record);
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