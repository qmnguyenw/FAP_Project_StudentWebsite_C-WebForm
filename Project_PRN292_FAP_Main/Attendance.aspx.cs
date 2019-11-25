using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{

    public partial class Attendance : System.Web.UI.Page
    {

        public string termID = null;
        public CourseDetail cda = null;
        Student onlineStudent;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            IsUserLogedIn();
            onlineStudent = (Student)Session["onlineStudent"];
            if (!IsPostBack)
            {
                btnStudent.Text = onlineStudent.StudentShortName.ToLower();
                lbStudent.Text = string.Format("{0} ({1})", onlineStudent.StudentShortName, onlineStudent.StudentName);
                termID = Request.QueryString["term"];
                if (termID == null)
                {
                    termID = DataAccess.GetDataBySql("Select top 1 * from Term order by end_date desc").Rows[0]["term_id"].ToString();
                }
                string cdaID = Request.QueryString["course"];
                if (cdaID == null)
                {
                    cda = GetCourseDetailByTermIDFirst(Convert.ToInt32(termID));
                }
                else
                {
                    cda = GetCourseDetailByTermIDAndCourseDetaiID(Convert.ToInt32(termID), Convert.ToInt32(cdaID));
                }
                LoadRpTerm();
                LoadRpCourse();
                LoadRpAttendance();
            }
        }

        CourseDetail GetCourseDetailByTermIDAndCourseDetaiID(int termID, int cda)
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select distinct cd.*,t.start_date,t.end_date,c.course_name from CourseDetail cd, Term t, Course c, CourseStudent cs where cd.term_id = {0} and cd.term_id = t.term_id and cd.course_code = c.course_code and cd.id = {1} and cs.course_detail_id = cd.id and cs.student_code like '{2}'", termID, cda,onlineStudent.StudentCode));
            List<Term> list = new List<Term>();
            foreach (DataRow dr in dt.Rows)
            {
                CourseDetail cdat = new CourseDetail();
                cdat.CdID = Convert.ToInt32(dr["id"]);
                cdat.CourseCode = dr["course_code"].ToString();
                cdat.LecturerShort = dr["lecturer_shortname"].ToString();
                cdat.Classname = dr["class"].ToString();
                cdat.CourseName = dr["course_name"].ToString();
                cdat.StartDate = Convert.ToDateTime(dr["start_date"]);
                cdat.EndDate = Convert.ToDateTime(dr["end_date"]);
                return cdat;
            }
            return null;
        }

        CourseDetail GetCourseDetailByTermIDFirst(int termID)
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select top 1 cd.*,t.start_date,t.end_date,c.course_name from CourseDetail cd, Term t, Course c, CourseStudent cs where cd.term_id = {0} and cd.term_id = t.term_id and cd.course_code = c.course_code and cs.course_detail_id = cd.id and cs.student_code like '{1}'", termID,onlineStudent.StudentCode));
            List<Term> list = new List<Term>();
            foreach (DataRow dr in dt.Rows)
            {
                CourseDetail cdat = new CourseDetail();
                cdat.CdID = Convert.ToInt32(dr["id"]);
                cdat.CourseCode = dr["course_code"].ToString();
                cdat.LecturerShort = dr["lecturer_shortname"].ToString();
                cdat.Classname = dr["class"].ToString();
                cdat.CourseName = dr["course_name"].ToString();
                cdat.StartDate = Convert.ToDateTime(dr["start_date"]);
                cdat.EndDate = Convert.ToDateTime(dr["end_date"]);
                return cdat;
            }
            return null;
        }

        List<CourseDetail> GetCourseDetailByTermID(int termID)
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select distinct cd.*,t.start_date,t.end_date,c.course_name from CourseDetail cd, Term t, Course c, CourseStudent cs where cd.term_id = {0} and cd.term_id = t.term_id and cd.course_code = c.course_code and cs.course_detail_id = cd.id and cs.student_code like '{1}'", termID,onlineStudent.StudentCode));
            List<CourseDetail> list = new List<CourseDetail>();
            foreach (DataRow dr in dt.Rows)
            {
                CourseDetail cdat = new CourseDetail();
                cdat.CdID = Convert.ToInt32(dr["id"]);
                cdat.CourseCode = dr["course_code"].ToString();
                cdat.LecturerShort = dr["lecturer_shortname"].ToString();
                cdat.Classname = dr["class"].ToString();
                cdat.CourseName = dr["course_name"].ToString();
                cdat.StartDate = Convert.ToDateTime(dr["start_date"]);
                cdat.EndDate = Convert.ToDateTime(dr["end_date"]);
                list.Add(cdat);
            }
            return list;
        }


        List<Term> GetAllTerm()
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select distinct t.* from Term t, CourseDetail cd, CourseStudent cs where t.term_id = cd.term_id and cd.id = cs.course_detail_id and cs.student_code like '{0}' order by end_date asc",onlineStudent.StudentCode));
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

        List<AttendanceDetail> GetAttendances()
        {

            List<AttendanceDetail> list = new List<AttendanceDetail>();
            if (cda == null) return list;
            DataTable dt = DataAccess.GetDataBySql(string.Format("select l.study_date, l.slot_no, c.lecturer_shortname, c.class," +
            " a.attendance_status, case when a.attendance_status = 0 then 'Absent' " +
            " else case when a.attendance_status = 1 then 'Present' " +
            " else 'Future' end end as status " +
            " from Attendances a, LectureDetail l, CourseDetail c " +
            " where a.lecture_detail_id = l.id and l.course_detail_id = c.id and a.student_code like '{0}' " +
            " and c.term_id = {1} and c.id = {2} order by l.study_date asc", onlineStudent.StudentCode, termID, cda.CdID));
            int countAbsent = 0;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                AttendanceDetail ad = new AttendanceDetail();
                ad.No = i;
                ad.Date = Convert.ToDateTime(dr["study_date"]);
                ad.Slot = Convert.ToInt32(dr["slot_no"]);
                ad.Lecturer = dr["lecturer_shortname"].ToString();
                ad.GroupName = dr["class"].ToString();
                ad.AttendanceStatus = dr["status"].ToString();
                if (dr["attendance_status"] != DBNull.Value && !Convert.ToBoolean(dr["attendance_status"]))
                {
                    countAbsent++;
                }
                list.Add(ad);
            }
            if (i == 0)
            {
                lbAbsentPer.Text = "ABSENT: 0% ABSENT SO FAR (0 ABSENT ON 0 TOTAL).";
            }
            else
            {
                lbAbsentPer.Text = string.Format("ABSENT: {0}% ABSENT SO FAR ({1} ABSENT ON {2} TOTAL).", ((int)((double)countAbsent) * 100 / i), countAbsent, i);
            }

            return list;
        }

        private void LoadRpTerm()
        {
            rpTerm.DataSource = GetAllTerm();
            rpTerm.DataBind();
        }

        private void LoadRpCourse()
        {
            rpCourse.DataSource = GetCourseDetailByTermID(Convert.ToInt32(termID));
            rpCourse.DataBind();
        }

        private void LoadRpAttendance()
        {
            rpAttendance.DataSource = GetAttendances();
            rpAttendance.DataBind();
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