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
    public partial class Form4 : Form
    {
       // string status = "UNACTIVE";
        Form2 conn = new Form2();
        public Form4()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus;
           
            conn.oleDbConnection1.Open();
           // OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,PH2=@PH2,VAddress=@VAddress,CPName=@CPName,CPPH=@CPPH,VEmail=@VEmail,VFax=@VFax,VGroup=@VGroup,VStatus=@VStatus where VID=@VID", conn.oleDbConnection1);
 OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,VGroup=@VGroup,VStatus=@VStatus where VID=@VID", conn.oleDbConnection1);


            cmd.Parameters.AddWithValue("@VName", textBox1.Text);
           // cmd.Parameters.AddWithValue("@VCity", textBox2.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
            //cmd.Parameters.AddWithValue("@PH2", textBox12.Text);
            //cmd.Parameters.AddWithValue("@VAddress", textBox11.Text);
            //cmd.Parameters.AddWithValue("@CPName", textBox5.Text);
            //cmd.Parameters.AddWithValue("@CPPH", textBox10.Text);
            //cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
            //cmd.Parameters.AddWithValue("@VFax", textBox9.Text);
            cmd.Parameters.AddWithValue("@VGroup", textBox9.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox4.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);

            //OleDbCommand cmd = new OleDbCommand("Update Vendor set VStatus=@VStatus where VID=@VID", conn.oleDbConnection1);
            //cmd.Parameters.AddWithValue("@VStatus", textBox4.Text);
           

            cmd.ExecuteNonQuery();            
            conn.oleDbConnection1.Close();
            MessageBox.Show("Vendor has been Approved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            this.textBox4.Text = "ACTIVE";
            //this.textBox4.ReadOnly = true;
            
             conn.oleDbConnection1.Open();
             OleDbCommand cmd = new OleDbCommand("Select VID from Vendor where VStatus = 'SFA' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //comboBox1.Items.Clear();
                comboBox1.Items.Add(dr["VID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            //PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus;
            if (dr.Read())
            {
                textBox1.Text = dr["VName"].ToString();
                textBox2.Text = dr["VCity"].ToString();
                textBox3.Text = dr["PH1"].ToString();
                textBox12.Text = dr["PH2"].ToString();
                textBox11.Text = dr["VAddress"].ToString();
                textBox5.Text = dr["CPName"].ToString();
                textBox10.Text = dr["CPPH"].ToString();
                textBox9.Text = dr["VEmail"].ToString();
                textBox8.Text = dr["VFax"].ToString();
                textBox7.Text = dr["VGroup"].ToString();
                
               
            }

            conn.oleDbConnection1.Close();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
          conn.oleDbConnection1.Open();
          //OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=@VName,PH1=@PH1,PH2=@PH2,VAddress=@VAddress,CPName=@CPName,CPPH=@CPPH,VEmail=@VEmail,VFax=@VFax,VGroup=@VGroup,VStatus=@VStatus where VID=@VID", conn.oleDbConnection1);

          //cmd.Parameters.AddWithValue("@VName", textBox1.Text);
          //cmd.Parameters.AddWithValue("@VCity", textBox2.Text);
          //cmd.Parameters.AddWithValue("@PH1", textBox3.Text);
          //cmd.Parameters.AddWithValue("@PH2", textBox12.Text);
          //cmd.Parameters.AddWithValue("@VAddress", textBox11.Text);
          //cmd.Parameters.AddWithValue("@CPName", textBox5.Text);
          //cmd.Parameters.AddWithValue("@CPPH", textBox10.Text);
          //cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
          //cmd.Parameters.AddWithValue("@VFax", textBox9.Text);
          //cmd.Parameters.AddWithValue("@VGroup", textBox9.Text);
          //cmd.Parameters.AddWithValue("@VStatus", status);
          //cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
          OleDbCommand cmd = new OleDbCommand("Update Vendor set VStatus=@VStatus where VID='" + comboBox1.Text + "'", conn.oleDbConnection1);
          cmd.Parameters.AddWithValue("@VStatus","UNACTIVE");
           
          cmd.ExecuteNonQuery();        
          conn.oleDbConnection1.Close();
          MessageBox.Show("Issue accured in Approving Vendor Please press OK ","",MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Hide();
          Form5 f5 = new Form5();
          f5.Show();
         // this.button2.Visible = true;

            
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
