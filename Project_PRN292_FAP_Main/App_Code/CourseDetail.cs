using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PRN292_FAP
{
    public class CourseDetail
    {
        int cdID;
        string courseCode;
        string courseName;
        string termName;
        string lecturer_short;
        string classname;
        DateTime startDate;
        DateTime endDate;
        string startDateFormat;
        int studentNum;
        int no;

        public int CdID
        {
            get
            {
                return cdID;
            }

            set
            {
                cdID = value;
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

        public string CourseName
        {
            get
            {
                return courseName;
            }

            set
            {
                courseName = value;
            }
        }

        public string TermName
        {
            get
            {
                return termName;
            }

            set
            {
                termName = value;
            }
        }

        public string LecturerShort
        {
            get
            {
                return lecturer_short;
            }

            set
            {
                lecturer_short = value;
            }
        }

        public string Classname
        {
            get
            {
                return classname;
            }

            set
            {
                classname = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
                startDateFormat = StartDateFormatF();
            }
        }

        public string StartDateFormatF()
        {
            return string.Format("{0:dd/MM/yyyy}", startDate);
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public string StartDateFormat
        {
            get
            {
                return startDateFormat;
            }

            set
            {
                startDateFormat = value;
            }
        }

        public int StudentNum
        {
            get
            {
                return studentNum;
            }

            set
            {
                studentNum = value;
            }
        }

        public int No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public string EndDateFormat()
        {
            return string.Format("{0:dd/MM/yyyy}", endDate);
        }

        public CourseDetail()
        {

        }

        public override string ToString()
        {
            return CourseCode + "-" + TermName + "-" + LecturerShort + "-" + Classname;
        }
        
    }

}
