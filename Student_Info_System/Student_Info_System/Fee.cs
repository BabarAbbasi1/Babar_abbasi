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
    public partial class Fee : Form
    {
        Connection mc = new Connection();
        public Fee()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void Fee_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Std_Id from Std_Tbl where status= '" + "Active" + "'", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["Std_Id"]);
                }
                mc
                .conn.Close();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "0";
            }
            else
            {
                int a = Convert.ToInt32(textBox4.Text);
                int b = Convert.ToInt32(textBox5.Text);
                int c = a - b;
                textBox6.Text = c.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Update Std_Tbl Set PaidFee ='" + textBox5.Text + "' where Std_Id ='" + comboBox4.Text + "'", mc.conn);
                SqlCommand cmd1 = new SqlCommand("Update Std_Tbl Set RemFee ='" + textBox6.Text + "' where Std_Id ='" + comboBox4.Text + "'", mc.conn);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                mc.conn.Close();
                DialogResult di = MessageBox.Show("Fee Added Successfully...!!");
                if(di==DialogResult.OK)
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

        private void button8_Click(object sender, EventArgs e)
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
                    textBox5.Text = dr["PaidFee"].ToString();
                    textBox6.Text = dr["RemFee"].ToString();


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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
