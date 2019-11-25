using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class Exam
    {
        int idExam;
        string courseCode;
        string courseExam;
        DateTime dateExam;
        string dateExamFormat;
        string roomNoExam;
        string timeExam;
        string formExam;
        string nameExam;
        DateTime publicDateExam;
        string publicDateExamFormat;

        public int IDName
        {
            get {
                return idExam;
            }
            set
            {
                idExam = value;
            }
        }

        public string CourseCode
        {
            get
            {
                return courseCode;
            }

            set
            {
                courseCode = value;
            }
        }

        public string CourseExam
        {
            get
            {
                return courseExam;
            }

            set
            {
                courseExam = value;
            }
        }

        public DateTime DateExam
        {
            get
            {
                return dateExam;
            }

            set
            {
                dateExam = value;
                dateExamFormat = string.Format("{0:dd/MM/yyyy}", dateExam);
            }
        }

        public string RoomNoExam
        {
            get
            {
                return roomNoExam;
            }

            set
            {
                roomNoExam = value;
            }
        }

        public string TimeExam
        {
            get
            {
                return timeExam;
            }

            set
            {
                timeExam = value;
            }
        }

        public string FormExam
        {
            get
            {
                return formExam;
            }

            set
            {
                formExam = value;
            }
        }

        public string NameExam
        {
            get
            {
                return nameExam;
            }

            set
            {
                nameExam = value;
            }
        }

        public DateTime PublicDateExam
        {
            get
            {
                return publicDateExam;
            }

            set
            {
                publicDateExam = value;
                publicDateExamFormat = string.Format("{0:dd/MM/yyyy}", publicDateExam);
            }
        }

        public string PublicDateExamFormat
        {
            get
            {
                return publicDateExamFormat;
            }

            set
            {
                publicDateExamFormat = value;
            }
        }

        public string DateExamFormat
        {
            get
            {
                return dateExamFormat;
            }

            set
            {
                dateExamFormat = value;
            }
        }

        public Exam() { }

        public Exam(int idExam, string courseCode, string courseExam, DateTime dateExam, string roomNoExam, string timeExam,
            string formExam, string nameExam, DateTime publicDateExam)
        {
            this.idExam = idExam;
            this.CourseCode = courseCode;
            this.CourseExam = courseExam;
            this.DateExam = dateExam;
            this.RoomNoExam = roomNoExam;
            this.TimeExam = timeExam;
            this.FormExam = formExam;
            this.NameExam = nameExam;
            this.PublicDateExam = publicDateExam;
        }
    }
}