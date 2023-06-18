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
    public partial class Form2 : Form
    {
        SqlConnection connection = Form1.connection;
        public Form2()
        {
            InitializeComponent();
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
            if (textBox2.Text == "Ad")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Ad";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Soyad")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "")
            {
                textBox3.Text = "Soyad";
                textBox3.ForeColor = Color.Silver;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Sifre")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.PasswordChar = '*';
            }
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            char? none = null;
            if (textBox4.Text == "")
            {
                textBox4.Text = "Sifre";
                textBox4.ForeColor = Color.Silver;
                textBox4.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "TC kimlik no")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "TC kimlik no";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Telefon No")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Telefon No";
                textBox6.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Email"){
     
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }       

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Email";
                textBox7.ForeColor = Color.Silver;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Adres")
            {

                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Silver;
            }
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Adres";
                richTextBox1.ForeColor = Color.Black;
            }
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "KullaniciType";
                textBox8.ForeColor = Color.Silver;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "KullaniciType")
            {

                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }
        
        bool move;
        int mouse_x;
        int mouse_y;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO takvim (username, Ad, Soyad, Password, TcKimlikNo, Telefon, Email, Adres, KullaniciType) VALUES (@Username, @Ad, @Soyad, @Password, @TcKimlikNo, @Telefon, @Email, @Adres, @KullaniciType)", connection);

                // Parametreleri kullanarak SQL sorgusunu parametrelerle birlikte güvenli hale getirin
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Ad", textBox2.Text);
                command.Parameters.AddWithValue("@Soyad", textBox3.Text);
                command.Parameters.AddWithValue("@Password", textBox4.Text);
                command.Parameters.AddWithValue("@TcKimlikNo", textBox5.Text);
                command.Parameters.AddWithValue("@Telefon", textBox6.Text);
                command.Parameters.AddWithValue("@Email", textBox7.Text);
                command.Parameters.AddWithValue("@Adres", richTextBox1.Text);
                command.Parameters.AddWithValue("@KullaniciType", textBox8.Text);

                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Kayıt başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message);
            }

        }

        
    }
}

