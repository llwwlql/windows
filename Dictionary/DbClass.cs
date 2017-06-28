using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Dictionary
{
    class DbClass
    {
        public static MySqlConnection mycon = null;
        private string constr = "server=127.0.0.1;User Id=root;password=root;Database=dictionary;CharSet=utf8;port=3306";

        public DbClass()
        {
            mycon = this.InstanceConn();
        }

        public MySqlConnection InstanceConn()
        {
            if (mycon == null)
            {
                mycon = new MySqlConnection(constr);
            }
            return mycon;
        }

        public string[] getResultSet(string english)
        {
            mycon.Open();
            String sqlStr = "select * from dic where english = '" + english+"'";
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            string[] sqlResult = new string[2];
            sqlResult[0] = "";
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    sqlResult[0] += reader.GetString(1);
                    sqlResult[1] += reader.GetString(2);
                    break;
                }
            }
            mycon.Close();
            return sqlResult;
        }
        public string[] getLikeResultSet(String english)
        {
            mycon.Open();
            String sqlStr = "select * from dic where english like '" + english + "%'";
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            string[] sqlResult = new string[6];
            for (int i = 1; i < 6; i++)
            {
                sqlResult[i] = "";
            }

            int j = 1;
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    sqlResult[j] += reader.GetString(1);
                    j++;
                    if (j > 5)
                        break;
                }
            }
            mycon.Close();
            return sqlResult;
        }
        public bool getInsert(string english,string chinese,int uuid) {
            mycon.Open();
            String sqlStr = "insert into notepad(english,chinese,uuid) values('"+ english +"','"+ chinese +"'," + uuid +")";
            String selectStr = "select 1 from notepad where english = '"+ english +"' and uuid = " + uuid;
            MySqlCommand selectCmd = new MySqlCommand(selectStr, mycon);
            MySqlDataReader reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {//单词本已存在该单词
                    mycon.Close();
                    return false;
                }
            }
            mycon.Close();
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            mycmd.ExecuteNonQuery();
            mycon.Close();
            return true;
        }
        public List<NotePad> getNotePad(int userId) {
            mycon.Open();
            List<NotePad> notePads = new List<NotePad>();
            String sqlStr = "select * from notepad where uuid = " + userId +" order by english";
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    String english = reader.GetString(2);
                    String chinese = reader.GetString(3);
                    NotePad notePad = new NotePad(english,chinese,userId);
                    notePads.Add(notePad);
                }
            }
            mycon.Close();
            return notePads;
        }
        public string[] login(String username,String password)
        {
            mycon.Open();
            String sqlStr = "select * from user where username=@uName and password=@uPwd";
            MySqlParameter[] ps = {
                    new MySqlParameter("uName" , username),
                    new MySqlParameter("uPwd" , password)};
            MySqlCommand mycmd = new MySqlCommand(sqlStr,mycon);
            mycmd.Parameters.AddRange(ps);
            MySqlDataReader reader = mycmd.ExecuteReader();
            string[] sqlResult = new string[2];
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    sqlResult[0] = reader.GetInt32(0).ToString();
                    sqlResult[1] = reader.GetString(2);
                    break;
                }
            }
            mycon.Close();
            return sqlResult;
        }

        public bool register(String username,String nickname,String password)
        {
            mycon.Open();
            String sqlStr = "insert into user(username,nickname,password) values('" + username + "','" + nickname + "','"+password + ")";
            String selectStr = "select 1 from user where username = '" + username + "'";
            MySqlCommand selectCmd = new MySqlCommand(selectStr, mycon);
            MySqlDataReader reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {//用户名已存在
                    mycon.Close();
                    return false;
                }
            }
            mycon.Close();
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand(sqlStr, mycon);
            mycmd.ExecuteNonQuery();
            mycon.Close();
            return true;
        }
        public int getUserId(String username)
        {
            mycon.Open();
            String selectStr = "select id from user where username = '" + username + "'";
            MySqlCommand selectCmd = new MySqlCommand(selectStr, mycon);
            MySqlDataReader reader = selectCmd.ExecuteReader();
            int userId = -1;
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    userId = reader.GetInt32(0);
                    break;
                }
            }
            mycon.Close();
            return userId;
        }

        public News getNews()
        {
            mycon.Open();
            String selectStr = "select * from news order by time desc limit 1";
            MySqlCommand selectCmd = new MySqlCommand(selectStr, mycon);
            MySqlDataReader reader = selectCmd.ExecuteReader();
            News news = null;
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    string title = reader.GetString(1);
                    string content = reader.GetString(2);
                    string time = reader.GetString(3);
                    string image = reader.GetString(4);
                    news = new News(title,content,image,time);
                    break;
                }
            }
            mycon.Close();
            return news;
        }
    }
}
