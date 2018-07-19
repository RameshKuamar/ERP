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
    public partial class invoice : Form
    {
        Form2 conn = new Form2();
        public invoice()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void invoice_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            textBox1.ReadOnly = true;

            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox10.ReadOnly = true;

           // textBox2.Text = Convert.ToInt32();
            this.textBox8.ReadOnly = true;
            int c = 0;
                 
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
            OleDbCommand cmdd = new OleDbCommand("Select GRNID from GRN where Status ='OPEN' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add(drr["GRNID"]).ToString();
            }



            conn.oleDbConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceID,VendorID,VendorName,GRNDate,CDate,AmountPayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@GRNDate,@CDate,@AmountPayable,@GRNID)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VendorID", textBox4.Text);
            cmd.Parameters.AddWithValue("@VendorName", textBox5.Text);
            cmd.Parameters.AddWithValue("@GRNDate",  textBox10.Text.ToString());
            cmd.Parameters.AddWithValue("@CDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@AmountPayable", textBox8.Text);
            cmd.Parameters.AddWithValue("@GRNID", comboBox1.Text);
            cmd.ExecuteNonQuery();


            OleDbCommand cmd1 = new OleDbCommand("Update GRN set Status= 'CLOSE'  where GRNID ='" + comboBox1.Text + "'", conn.oleDbConnection1);
            cmd1.ExecuteNonQuery();  

            conn.oleDbConnection1.Close();
            MessageBox.Show("INVOICE CREATED","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private object Int32(string p)
        {
            throw new NotImplementedException();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox8.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from GRN where GRNID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox10.Text = dr["GRDate"].ToString();
                textBox3.Text = dr["POID"].ToString();
                textBox4.Text = dr["VID"].ToString();
                textBox5.Text = dr["VName"].ToString();

            }
           
            OleDbCommand cmd1 = new OleDbCommand("Select  *from PO where POID = '" + textBox3.Text + "'", conn.oleDbConnection1);
          
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox6.Text = dr1["PPRICE"].ToString();
               
            }
            OleDbDataAdapter da = new OleDbDataAdapter("Select Pid , PQty  from POProducts where POID ='" + textBox3.Text + "'", conn.oleDbConnection1);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           // Hide();
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           //// conn.oleDbConnection1.Open();
           // OleDbCommand cmd = new OleDbCommand("Select *from POProducts where POID ='" + textBox3.Text + "' ", conn.oleDbConnection1);
           // OleDbDataReader dr = cmd.ExecuteReader();

           // if (dr.Read())
           // {
           //     textBox2.Text += dr["Pid"].ToString()+Environment.NewLine;
           //     textBox7.Text += dr["PQty"].ToString() + Environment.NewLine;
           // }
           
        }
    }
}
