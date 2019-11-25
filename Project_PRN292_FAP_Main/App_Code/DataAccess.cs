using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PRN292_FAP
{
    class DataAccess
    {
        public static SqlConnection GetConnection()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ToString();
            return new SqlConnection(ConnectionString);
        }

        public static DataTable GetDataBySql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds.Tables[0];
        }

        public static int PerformNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            cmd.Connection.Open();
            int res = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return res;
        }

        public static DataTable getStudentByCode(string code)
        {
            return GetDataBySql(string.Format("select * from Student where student_code like '{0}'", code));
        }

        public static DataTable getArtById(int id)
        {
            return GetDataBySql(string.Format("select * from Article where art_id like '{0}'", id));
        }

        public static Article getArticleByID(int idParam)
        {
            DataTable dt = DataAccess.getArtById(idParam);
            Article a = new Article();
            foreach (DataRow dr in dt.Rows)
            {
                a.ID = Convert.ToInt32(dr["art_id"]);
                a.Title = dr["title"].ToString();
                a.Content = dr["content"].ToString();
                a.AuthorName = dr["author_name"].ToString();
                a.UploadTime = Convert.ToDateTime(dr["upload_time"]);

            }
            return a;
        }

        public static DataTable Phong_getAccountbyCode(string code)
        {
            string sql = @"SELECT * FROM student WHERE student_code like @code";
            SqlCommand command = new SqlCommand(sql, GetConnection());

            SqlParameter param1 = new SqlParameter("@code", SqlDbType.NVarChar);
            param1.Value = code;
            command.Parameters.Add(param1);

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds.Tables[0];
        }


        public static DataTable GetAllExamSchedulesByStudentCode(string studentCode)
        {
            return GetDataBySql(@"SELECT dbo.Exam.*, dbo.Exam_Student.id AS es_id, dbo.Exam_Student.exam_id AS es_examid, dbo.Exam_Student.student_code AS student_code, dbo.Course.course_name
FROM     dbo.Course INNER JOIN
                  dbo.CourseDetail ON dbo.Course.course_code = dbo.CourseDetail.course_code INNER JOIN
                  dbo.CourseStudent ON dbo.CourseDetail.id = dbo.CourseStudent.course_detail_id INNER JOIN
                  dbo.Exam ON dbo.Course.course_code = dbo.Exam.course_code INNER JOIN
                  dbo.Exam_Student ON dbo.Exam.id = dbo.Exam_Student.exam_id INNER JOIN
                  dbo.Student ON dbo.CourseStudent.student_code = dbo.Student.student_code AND dbo.Exam_Student.student_code = dbo.Student.student_code
WHERE dbo.Student.student_code like '" + studentCode + "'");
        }

        public static DataTable GetAllExamSchedules()
        {
            return GetDataBySql(@"SELECT dbo.Exam.*, dbo.Exam_Student.id AS es_id, dbo.Exam_Student.exam_id AS es_examid, dbo.Exam_Student.student_code AS student_code, dbo.Course.course_name
FROM     dbo.Course INNER JOIN
                  dbo.CourseDetail ON dbo.Course.course_code = dbo.CourseDetail.course_code INNER JOIN
                  dbo.CourseStudent ON dbo.CourseDetail.id = dbo.CourseStudent.course_detail_id INNER JOIN
                  dbo.Exam ON dbo.Course.course_code = dbo.Exam.course_code INNER JOIN
                  dbo.Exam_Student ON dbo.Exam.id = dbo.Exam_Student.exam_id INNER JOIN
                  dbo.Student ON dbo.CourseStudent.student_code = dbo.Student.student_code AND dbo.Exam_Student.student_code = dbo.Student.student_code");
        }

        public static List<Exam> getAllExamSchedulesList()
        {
            DataTable dt = DataAccess.GetAllExamSchedules();
            List<Exam> examList = new List<Exam>();
            foreach (DataRow dr in dt.Rows)
            {
                int idExam = Convert.ToInt32(dr["id"]);
                string courseCode = dr["course_code"].ToString();
                string courseExam = dr["course_name"].ToString();
                DateTime dateExam;
                try
                {
                    dateExam = Convert.ToDateTime(dr["date"]);
                }
                catch (Exception e)
                {
                    dateExam = default(DateTime);
                }
                string roomNoExam = dr["room_no"].ToString();
                string timeExam = dr["time"].ToString();
                string formExam = dr["exam_form"].ToString();
                string nameExam = dr["exam_name"].ToString();
                DateTime publicDateExam;
                try
                {
                    publicDateExam = Convert.ToDateTime(dr["public_date"]);
                }
                catch (Exception e)
                {
                    publicDateExam = default(DateTime);
                }
                Exam exam = new Exam(idExam, courseCode, courseExam, dateExam, roomNoExam, timeExam, formExam, nameExam, publicDateExam);
                examList.Add(exam);
            }
            return examList;
        }

        public static List<Exam> getAllExamSchedulesListByStudentCode(string code)
        {
            DataTable dt = GetAllExamSchedulesByStudentCode(code);
            List<Exam> examList = new List<Exam>();
            int i=1;
            foreach (DataRow dr in dt.Rows)
            {
                int idExam = i;
                string courseCode = dr["course_code"].ToString();
                string courseExam = dr["course_name"].ToString();
                DateTime dateExam;
                try
                {
                    dateExam = Convert.ToDateTime(dr["date"]);
                }
                catch (Exception e)
                {
                    dateExam = default(DateTime);
                }
                string roomNoExam = dr["room_no"].ToString();
                string timeExam = dr["time"].ToString();
                string formExam = dr["exam_form"].ToString();
                string nameExam = dr["exam_name"].ToString();
                DateTime publicDateExam;
                try
                {
                    publicDateExam = Convert.ToDateTime(dr["public_date"]);
                }
                catch (Exception e)
                {
                    publicDateExam = default(DateTime);
                }
                Exam exam = new Exam(idExam, courseCode, courseExam, dateExam, roomNoExam, timeExam, formExam, nameExam, publicDateExam);
                examList.Add(exam);
                i++;
            }
            return examList;
        }

        public static DataTable Phong_getPhuHuynhInforbyCode(string code)
        {
            string sql = @"SELECT s.phone, p.parent_name, p.phone as PhuHuynhPhone, p.address  FROM Student s inner join Parent p on s.parent_id = p.parent_id  WHERE s.student_code like @code";
            SqlCommand command = new SqlCommand(sql, GetConnection());

            SqlParameter param1 = new SqlParameter("@code", SqlDbType.NVarChar);
            param1.Value = code;
            command.Parameters.Add(param1);

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds.Tables[0];
        }


        public static void Phong_UpdateInfor(PhuHuynh d, string code)
        {
            string sql = "update Student set phone = @studentPhone where student_code like @code update Parent set parent_name = @nameParent, phone = @parentphone, address = @add from Student s, Parent p where s.student_code like @code and s.parent_id = p.parent_id";


            SqlCommand command = new SqlCommand(sql, GetConnection());
            SqlParameter param1 = new SqlParameter("@studentPhone", SqlDbType.NVarChar);
            param1.Value = d.phone;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@code", SqlDbType.NVarChar);
            param2.Value = code;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@nameParent", SqlDbType.NVarChar);
            param3.Value = d.namePhuHuynh;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@parentphone", SqlDbType.NVarChar);
            param4.Value = d.phonePhuHuynh;
            command.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter("@add", SqlDbType.NVarChar);
            param5.Value = d.DiaChiPhuHuynh;
            command.Parameters.Add(param5);

            command.Connection.Open();
            int count = command.ExecuteNonQuery();
            command.Connection.Close();

        }


    }

}




