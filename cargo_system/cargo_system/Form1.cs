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

namespace cargo_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Connection mc = new Connection();


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = false;
            button6.Visible = false;


            button12.Visible = false;
            button13.Visible = false;
            //button14.Visible = false;
            button15.Visible = false;

            panel1.Visible = true;
            panel2.Visible = true;

            demage_panel.Visible = false;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            track_panel.Visible = false;
            reorder_panel.Visible = false;

            gate_panel.Visible = false;



            accept_panel.Visible = false;


            username.Visible = false;
            pass.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            button9.Visible = false;
            button10.Visible = false;

            button7.Visible = true;
            button8.Visible = true;
                //Form1.MDIParent = this.panel1;


            try
            {
                mc.constring();

                mc.conn.Open();


                SqlCommand cmd = new SqlCommand("SELECT count (ID) from ware_house ", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    id = Convert.ToInt32((Dr[0])); id++;

                }

                textBox2.Text = "00" + id.ToString() + "-" + System.DateTime.Today.Year;


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

            //Cargo Order ID populate


            try
            {
                mc.constring();

                mc.conn.Open();


                SqlCommand cmd = new SqlCommand("SELECT count (O_ID) from Order_cargo ", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    id = Convert.ToInt32((Dr[0])); id++;

                }

                textBox6.Text = "00" + id.ToString() + "-" + System.DateTime.Today.Year;


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



            //// Papulate Un acceted Order

            try
            {


                mc.conn.Open();

                //AND Status='"+"Open"+"'"
                SqlCommand cmd = new SqlCommand("SELECT O_ID From Order_cargo where Acceptance='No'", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox5.Items.Add(Dr["O_ID"]);
                    comboBox7.Items.Add(Dr["O_ID"]);
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

            ////Gate Pass For Accepted Goods

            try
            {


                mc.conn.Open();

                //AND Status='"+"Open"+"'"
                SqlCommand cmd = new SqlCommand("SELECT O_ID From Order_cargo where Acceptance='yes'", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    comboBox9.Items.Add(Dr["O_ID"]);
                   
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
        int id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            view_panel.Visible = false;
            cargo_order_panel.Visible = true;
            ware_panel.Visible = false;
            track_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            button10.Visible = false;

            label1.Visible = true;
            label2.Visible = true;

            username.Visible = true;
            pass.Visible = true;
            button9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Visible = false;


            label1.Visible = true;
            label2.Visible = true;
            button8.Visible = true;

            username.Visible = true;
            pass.Visible = true;
            button10.Visible = true;

            button9.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button8.Visible = true;

            button12.Visible = false;
            button13.Visible = false;
            //button14.Visible = false;
            button15.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
       
            button5.Visible = false;
            button6.Visible = false;

            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            track_panel.Visible = false;
            accept_panel.Visible = false;
            demage_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            mc.constring();

            if (username.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }


            try
            {
               

                mc.conn.Open();

                //int pas = Convert.ToDecimal(pass.Text);

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();




                while (dr.Read())
                {


                    if (dr["Pass"].ToString() == pass.Text && dr["username"].ToString() == username.Text)
                    {
                     
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        button5.Visible = true;
                        button6.Visible = true;

                        ware_panel.Visible = true;


                        username.Visible = false;
                        pass.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        button7.Visible = false;
                        button9.Visible = false;
                        button10.Visible = false;

                        reorder_panel.Visible = false;
                        gate_panel.Visible = false;

                        pass.Text = "";
                        username.Text = "";


                       
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

        private void button10_Click(object sender, EventArgs e)
        {

            mc.constring();

            if (username.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }


            try
            {


                mc.conn.Open();

                //int pas = Convert.ToDecimal(pass.Text);

                SqlCommand cmd = new SqlCommand("SELECT * FROM ware_house", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();




                while (dr.Read())
                {


                    if (dr["pass"].ToString() == pass.Text && dr["ID"].ToString() == username.Text)
                    {

                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = false;
                        button4.Visible = true;
                        button5.Visible = false;
                        button6.Visible = false;


                        username.Visible = false;
                        pass.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                        button7.Visible = false;
                        button9.Visible = false;
                        button10.Visible = false;
                        button8.Visible = false;

                        accept_panel.Visible = true;

                        button12.Visible = true;
                        button13.Visible = true;
                        //button14.Visible = true;
                        button15.Visible = true;
                        reorder_panel.Visible = false;
                        gate_panel.Visible = false;


                        pass.Text = "";
                        username.Text = "";







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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            mc.constring();

            try
            {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("All filed Required Must Be Filled");
                }
                else
                {
                    //id = Convert.ToInt32(c_id.Text);

                    mc.conn.Open();

                    int qty = 50;

                    SqlCommand cmd = new SqlCommand("insert into ware_house([ID],[Place],[Supervisor_name],[Capacity],[Mobile],[quantity],[pass]) values (@ID,@Place,@Supervisor_name,@Capacity,@Mobile,@quantity,@pass)", mc.conn);

                    cmd.Parameters.AddWithValue("@ID",textBox2.Text);
                    cmd.Parameters.AddWithValue("@Place",comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@Supervisor_name", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Capacity",Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Mobile", Convert.ToInt32(textBox5.Text));
                    cmd.Parameters.AddWithValue("@quantity",qty);
                    cmd.Parameters.AddWithValue("@pass", Convert.ToInt32(textBox1.Text));
 

                    cmd.ExecuteNonQuery();


                    mc.conn.Close();

                    DialogResult rs = MessageBox.Show("WareHouse ADDED !");

                    if (rs == DialogResult.OK)
                    {
                        
                    ware_panel.Visible=false;

                    }

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

        private void button15_Click(object sender, EventArgs e)
        {
            accept_panel.Visible = true;

            view_panel.Visible = false;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            track_panel.Visible = false;
            demage_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view_panel.Visible = false;
            ware_panel.Visible = true;
            cargo_order_panel.Visible = false;
            track_panel.Visible = false;
            demage_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void cargo_order_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            mc.constring();

            try
            {
                if (textBox6.Text == "" || textBox7.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                {
                    MessageBox.Show("All filed Required Must Be Filled");
                }
                else
                {
                    //id = Convert.ToInt32(c_id.Text);

                    mc.conn.Open();

                    int qty = 50;

                    SqlCommand cmd = new SqlCommand("insert into Order_cargo([O_ID],[quantity],[warehouse],[Shifted_from],[shifted_to],[shifted_Date],[shifted_time],[Acceptance]) values (@O_ID,@quantity,@warehouse,@Shifted_from,@shifted_to,@shifted_Date,@shifted_time,@Acceptance)", mc.conn);

                    cmd.Parameters.AddWithValue("@O_ID", textBox6.Text);
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(textBox7.Text));
                    cmd.Parameters.AddWithValue("@warehouse", comboBox2.SelectedItem);
                    cmd.Parameters.AddWithValue("@Shifted_from", comboBox3.SelectedItem);
                    cmd.Parameters.AddWithValue("@shifted_to",comboBox4.SelectedItem);
                    cmd.Parameters.AddWithValue("@shifted_Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@shifted_time",System.DateTime.Today.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Acceptance","No");


                    cmd.ExecuteNonQuery();


                    mc.conn.Close();

                    DialogResult rs = MessageBox.Show("Cargo ADDED !");

                    if (rs == DialogResult.OK)
                    {

                        cargo_order_panel.Visible = false;

                    }

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

        private void button3_Click(object sender, EventArgs e)
        {
            view_panel.Visible = true;
            cargo_order_panel.Visible = false;
            ware_panel.Visible = false;
            track_panel.Visible = false;
            demage_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;

            mc.constring();

            try
            {

                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Order_cargo];", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                else
                    MessageBox.Show("There is no any data to show.");
                mc.conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            demage_panel.Visible = false;
            track_panel.Visible = true;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            mc.constring();

            try
            {

                mc.conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Order_cargo] where O_ID ='"+textBox8.Text+"';", mc.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                }
                else
                    MessageBox.Show("Invalid ID .");
                mc.conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            mc.constring();
            
            try
            {
                mc.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *  From Order_cargo where O_ID='" + comboBox5.Text + "'", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    //comboBox2.Items.Add(Dr["Approve"]);
                    textBox13.Text = Dr["O_ID"].ToString();
                    textBox11.Text = Dr["quantity"].ToString();
                    textBox9.Text = Dr["Shifted_from"].ToString();
                    textBox12.Text = Dr["shifted_to"].ToString();
                    textBox10.Text = Dr["shifted_Date"].ToString();
                    



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

        private void button22_Click(object sender, EventArgs e)
        {

            mc.constring();
            try
            {
                if (comboBox6.Text == "")
                {
                    MessageBox.Show("Select Approvence..");
                }
                else
                {
                    mc.conn.Open();


                    SqlCommand cmd = new SqlCommand("update Order_cargo set Acceptance ='" + comboBox6.Text + "' where O_ID='" + comboBox5.Text + "' ", mc.conn);

                    cmd.ExecuteNonQuery();

                    mc.conn.Close();

                    DialogResult dr = MessageBox.Show("Order Accepted..");

                    if (dr == DialogResult.OK)
                    {

                        textBox9.Text = "";
                        textBox10.Text = "";

                        textBox11.Text = "";

                        textBox12.Text = "";
                        textBox13.Text = "";
                        textBox10.Text = "";
                      
                    }
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

        private void button13_Click(object sender, EventArgs e)
        {
            demage_panel.Visible = true;
            track_panel.Visible = false;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            accept_panel.Visible = false;
            reorder_panel.Visible = false;
            gate_panel.Visible = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            mc.constring();

            try
            {
                if (comboBox7.Text == "" || richTextBox1.Text == "")
                {
                    MessageBox.Show("Write Somthing in Commment Box About Goods...");
                }
                else
                {
                    //id = Convert.ToInt32(c_id.Text);

                    mc.conn.Open();

                  

                    SqlCommand cmd = new SqlCommand("insert into damage_goods([D_id],[comment_box]) values (@D_id,@comment_box)", mc.conn);

                    cmd.Parameters.AddWithValue("@D_id", comboBox7.SelectedItem);
                    cmd.Parameters.AddWithValue("@comment_box", richTextBox1.Text);
                   

                    cmd.ExecuteNonQuery();


                    mc.conn.Close();

                    DialogResult rs = MessageBox.Show("Repost Submitted !");

                    if (rs == DialogResult.OK)
                    {

                        richTextBox1.Text = "";
                        comboBox7.Text = "";
                        demage_panel.Visible = false;
                    }

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

        private void button5_Click(object sender, EventArgs e)
        {
            mc.constring();

            reorder_panel.Visible = true;
            demage_panel.Visible = false;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            track_panel.Visible = false;
            gate_panel.Visible = false;


            try
            {
                mc.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *  From damage_goods ", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                  comboBox8.Items.Add(Dr["D_id"]).ToString();



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

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *  From damage_goods where D_id='"+comboBox8.Text+"'", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    richTextBox2.Text = (Dr["comment_box"]).ToString();



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

        private void button12_Click(object sender, EventArgs e)
        {
            gate_panel.Visible = true;
            reorder_panel.Visible = false;
            demage_panel.Visible = false;
            ware_panel.Visible = false;
            cargo_order_panel.Visible = false;
            view_panel.Visible = false;
            track_panel.Visible = false;
        }

        private void gate_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        string a, b, c, d, f = "";

        private void button27_Click(object sender, EventArgs e)
        {
            cargo_Pass cr = new cargo_Pass();

            cr.p_id.Text = a;
            cr.p_qty.Text = b;
            cr.p_date.Text = c;
            cr.p_from.Text = d;
            cr.p_to.Text = f;
            cr.p_weight.Text = textBox14.Text;
            

            
            cr.Show();
            gate_panel.Visible = false;
         
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mc.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *  From Order_cargo where O_ID='" + comboBox9.Text + "'", mc.conn);
                SqlDataReader Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {

                    

                    a = (Dr["O_ID"]).ToString();
                    b = (Dr["quantity"]).ToString();
                    c = (Dr["shifted_Date"]).ToString();
                    d = (Dr["Shifted_from"]).ToString();
                    f = (Dr["Shifted_to"]).ToString();
                   

                   
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
}
    
}
