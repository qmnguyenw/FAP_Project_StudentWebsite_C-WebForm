using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class Week
    {
        string monday;
        string displayStr;

        public Week()
        {

        }

        public Week(string monday, string display)
        {
            this.monday = monday;
            this.displayStr = display;
        }

        public string Monday
        {
            get
            {
                return monday;
            }

            set
            {
                monday = value;
            }
        }

        public string DisplayStr
        {
            get
            {
                return displayStr;
            }

            set
            {
                displayStr = value;
            }
        }
    }

    public class Cell
    {
        string courseCode;
        string attendStatus;
        bool isEmpty;

        public Cell()
        {
            isEmpty = true;
            courseCode = null;
            attendStatus = null;
        }

        public Cell(string courseCode, string attendStatus, bool isEmpty)
        {
            this.courseCode = courseCode;
            this.attendStatus = attendStatus;
            this.isEmpty = isEmpty;
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

        public string AttendStatus
        {
            get
            {
                return attendStatus;
            }

            set
            {
                attendStatus = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return isEmpty;
            }

            set
            {
                isEmpty = value;
            }
        }
    }

}