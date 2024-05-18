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
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO oyinchi (id_fudbolchi, ism, familiya, komanda, millat, yoshi, pozitsiya) VALUES (@id_fudbolchi, @ism, @familiya, @komanda, @millat, @yoshi, @pozitsiya)", con);

                cmd.Parameters.AddWithValue("@id_fudbolchi", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@ism", textBox2.Text);
                cmd.Parameters.AddWithValue("@familiya", textBox3.Text);
                cmd.Parameters.AddWithValue("@komanda", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@millat", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@yoshi", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@pozitsiya", comboBox2.SelectedItem);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Muvoffaqiyatli qo'shildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmg = new SqlCommand("Select * from oyinchi", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmg);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update oyinchi set yoshi=@yoshi, ism=@ism, familiya= @familiya, komanda=@komanda, millat=@millat, pozitsiya=@pozitsiya where id_fudbolchi=@id_fudbolchi", con);

                cmd.Parameters.AddWithValue("@id_fudbolchi", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@ism", textBox2.Text);
                cmd.Parameters.AddWithValue("@familiya", textBox3.Text);
                cmd.Parameters.AddWithValue("@komanda", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@millat", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@yoshi", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@pozitsiya", comboBox2.SelectedItem);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Muvoffaqiyatli Yangilandi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmg = new SqlCommand("Select * from oyinchi", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmg);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xatolik: " + ex.Message, "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete oyinchi where id_fudbolchi=@id_fudbolchi", con);
            cmd.Parameters.AddWithValue("@id_fudbolchi", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("Muvfoqiyatli O'chirildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlCommand cmg = new SqlCommand("Select * from oyinchi", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmg);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
            con.Open();
            DataTable dt = new DataTable();

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                int idValue;
                if (int.TryParse(textBox1.Text, out idValue))
                {
                    SqlCommand cmd = new SqlCommand("Select * from oyinchi where id_fudbolchi=@id_fudbolchi", con);
                    cmd.Parameters.AddWithValue("@id_fudbolchi", idValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!String.IsNullOrEmpty(textBox2.Text))
            {
                string searchPattern = textBox2.Text.Substring(0, 1) + "%";
                SqlCommand cmd = new SqlCommand("Select * from oyinchi where ism LIKE @ismPattern", con);
                cmd.Parameters.AddWithValue("@ismPattern", searchPattern);
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
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmg = new SqlCommand("Select * from oyinchi", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmg);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_fudbolchi"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["familiya"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ism"].FormattedValue.ToString();
                    comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["pozitsiya"].FormattedValue.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["yoshi"].FormattedValue.ToString();
                    comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["millat"].FormattedValue.ToString();
                    comboBox3.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["komanda"].FormattedValue.ToString();

                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
