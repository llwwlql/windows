using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    class News
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        private string time;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public News(string title ,string content,string image,string time) {
            this.time = time;
            this.title = title;
            this.content = content;
            this.image = image;
        }
    }
}
