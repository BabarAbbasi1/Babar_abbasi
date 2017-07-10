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
    public partial class Records : Form
    {
        Connection mc = new Connection();
        public Records()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void Records_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select Std_Id from Std_Tbl", mc.conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            mc.conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Std_Tbl",mc.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("There is no data");
            }
            mc.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Std_Tbl where Std_Id ='" + comboBox4.SelectedItem+ "'", mc.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("There is no data");
            }
            mc.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mc.conn.Open();
            SqlCommand cmd = new SqlCommand("Select Std_Id,Name,Fee,PaidFee,RemFee from Std_Tbl where Std_Id ='" + comboBox4.SelectedItem + "'", mc.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("There is no data");
            }
            mc.conn.Close();

        }
    }
}
