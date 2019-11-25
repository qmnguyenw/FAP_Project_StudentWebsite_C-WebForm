using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Project_PRN292_FAP
{
    public class Student
    {

        string studentShortName;
        public string StudentCode
        {
            get;

            set;
        }

        public string StudentName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string No { get; set; }
        public string StudentShortName
        {
            get
            {
                studentShortName = GetStudentShortName();
                return studentShortName;
            }
            set
            {
                studentShortName = value;
            }
        }

        public Student()
        {

        }

        public Student(string code, string name, string mail, string Phone, string pass, string img)
        {
            StudentCode = code;
            StudentName = name;
            Email = mail;
            this.Phone = Phone;
            Password = pass;
            Image = img;
        }

        string GetStudentShortName()
        {
            string[] ele = StudentName.Trim().Split(new char[] { ' ' });
            int size = ele.Length;

            string remain = "";
            for (int i = 0; i < size - 1; i++)
            {
                remain += ele[i][0];
            }
            remain = remain.ToUpper();

            return convertToUnSign3(ele[size - 1] + remain+StudentCode.ToUpper());
        }

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

    }

    class StudentList
    {
        public static Student getStudentByStudent_Code(string code)
        {
            DataTable dt = DataAccess.getStudentByCode(code);
            foreach (DataRow dr in dt.Rows)
            {
                string student_code = dr["student_code"].ToString();
                string name = dr["student_name"].ToString();
                string email = dr["email"].ToString();
                string phone = dr["phone"].ToString();
                string pass = dr["password"].ToString();
                string img = "Image/" + dr["img"].ToString();
                return new Student(student_code, name, email, phone, pass, img);
            }
            return null;
        }
    }

}