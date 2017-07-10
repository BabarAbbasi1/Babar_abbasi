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
    public partial class Add_Student : Form
    {
        Connection mc = new Connection();
        public Add_Student()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }
        string gender = "";
        private void Add_Student_Load(object sender, EventArgs e)
        {
            {
                groupBox2.Enabled = false;
            }
            try
            {
                mc.conn.Open();
                int c = 0;

                SqlCommand cmd = new SqlCommand("select count (Std_Id) from Std_Tbl", mc.conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;

                }

                textBox1.Text = c.ToString();
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

            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Name from Course_Tbl ", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["Name"]);
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please Enter All Required Info");
            }
            else
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {

                gender = radioButton2.Text;
            }
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox10.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Please Enter All Required Info");
            }
            else
                try
                {

                    int a = 0;
                    mc.conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Std_Tbl([Std_Id],[Name],[Surname],[Gender],[Address],[ContactNo],[Email],[Department],[Course],[Fee],[PaidFee],[RemFee],[status],[Teacher],[Year]) values (@Std_Id,@Name,@Surname,@Gender,@Address,@ContactNo,@Email,@Department,@Course,@Fee,@PaidFee,@RemFee,@status,@Teacher,@Year)", mc.conn);
                    cmd.Parameters.AddWithValue("@Std_Id", Convert.ToInt16(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Surname", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Email", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Department", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Course", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Teacher", textBox10.Text);
                    cmd.Parameters.AddWithValue("@Fee", Convert.ToInt32(textBox7.Text));
                    cmd.Parameters.AddWithValue("@PaidFee", Convert.ToInt32(a));
                    cmd.Parameters.AddWithValue("@RemFee", Convert.ToInt32(textBox7.Text));
                    cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(textBox8.Text));
                    cmd.Parameters.AddWithValue("@status", textBox9.Text);
                    cmd.ExecuteNonQuery();

                    mc.conn.Close();

                    DialogResult di = MessageBox.Show("Record Inserted Successfully...!");
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Name from Teacher_Tbl where Subject ='" + comboBox2.SelectedItem + "'", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox10.Text = dr["Name"].ToString();
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

            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Fee from Course_Tbl where Name ='" + comboBox2.SelectedItem + "'", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox7.Text = dr["Fee"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
