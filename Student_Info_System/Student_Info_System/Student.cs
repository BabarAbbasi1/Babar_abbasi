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
    public partial class Student : Form
    {
        Connection mc = new Connection();
        public Student()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void Student_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Std_Id from Std_Tbl where status= '" + "InActive" + "'", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["Std_Id"]);
                }
                
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Std_Tbl where Std_Id= '" + comboBox4.SelectedItem + "'", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr["Name"].ToString();
                    textBox1.Text = dr["Surname"].ToString();
                    textBox3.Text = dr["Email"].ToString();
                    textBox7.Text = dr["ContactNo"].ToString();
                    textBox4.Text = dr["Fee"].ToString();
                    textBox8.Text = dr["Course"].ToString();
                    textBox5.Text = dr["Address"].ToString();
                    textBox10.Text = dr["Teacher"].ToString();
                    textBox6.Text = dr["Department"].ToString();
                    comboBox2.SelectedItem = dr["status"].ToString();
                    textBox9.Text = dr["Year"].ToString();
               }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Update Std_Tbl Set status ='" + comboBox2.SelectedItem + "' where Std_Id ='" + comboBox4.Text + "'", mc.conn);
                
                cmd.ExecuteNonQuery();
                
                mc.conn.Close();
                DialogResult di = MessageBox.Show("Student Updated Successfully...!!");
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
    }
}
