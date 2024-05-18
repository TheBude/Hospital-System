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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmg = new SqlCommand("Select * from oyin", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmg);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO oyin (id_oyin, kamanda1, kamanda2, sana_oyin, hisob) VALUES (@id_oyin, @kamanda1, @kamanda2, @sana_oyin, @hisob)", con);

                cmd.Parameters.AddWithValue("@id_oyin", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@hisob", textBox2.Text);
                cmd.Parameters.AddWithValue("@kamanda2", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@kamanda1", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@sana_oyin", textBox4.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Muvoffaqiyatli qo'shildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmg = new SqlCommand("Select * from oyin", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmg);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
                SqlCommand cmd = new SqlCommand("Update oyin set kamanda1=@kamanda1, kamanda2=@kamanda2, sana_oyin= @sana_oyin, hisob=@hisob where id_oyin=@id_oyin", con);

                cmd.Parameters.AddWithValue("@id_oyin", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@hisob", textBox2.Text);
                cmd.Parameters.AddWithValue("@kamanda2", comboBox2.SelectedItem);
                cmd.Parameters.AddWithValue("@kamanda1", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@sana_oyin", textBox4.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Muvoffaqiyatli Yangilandi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmg = new SqlCommand("Select * from oyin", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmg);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            catch
            {
                MessageBox.Show("Notug'ri Kiritildi!", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete oyin where id_oyin=@id_oyin", con);
                cmd.Parameters.AddWithValue("@id_oyin", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Muvoffaqiyatli o'chirildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmg = new SqlCommand("Select * from oyin", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmg);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            catch 
            {
                MessageBox.Show("Notug'ri Kiritildi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    SqlCommand cmd = new SqlCommand("Select * from oyin where id_oyin=@id_oyin", con);
                    cmd.Parameters.AddWithValue("@id_oyin", idValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_oyin"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["sana_oyin"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["hisob"].FormattedValue.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["kamanda2"].FormattedValue.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["kamanda1"].FormattedValue.ToString();
            }
            else
            {
                MessageBox.Show("Olib Bo'lmadi!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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
    }
}
