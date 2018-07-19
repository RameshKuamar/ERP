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
    public partial class Form12 : Form
    {
        string st = "INACTIVE";
        Form2 conn = new Form2();
        public Form12()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {
          
  
            textBox7.ReadOnly = true;
            textBox7.Text = "ACTIVE";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select CID from Customer where CStatus = 'SFA' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //comboBox1.Items.Clear();
                comboBox1.Items.Add(dr["CID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            //,Cname,CAddress,City,PH1,PH2,ContactPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup
            //,Cname,City,PH1,ContactPerson,CreditLimit,CStatus
            if (dr.Read())
            {
                textBox2.Text = dr["CName"].ToString();
                textBox8.Text = dr["CAddress"].ToString();
                textBox3.Text = dr["City"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox1.Text = dr["PH2"].ToString();
                textBox5.Text = dr["ContactPerson"].ToString();
                textBox9.Text = dr["CPPH"].ToString();
                textBox10.Text = dr["CEmail"].ToString();
                textBox6.Text = dr["CreditLimit"].ToString();
                textBox11.Text = dr["CGroup"].ToString();
                
                
                
               
            }

            conn.oleDbConnection1.Close();
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,PH1=@PH1,ContactPerson=@ContactPerson,CreditLimit=@CreditLimit,CStatus=@CStatus where CID=@CID", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", textBox5.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox6.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox7.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show(" Customer has been Approved","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
           // OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,PH1=@PH1,ContactPerson=@ContactPerson,CreditLimit=@CreditLimit,CStatus=@CStatus where CID=@CID", conn.oleDbConnection1);

            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,CStatus=@CStatus where CID='" + comboBox1.Text + "'", conn.oleDbConnection1);

            //Fields are=Cname,CAddress,City,PH1,PH2,ContactPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup


            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
           // cmd.Parameters.AddWithValue("@CAddress", textBox8.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            //cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            //cmd.Parameters.AddWithValue("@PH2", textBox1.Text);
            //cmd.Parameters.AddWithValue("@ContactPerson", textBox5.Text);
            //cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            //cmd.Parameters.AddWithValue("@CreditLimit", textBox6.Text);
            //cmd.Parameters.AddWithValue("@CGroup", textBox11.Text);
            cmd.Parameters.AddWithValue("@CStatus", st);
            cmd.Parameters.AddWithValue("@CID", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("CUSTOMER CAN NOT BE APPROVED","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
