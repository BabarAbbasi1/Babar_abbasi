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
    public partial class Form1 : Form
    {
        Connection mc = new Connection();
        public Form1()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter username and Password");
                return;
            }
            try
            {
                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Login", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Password"].ToString() == textBox2.Text && dr["Username"].ToString() == textBox1.Text)
                    {
                        DialogResult di = MessageBox.Show("You Have Login Successfully");
                        if (di == DialogResult.OK)
                        {
                            Main mn = new Main();
                            mn.Show();
                            this.Hide();
                        }
                            
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect ID PASSWORD ! ", "Try Again");
                        break;
                    }
                }
                mc.conn.Close();
                
            }

            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_User AA = new Add_User();
            AA.Show();
            this.Hide();
        }
    }
            }
