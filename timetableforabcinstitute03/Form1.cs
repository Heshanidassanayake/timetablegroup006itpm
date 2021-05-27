using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timetableforabcinstitute03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            lblTitle.Text = "Student Groups";
            this.PnlFormLoader.Controls.Clear();
            Form2 Form2_vrb = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form2_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form2_vrb);
            Form2_vrb.Show();




        }

        private void btnstudentgroup_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Student Groups";
            this.PnlFormLoader.Controls.Clear();
            Form2 Form2_vrb = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form2_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form2_vrb);
            Form2_vrb.Show();
        }

        private void btnlecturer_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Lecturer";
            this.PnlFormLoader.Controls.Clear();
            Form3 Form3_vrb = new Form3() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form3_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form3_vrb);
            Form3_vrb.Show();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Subject";
            this.PnlFormLoader.Controls.Clear();
            Form4 Form4_vrb = new Form4() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form4_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form4_vrb);
            Form4_vrb.Show();
        }

        private void btnsession_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Session";
            this.PnlFormLoader.Controls.Clear();
            Form5 Form5_vrb = new Form5() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form5_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form5_vrb);
            Form5_vrb.Show();
        }

        private void btnworkingdaysandhours_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Working Days and Hours";
            this.PnlFormLoader.Controls.Clear();
            Form6 Form6_vrb = new Form6() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form6_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form6_vrb);
            Form6_vrb.Show();
        }

        private void btnlocation_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Location";
            this.PnlFormLoader.Controls.Clear();
            Form7 Form7_vrb = new Form7() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form7_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form7_vrb);
            Form7_vrb.Show();
        }

        private void btntags_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Tag";
            this.PnlFormLoader.Controls.Clear();
            Form8 Form8_vrb = new Form8() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form8_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form8_vrb);
            Form8_vrb.Show();
        }

        private void btnstatistic_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Statistic";
            this.PnlFormLoader.Controls.Clear();
            Form9 Form9_vrb = new Form9() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form9_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form9_vrb);
            Form9_vrb.Show();
        }

        private void btngeneratetimeslot_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Generate Time Slot";
            this.PnlFormLoader.Controls.Clear();
            Form10 Form10_vrb = new Form10() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form10_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form10_vrb);
            Form10_vrb.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsessionandnotavailabletimeallocation_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Sessions and Not Available Time Allocations";
            this.PnlFormLoader.Controls.Clear();
            Form11 Form11_vrb = new Form11() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form11_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form11_vrb);
            Form11_vrb.Show();
        }

        private void btnmanagesessionrooms_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Session Rooms";
            this.PnlFormLoader.Controls.Clear();
            Form12 Form12_vrb = new Form12() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form12_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form12_vrb);
            Form12_vrb.Show();
        }

        private void btnmanagenotavailabletime_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Not Available Time";
            this.PnlFormLoader.Controls.Clear();
            Form13 Form13_vrb = new Form13() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form13_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form13_vrb);
            Form13_vrb.Show();
        }

        private void btnmanageaddsession_Click(object sender, EventArgs e)
        {
           /* lblTitle.Text = "Manage Add Session";
            this.PnlFormLoader.Controls.Clear();
            Form14 Form14_vrb = new Form14() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form14_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form14_vrb);
            Form14_vrb.Show();*/
        }

        private void btngeneratetimetable_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Time Tables";
            this.PnlFormLoader.Controls.Clear();
            Form15 Form15_vrb = new Form15() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Form15_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(Form15_vrb);
            Form15_vrb.Show();
        }

        private void PnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
