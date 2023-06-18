using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takvim2
{
    public partial class UserControlDays : UserControl
    {
        //let us create another static variable for day;
        public static string static_day;

        public int Year { get; internal set; }
        public int Month { get; internal set; }

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            EventForm eventform = new EventForm();
            eventform.Show();
        }


    }
}
