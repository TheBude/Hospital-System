using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userTab2", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            DataTable dt = new DataTable();

            if (!String.IsNullOrEmpty(textBox1.Text) && textBox1.Text.Length >= 1)
            {
                string searchPattern = textBox1.Text.Substring(0, 1) + "%";
                SqlCommand cmd = new SqlCommand("Select * from userTab2 where Ism LIKE @IsmPattern", con);
                cmd.Parameters.AddWithValue("@IsmPattern", searchPattern);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            else
            {
                MessageBox.Show("Iltimos, Qidirish uchun So'z Kiriting.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Bunaqa Ma'lumot Topilmadi.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }
    }
}
