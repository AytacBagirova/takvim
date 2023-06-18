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
namespace takvim2
{
    public partial class Form1 : Form

    {
       public static SqlConnection connection = new SqlConnection("Data Source=WIN-IKG94OT125D\\SQLEXPRESS; Initial Catalog=takvim; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }
        char? bosluk = null;

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(bosluk);
            }
        }
        bool isThere;
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            connection.Open();
            SqlCommand command = new SqlCommand("Select *from takvim", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (username == reader["username"].ToString().TrimEnd() && password == reader["password"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }
                else
                {
                    isThere = false;
                }
            }
            connection.Close();
            if (isThere)
            {
                MessageBox.Show("Basariyla giris yaptiniz", "Program");
                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Giris yapamadiniz!", "Program");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
