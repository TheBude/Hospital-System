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

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=rentcar;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into userTab2 values (@ID,@Ism,@Yoshi,@Tashxis,@Kasalik_Tarixi)", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Ism", textBox2.Text);
            cmd.Parameters.AddWithValue("@Yoshi", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Tashxis", textBox4.Text);
            cmd.Parameters.AddWithValue("@Kasalik_Tarixi", textBox5.Text);
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
            SqlCommand cmd = new SqlCommand("Update userTab2 set Ism=@Ism, Yoshi=@Yoshi, Tashxis=@Tashxis, Kasalik_Tarixi= @Kasalik_Tarixi where ID = @ID ", con);

            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Ism", textBox2.Text);
            cmd.Parameters.AddWithValue("@Yoshi", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Tashxis", textBox4.Text);
            cmd.Parameters.AddWithValue("@Kasalik_Tarixi", textBox5.Text);
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
            SqlCommand cmd = new SqlCommand("Delete userTab2 where ID=@ID", con);
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

            // ID raqamiga qarab qidirish
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                int idValue;
                if (int.TryParse(textBox1.Text, out idValue))
                {
                    SqlCommand cmd = new SqlCommand("Select * from userTab2 where ID=@ID", con);
                    cmd.Parameters.AddWithValue("@ID", idValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Ismga qarab qidirish (case-sensitive)
            else if (!String.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 3)
            {
                // Ismdagi birinchi, ikkinchi va uchinchi harflarni olish
                string searchPattern = textBox2.Text.Substring(0, 3) + "%";
                SqlCommand cmd = new SqlCommand("Select * from userTab2 where Ism LIKE @IsmPattern", con);
                cmd.Parameters.AddWithValue("@IsmPattern", searchPattern);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            else
            {
                MessageBox.Show("Please enter at least three letters of the Name.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            // Natijani DataGridView'ga o'rnatish
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No records found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
