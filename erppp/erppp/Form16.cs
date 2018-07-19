using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RKERP
{
    public partial class Form16 : Form
    {
        Form2 conn = new Form2();
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
           
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            
            textBox10.ReadOnly = true;

            this.textBox8.ReadOnly = true;
            int c = 0;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from InvoiceR ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "0" + c.ToString()+ "-" + System.DateTime.Today.Year; 
            OleDbCommand cmdd = new OleDbCommand("Select DCID from DelChalan where Status ='OPEN' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Add(drr["DCID"]).ToString();
            }



            conn.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from DelChalan where DCID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox10.Text = dr["DCDate"].ToString();
                textBox3.Text = dr["SOID"].ToString();
                textBox5.Text = dr["CName"].ToString();
                textBox4.Text = dr["CID"].ToString();
                

            }
            OleDbCommand cmd1 = new OleDbCommand("Select  *from SO where SOID = '" + textBox3.Text + "'", conn.oleDbConnection1);

            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox6.Text = dr1["PRICE"].ToString();
                // textBox6.Text = dr1["TotalAmount"].ToString();
               

            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select Pid , PQty  from SOProducts where SOID ='" + textBox3.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.oleDbConnection1.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox6.Text);
            int disc = Convert.ToInt32(textBox9.Text);
            int discount = (price * disc) / 100;
            int d = price - discount;
            textBox8.Text = d.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into InvoiceR(InvoiceID,CustID,CustName,DCDate,InvoiceDate,AmountRecievable,DelCID) values(@InvoiceID,@CustID,@CustName,@DCDate,@InvoiceDate,@AmountRecievable,@DelCID)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustID", textBox4.Text);
            cmd.Parameters.AddWithValue("@CustName", textBox5.Text);
            cmd.Parameters.AddWithValue("@DCDate", textBox10.Text);
            cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@AmountRecievable", textBox8.Text);
            cmd.Parameters.AddWithValue("@DelCID", comboBox1.Text);
             cmd.ExecuteNonQuery();

            // string s = "CLOSE";
            // OleDbCommand cmd1 = new OleDbCommand("Update DelChalan set Status= @Status where DelCID ='" + comboBox1.Text + "'", conn.oleDbConnection1);
            // cmd.Parameters.AddWithValue("@Status","CLOSE"); 
            //cmd1.ExecuteNonQuery();  

            conn.oleDbConnection1.Close();
            MessageBox.Show("IVOICE PAYABLE CREATED", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
