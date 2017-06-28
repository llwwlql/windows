using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    public class NotePad
    {
        private String english;

        public String English
        {
            get { return english; }
            set { english = value; }
        }
        private String chinese;

        public String Chinese
        {
            get { return chinese; }
            set { chinese = value; }
        }

        public NotePad(String english,String chinese,int uuid){
            this.english = english;
            this.Chinese = chinese;
            this.uuid = uuid;
        }

        private int uuid;

        public int Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }

    }
}
