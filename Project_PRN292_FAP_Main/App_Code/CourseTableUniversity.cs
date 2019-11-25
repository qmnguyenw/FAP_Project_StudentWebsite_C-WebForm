using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class CourseTableUniversity
    {
        string courseCode;
        string courseName;
        List<string> teachers;
        List<CourseDetail> couresDetailGroup;

        public CourseTableUniversity()
        {

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

        public List<string> Teachers
        {
            get
            {
                return teachers;
            }

            set
            {
                teachers = value;
            }
        }

        public List<CourseDetail> CouresDetailGroup
        {
            get
            {
                return couresDetailGroup;
            }

            set
            {
                couresDetailGroup = value;
            }
        }
    }
}