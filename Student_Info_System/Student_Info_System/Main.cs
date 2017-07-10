using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Info_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Student data = new Add_Student();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Course data = new Add_Course();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student data = new Student();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Teacher data = new Add_Teacher();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fee data = new Fee();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("You have logout successfully..!" , "See you next time..");
            if(di==DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Records data = new Records();
            data.MdiParent = this;
            data.Dock = DockStyle.Fill;
            data.FormBorderStyle = FormBorderStyle.None;
            data.Show();
        }
    }
}
