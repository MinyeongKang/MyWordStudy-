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

    

    public partial class Form1 : Form
    {

        MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; " +
        "Database=sober; Uid=root; Pwd=0000");
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(900, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")  // 텍스트박스에 아무것도 입력안했을때 메시지 출력
                MessageBox.Show("아이디 또는 비밀번호를 입력하세요", "Warning");
            else     // 텍스트 박스에 이름을 입력했을때 label2에 출력하는 else문
                //label3.Text = textBox1.Text + "님! 안녕하세요!";
                CheckID_PW();


           
        }

        private void CheckID_PW()
        {
            string id = textBox1.Text;
            string password = textBox2.Text;

            // Query the database to check if the entered ID and password match a record
            string query = string.Format("SELECT * FROM sober.restarant WHERE id = '{0}' AND pwd = '{1}'", id, password);
            MySqlConnection myCon = new MySqlConnection("Server=127.0.0.1; " +
                "Database=sober; Uid=root; Pwd=0000");
            MySqlCommand cmd = new MySqlCommand(query, myCon);

            myCon.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                // The user ID and password match a record in the database, show the next form
                this.Hide();
                Form3 newform3 = new Form3();
                newform3.Size = new System.Drawing.Size(1500, 1200);
                newform3.StartPosition = FormStartPosition.CenterScreen;

                newform3.ShowDialog();


            }
            else
            {
                // The user ID and password do not match a record in the database, show an error message
                MessageBox.Show("ID 또는 Password가 올바르지 않습니다.", "Error");
            }

            myCon.Close();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newform2 = new Form2();
            newform2.Size = new System.Drawing.Size(900, 800);
            newform2.StartPosition = FormStartPosition.CenterScreen;


            newform2.ShowDialog();
        }

    }
}
