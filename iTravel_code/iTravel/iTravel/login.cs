using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace iTravel
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();

            signin zhuce = new signin();
            zhuce.Show();

        }//显示注册界面
        private void buttonX1_Click(object sender, EventArgs e)
        {
            string User, Pwd; //用户名，密码
            bool flagshow = false;//用来标注登录名是否存在于数据库
            string strConnect = "Data Source=CAI-PC\\SQLEXPRESS;Initial Catalog=MyData1;Persist Security Info=True;User ID=sa;Password=******"; SqlConnection conConnection = new SqlConnection(strConnect); conConnection.Open();

            string cmd = "select 用户名,密码,email from 用户";

            SqlCommand com = new SqlCommand(cmd, conConnection); SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())//从数据库读取用户信息
            {

                User = reader["用户名"].ToString();

                Pwd = reader["密码"].ToString();

                if (User.Trim() == textBoxX1.Text & Pwd.Trim() == textBoxX2.Text)
                {

                    flagshow = true; //用户名存在于数据库，则为true

                }

            }

            reader.Close();

            conConnection.Close();

            if (flagshow == true)
            {
                showMainForm();//用户存在，返回登录界面

            }

            else
            {

                MessageBox.Show("用户不存在或密码错误！", "提示");

                return;

            }

        }

        private void showMainForm()
        {
            this.Close();
            Form1 main = new Form1();
            main.Show();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            signin zhuce = new signin( );
            zhuce.Show( );

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

        }
    }
}
