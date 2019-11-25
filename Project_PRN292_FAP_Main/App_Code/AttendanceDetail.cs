using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class AttendanceDetail
    {
        int no;
        DateTime date;
        string dateStr;
        int slot;
        string lecturer;
        string groupName;
        string attendanceStatus;

        public AttendanceDetail()
        {

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

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                dateStr = String.Format("{0:dddd dd/MM/yyyy}", date);
            }
        }

        public string DateStr
        {
            get
            {
                return dateStr;
            }

            set
            {
                dateStr = value;
            }
        }

        public int Slot
        {
            get
            {
                return slot;
            }

            set
            {
                slot = value;
            }
        }

        public string Lecturer
        {
            get
            {
                return lecturer;
            }

            set
            {
                lecturer = value;
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }

        public string AttendanceStatus
        {
            get
            {
                return attendanceStatus;
            }

            set
            {
                attendanceStatus = value;
            }
        }
    }
}