using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class Term
    {
        int tID;
        string tName;
        DateTime start;
        DateTime end;



        public DateTime Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }


        public string TName
        {
            get
            {
                string fChar = tName[0].ToString().ToUpper();
                string remain = tName.ToLower().Substring(1);
                return fChar + remain;
            }

            set
            {
                tName = value;
            }
        }

        public int TID
        {
            get
            {
                return tID;
            }

            set
            {
                tID = value;
            }
        }

        public Term()
        {

        }
    }
    
}