using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; " +
        "Database=sober; Uid=root; Pwd=0000");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newform1 = new Form1();
            newform1.Size = new System.Drawing.Size(900, 800);
            newform1.StartPosition = FormStartPosition.CenterScreen;


            newform1.ShowDialog();
            SIgnUp_Save();
        }

        private void SIgnUp_Save()
        {
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("아이디를 입력해주세요");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Password를 입력해주세요");
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Password를 다시 입력해주세요");
                    return;
                }


                this.Cursor = Cursors.WaitCursor;
                try
                {
                    string mySql = string.Format("INSERT INTO sober.restarant (id, pwd) VALUES ('{0}','{1}');",
textBox1.Text, textBox2.Text);

                    MySqlConnection myCon = new MySqlConnection("Server=127.0.0.1; " +
                    "Database=sober; Uid=root; Pwd=0000");
                    myCon.Open();
                    var cmd = new MySqlCommand();
                    cmd.Connection = myCon;
                    cmd.CommandText = mySql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    //MessageBox.Show("저장되었습니다.", "확인 - 197");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "확인 201");
                    //MstbtnCancel();
                }
            }
        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
