using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PRN292_FAP
{
    public partial class Home : System.Web.UI.Page
    {
        Student onlineStudent;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            IsUserLogedIn();
            
            if (!IsPostBack)
            {
                loadRpNews();
                onlineStudent = (Student)Session["onlineStudent"];
                btnStudent.Text = onlineStudent.StudentShortName.ToLower();
            }
        }

        void loadRpNews()
        {
            rpNews.DataSource = getTop10LatestNews();
            rpNews.DataBind();
        }

        List<Article> getTop10LatestNews()
        {
            DataTable dt = DataAccess.GetDataBySql(string.Format("select top 10 * from Article order by upload_time desc"));
            List<Article> list = new List<Article>();
            foreach (DataRow dr in dt.Rows)
            {
                Article ar = new Article();
                ar.ID = Convert.ToInt32(dr["art_id"]);
                ar.Title = dr["title"].ToString();
                ar.Content = dr["content"].ToString();
                ar.AuthorName = dr["author_name"].ToString();
                ar.UploadTime = Convert.ToDateTime(dr["upload_time"]);
                list.Add(ar);
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
    }
}