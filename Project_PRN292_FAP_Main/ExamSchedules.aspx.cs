using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class ExamSchedules : System.Web.UI.Page
    {
        Student onlineStudent;

        protected void Page_Load(object sender, EventArgs e)
        {
            IsUserLogedIn();
            onlineStudent = (Student)Session["OnlineStudent"];
            btnStudent.Text = onlineStudent.StudentShortName.ToLower();
            if (!IsPostBack)
            {
                SetUpGridView();
                SetDataForGridView();
            }

        }

        public void SetDataForGridView()
        {
            int count = -1;
            List<Exam> examList = DataAccess.getAllExamSchedulesListByStudentCode(onlineStudent.StudentCode);
            gvExamList.DataSource = examList;
            gvExamList.DataBind();
            count = examList.Count;
            if (count == 0) lbNothing.Text = "No displayed any item(s)";
            else lbNothing.Text = "Displayd " + count + " item(s)";
        }

        public void SetUpGridView()
        {
            gvExamList.AutoGenerateColumns = false;
            gvExamList.Columns.Clear();
            gvExamList.Columns.Add(new BoundField() { HeaderText = "NO", DataField = "IDName" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "SUBJECT CODE", DataField = "CourseCode" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "SUBJECT NAME", DataField = "CourseExam" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "DATE", DataField = "DateExamFormat" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "ROOM NO", DataField = "RoomNoExam" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "TIME", DataField = "TimeExam" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "EXAM FORM", DataField = "FormExam" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "EXAM", DataField = "NameExam" });
            gvExamList.Columns.Add(new BoundField() { HeaderText = "DATE OF PUBLICATION", DataField = "PublicDateExamFormat" });
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
            Response.Redirect(string.Format("Home.aspx"));
        }
    }
}