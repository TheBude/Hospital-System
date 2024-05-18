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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-RJJLU7JV\SQLEXPRESS;Initial Catalog=fudbol;Integrated Security=True;Encrypt=False");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string foydalanuvchiNomi, parol;

            foydalanuvchiNomi = textBox1.Text;
            parol = textBox2.Text;

            try
            {
                string surov = "SELECT * FROM Login_new WHERE username = '"+textBox1.Text+"' AND password = '"+textBox2.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(surov, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    foydalanuvchiNomi = textBox1.Text;
                    parol = textBox2.Text;

                    MessageBox.Show("Muvfoqiyatli Kirildi!", "Yaxshi" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xatolik, iltimos to'g'ri kiriting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Serverdan Xatolik" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
