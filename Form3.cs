using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takvim2
{
    public partial class Form3 : Form
    {
        int month, year;
        // lets create a static variable that we can pass to another from for month and year
        public static int static_month, static_year;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displaDays();
        }
        private void displaDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname+ " " + year;

            static_month = month;
            static_year = year;
            // lets get the first day of the month
            
            DateTime startofthemonth = new DateTime(year,month,1);
            //gwt the count of days of the month
            int days = DateTime.DaysInMonth (year,month);
            //convert the startofthemonth ti integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));
            //first lets create a blank usercontrol
            for (int i=1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            //now lets create usercontrol for days
            for( int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            //clear container
            daycontainer.Controls.Clear();
            //decrement month to go to previous month

            month--;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            //DateTime now = DateTime.Now;
            // lets get the first day of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            //gwt the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            //convert the startofthemonth ti integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));
            //first lets create a blank usercontrol
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            //now lets create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {    //clear container
            daycontainer.Controls.Clear();
            //increment month to go to next mont
            month++;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;
            //DateTime now = DateTime.Now;
            // lets get the first day of the month
            DateTime startofthemonth = new DateTime(year, month, 1);
            //gwt the count of days of the month
            int days = DateTime.DaysInMonth(year, month);
            //convert the startofthemonth ti integer
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));
            //first lets create a blank usercontrol
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }
            //now lets create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }
    }
}
