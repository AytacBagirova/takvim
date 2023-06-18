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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace takvim2
{
    public partial class EventForm : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=WIN-IKG94OT125D\\SQLEXPRESS; Initial Catalog=event; Integrated Security=TRUE");

        public EventForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO event ([date], [event]) VALUES (@date, @event)", connection);
                connection.Open();

                // Parametreleri kullanarak SQL sorgusunu parametrelerle birlikte güvenli hale getirin
                command.Parameters.AddWithValue("@date", txdate.Text);
                command.Parameters.AddWithValue("@event", txevent.Text);

                command.ExecuteNonQuery();
                connection.Close();


                MessageBox.Show("Kayıt başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            //lets call the static variables we declare
            txdate.Text =Form3.static_month+"/"+ UserControlDays.static_day+"/"+Form3.static_year;
        }
    }
}
