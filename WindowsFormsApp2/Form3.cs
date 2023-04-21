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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Width = 1100;

            // Clear the rows in dataGridView1
            dataGridView1.Rows.Clear();


            
            string selectQuery = "Select * from words";
            MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; " +
                "Database=sober; Uid=root; Pwd=0000");
            connection.Open();
            MySqlCommand cmd2 = new MySqlCommand(selectQuery, connection);
            MySqlDataReader table = cmd2.ExecuteReader();

            while (table.Read())
            {
                dataGridView1.Rows.Add(table["num"], table["word"], table["meaning"]);

            }
            connection.Close();


            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView2.Dock = DockStyle.Fill;
            //// Clear the rows in dataGridView1
            //dataGridView2.Rows.Clear();
            dataGridView2.Width = 1100;
         


            string selectQuery1 = "Select * from toadd";
            MySqlConnection connections = new MySqlConnection("Server=127.0.0.1; " +
    "Database=sober; Uid=root; Pwd=0000");
            connections.Open();

            MySqlCommand cmd4 = new MySqlCommand(selectQuery1, connections);
            MySqlDataReader table1 = cmd4.ExecuteReader();

            while (table1.Read())
            {
                dataGridView2.Rows.Add(table1["num"], table1["word"], table1["meaning"]);
            }
            connections.Close();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string cellText = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            //// Do something with the cell text
            //MessageBox.Show(cellText);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void delkey_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                string cellText = Convert.ToString(selectedRow.Cells["word"].Value);

                string deleteQuery = "DELETE FROM words WHERE word = @word";
                MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; " +
                    "Database=sober; Uid=root; Pwd=0000");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(deleteQuery, connection);
                cmd.Parameters.AddWithValue("@word", cellText);
                cmd.ExecuteNonQuery();
                connection.Close();

                // Refresh dataGridView1
                dataGridView1.Rows.Clear();
                string selectQuery = "SELECT * FROM words";
                connection.Open();
                MySqlCommand cmd2 = new MySqlCommand(selectQuery, connection);
                MySqlDataReader table = cmd2.ExecuteReader();
                while (table.Read())
                {
                    dataGridView1.Rows.Add(table["num"], table["word"], table["meaning"]);
                }
                connection.Close();
            }
        }

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //string cellText = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

        //    //// Do something with the cell text
        //    //MessageBox.Show(cellText);


        //private void addkey_Click(object sender, EventArgs e)
        //{

        //}


        private string cellText = "";
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row index is selected
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                StringBuilder rowText = new StringBuilder();

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    rowText.Append(selectedRow.Cells[i].Value.ToString());
                    rowText.Append("\t"); // Add a tab between each cell value
                }

                cellText = rowText.ToString().TrimEnd(); // Remove the trailing tab
            }

        }

        private void addkey_Click(object sender, EventArgs e)
        {
            // Set the name of the first column to "num"
            dataGridView2.Columns[0].Name = "num";

            // Set the name of the second column to "word"
            dataGridView2.Columns[1].Name = "word";

            // Set the name of the third column to "meaning"
            dataGridView2.Columns[2].Name = "meaning";

            if (dataGridView2.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.CurrentRow;
                string word = Convert.ToString(selectedRow.Cells["word"].Value);
                string meaning = Convert.ToString(selectedRow.Cells["meaning"].Value);

                string insertQuery = "INSERT INTO words (word, meaning) VALUES (@word, @meaning)";
                MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; " +
                    "Database=sober; Uid=root; Pwd=0000");
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@word", word);
                cmd.Parameters.AddWithValue("@meaning", meaning);
                cmd.ExecuteNonQuery();
                connection.Close();

                // Delete the selected row from dataGridView2
                dataGridView2.Rows.Remove(selectedRow);

                // Refresh dataGridView1
                //RefreshDataGridView1();
                string selectQuery2 = "Select * from words";
                MySqlConnection connection1 = new MySqlConnection("Server=127.0.0.1; " +
                    "Database=sober; Uid=root; Pwd=0000");
                connection1.Open();
                MySqlCommand cmd2 = new MySqlCommand(selectQuery2, connection1);
                MySqlDataReader table = cmd2.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (table.Read())
                {
                    dataGridView1.Rows.Add(table["num"], table["word"], table["meaning"]);

                }
                connection1.Close();

            }

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            
        }//
    }
}
