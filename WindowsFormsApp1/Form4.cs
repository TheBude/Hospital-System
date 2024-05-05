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
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into userTab values (@ID,@Name,@Age,@lavozimi,@bulim_raqami)", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@lavozimi", textBox4.Text);
            cmd.Parameters.AddWithValue("@bulim_raqami", textBox5.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Muvfoqiyatli Qo'shildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update userTab set Name=@Name, Age=@Age, lavozimi=@lavozimi, bulim_raqami= @bulim_raqami where ID = @ID  ", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@lavozimi", textBox4.Text);
            cmd.Parameters.AddWithValue("@bulim_raqami", textBox5.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Muvfoqiyatli Yangilandi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete userTab where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Muvfoqiyatli O'chirildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            DataTable dt = new DataTable();

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                int idValue;
                if (int.TryParse(textBox1.Text, out idValue))
                {
                    SqlCommand cmd = new SqlCommand("Select * from userTab where ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", idValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!String.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 1)
            {
                string searchPattern = textBox2.Text.Substring(0, 1) + "%";
                SqlCommand cmd = new SqlCommand("Select * from userTab where Name LIKE @NamePattern", con);
                cmd.Parameters.AddWithValue("@NamePattern", searchPattern);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userTab", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}
