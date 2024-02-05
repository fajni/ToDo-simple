
using System;

namespace Shared.Models
{
    public class Obligation
    {
        private int user_id;
        private int id;
        private string title;
        private DateTime date;
        private string note;

        public int GetSetUserId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public int GetSetId
        {
            get => id;
            set => id = value;
        }

        public string GetSetTitle
        {
            get => title;
            set => title = value;
        }

        public DateTime GetSetDate 
        {
            get => date; 
            set => date = value;
        }

        public string GetSetNote
        {
            get => note; 
            set => note = value;
        }

        public Obligation() { }

        public Obligation(int user_id, int id, string title, DateTime date, string note)
        {
            this.user_id = user_id;
            this.id = id;
            this.title = title;
            this.date = date;
            this.note = note;
        }

        public Obligation(int user_id, string title, DateTime date, string note)
        {
            this.user_id = user_id;
            this.title = title;
            this.date = date;
            this.note = note;
        }

        public override string ToString()
        {
            return "Obligation User Id: " + user_id + ", ID: " + id + ", Title: " + title + ", Date: " + date + ", Note: " + note;
        }
    }
}
