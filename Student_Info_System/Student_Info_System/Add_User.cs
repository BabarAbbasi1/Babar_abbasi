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
    public partial class Add_User : Form
    {
        Connection mc = new Connection();
        public Add_User()
        {
            InitializeComponent();
            mc.conn.ConnectionString = @"Data Source=DESKTOP-7C9BRO3\SQLEXPRESS;Initial Catalog=SIMS;Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Add_User_Load(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();
                int c = 0;

                SqlCommand cmd = new SqlCommand("select count (UserID) from Login", mc.conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = Convert.ToInt32(dr[0]);
                    c++;

                }

                textBox3.Text = c.ToString();
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
            if (textBox2.Text != textBox4.Text)
            {
                MessageBox.Show("Password does not match");
                textBox2.Clear();
                textBox4.Clear();
            }
            else
                try
                {
                    mc.conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Login([UserId],[Username],[Password]) values (@UserId,@Username,@Password)", mc.conn);
                    cmd.Parameters.AddWithValue("@UserID", Convert.ToInt16(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.ExecuteNonQuery();

                    mc.conn.Close();

                    DialogResult di = MessageBox.Show("User added Successfully...!");
                    if (di == DialogResult.OK)
                    {
                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();
                    }
                    if (di == DialogResult.Cancel)
                    {
                        Application.Exit();
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
