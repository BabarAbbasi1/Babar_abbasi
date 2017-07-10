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
    public partial class Add_Course : Form
    {
        Connection mc = new Connection();
        public Add_Course()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void Add_Course_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                int c = 0;

                SqlCommand cmd = new SqlCommand("select count (Code) from Course_Tbl", mc.conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;

                }

                textBox11.Text = c.ToString();
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

        private void button10_Click(object sender, EventArgs e)
        {
            string gender = "";
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Insert into Course_Tbl ([Code],[Name],[Fee],[TimeDuration]) values (@Code,@Name,@Fee,@TimeDuration)", mc.conn);
                cmd.Parameters.AddWithValue("@Code", Convert.ToInt32(textBox11.Text));
                cmd.Parameters.AddWithValue("@Name", textBox9.Text);
                cmd.Parameters.AddWithValue("@Fee", Convert.ToInt32(textBox10.Text));
                cmd.Parameters.AddWithValue("@TimeDuration", comboBox5.SelectedItem);
                cmd.ExecuteNonQuery();


                mc.conn.Close();

                DialogResult di = MessageBox.Show("Course Added Successfully....!!");
                if (di == DialogResult.OK)
                {
                    this.Hide();
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    }

