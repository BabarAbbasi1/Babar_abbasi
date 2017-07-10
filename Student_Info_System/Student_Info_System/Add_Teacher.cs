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

 namespace Student_Info_System
{
    public partial class Add_Teacher : Form
    {
        Connection mc = new Connection();
        public Add_Teacher()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void Add_Teacher_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                int c = 0;
                SqlCommand cmd = new SqlCommand("Select count(id) from Teacher_Tbl", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;
                }
                textBox15.Text = c.ToString();
                mc.conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                mc.conn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Teacher_Tbl ([id],[Name],[Subject],[Qualification]) values (@id,@Name,@Subject,@Qualification)",mc.conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox15.Text));
                cmd.Parameters.AddWithValue("@Name", textBox12.Text);
                cmd.Parameters.AddWithValue("@Subject", textBox13.Text);
                cmd.Parameters.AddWithValue("@Qualification", textBox14.Text);
                cmd.ExecuteNonQuery();

                mc.conn.Close();
                DialogResult di = MessageBox.Show("Teacher Added Successfully...!!");
                if (di == DialogResult.OK)
                {
                    this.Hide();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                mc.conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
