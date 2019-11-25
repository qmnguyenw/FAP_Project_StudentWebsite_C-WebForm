using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class Timeable : System.Web.UI.Page
    {
        public Cell[,] cells = new Cell[8,7];
        Student onlineStudent;
        void loadWeekInfo()
        {
            string code = onlineStudent.StudentCode;
            DateTime selectedMonday = DateTime.Parse(cbbWeek.SelectedValue);
            DateTime sunday = selectedMonday.AddDays(6);
            for (int i = 0; i < 8; i++)
            {
                int j = 0;
                for (DateTime dt = selectedMonday; dt <= sunday; dt = dt.AddDays(1))
                {
                    string curDate = string.Format("{0:yyyy/MM/dd}", dt);
                    string sql = string.Format(@"select c.course_code,
	                                    case when a.attendance_status = 0 then 'absent'
	                                    else case when a.attendance_status = 1 then 'present'
	                                    else 'Not yet' end end as status
                                        from Attendances a, LectureDetail l, CourseDetail c
                                        where a.lecture_detail_id = l.id and l.course_detail_id = c.id and a.student_code like '{0}'
                                        and l.study_date = '{1}' and l.slot_no = {2}",code,curDate,(i+1));
                    DataTable dtable = DataAccess.GetDataBySql(sql);
                    Cell cell = new Cell();
                    Cell temp = new Cell();
                    bool isEmpty = true;
                    foreach (DataRow dr in dtable.Rows)
                    {
                        temp = new Cell();
                        temp.CourseCode = dr["course_code"].ToString() + "";
                        temp.AttendStatus = dr["status"].ToString();
                        isEmpty = false;
                    }
                    
                    if (isEmpty)
                    {
                        cell.IsEmpty = true;
                    }else
                    {
                        cell = temp;
                        cell.IsEmpty = false;
                    }
                    cells[i,j] = cell;
                    j++;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["OnlineStudentCode"] = "he130069";
            //Session["IsUserLogIn"] = true;
            IsUserLogedIn();
            onlineStudent = (Student)Session["onlineStudent"];
            btnStudent.Text = onlineStudent.StudentShortName.ToLower();
            ctl00_mainContent_lblStudent.Text = string.Format("{0} ({1})",onlineStudent.StudentShortName,onlineStudent.StudentName);
            absentShort.Text = attendShort.Text = onlineStudent.StudentShortName;
            if (!IsPostBack)
            {
                SetCbbWeek();
                SetRpWeekDay();
            }
            loadWeekInfo();
        }

        void SetCbbWeek()
        {
            cbbWeek.DataTextField = "DisplayStr";
            cbbWeek.DataValueField = "Monday";
            List<Week> weeks = FetchWeeks(DateTime.Now.Year);
            cbbWeek.DataSource = weeks;
            cbbWeek.DataBind();
            cbbWeek.SelectedValue = string.Format("{0:yyyy/MM/dd}", GetCurrentMonday(DateTime.Now));
        }

        void SetRpWeekDay()
        {
            DateTime selectedMonday = DateTime.Parse(cbbWeek.SelectedValue);
            rpWeekday.DataSource = GetWeekDays(selectedMonday);
            rpWeekday.DataBind();
        }

        DateTime GetCurrentMonday(DateTime current)
        {
            DateTime monday = current.AddDays(1 - (int)current.DayOfWeek);
            return monday;
        }

        public List<string> GetWeekDays(DateTime current)
        {
            DateTime monday = current.AddDays(1 - (int)current.DayOfWeek);
            DateTime sunday = monday.AddDays(6);
            List<string> weekdays = new List<string>();
            for (DateTime i = monday; i <= sunday; i = i.AddDays(1))
            {
                weekdays.Add(string.Format("{0:dd/MM}", i));
            }
            return weekdays;
        }

        public List<Week> FetchWeeks(int year)
        {

            DateTime start = new DateTime(year, 1, 1);
            List<Week> weeks = new List<Week>();
            DateTime monday = start.AddDays(1 - (int)start.DayOfWeek);
            DateTime sunday = monday.AddDays(6);
            while (sunday.Year == year)
            {
                weeks.Add(new Week(string.Format("{0:yyyy/MM/dd}", monday), string.Format("{0:dd/MM} To {1:dd/MM}", monday, sunday)));
                monday = sunday.AddDays(1);
                sunday = monday.AddDays(6);
            }
            return weeks;
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

        private void IsUserLogedIn()
        {
            if (Session["IsUserLogIn"] == null || !Convert.ToBoolean(Session["IsUserLogIn"]))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void linkAttendance_Click(object sender, EventArgs e)
        {
            Response.Redirect("Attendance.aspx");
        }

        protected void cbbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRpWeekDay();
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetail.aspx");
        }
    }
}