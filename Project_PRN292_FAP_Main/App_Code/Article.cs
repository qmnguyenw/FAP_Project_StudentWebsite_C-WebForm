using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PRN292_FAP
{
    public class Article
    {
        int id;
        string title;
        string content;
        string authorName;
        DateTime uploadTime;
        string uploadTimeFormat;

        public Article()
        {

        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public string AuthorName
        {
            get
            {
                return authorName;
            }

            set
            {
                authorName = value;
            }
        }

        public DateTime UploadTime
        {
            get
            {
                return uploadTime;
            }

            set
            {
                uploadTime = value;
                uploadTimeFormat = string.Format("{0:dd/MM/yy hh:mm}",uploadTime);
            }
        }

        public string UploadTimeFormat
        {
            get
            {
                return uploadTimeFormat;
            }

            set
            {
                uploadTimeFormat = value;
            }
        }
    }
}