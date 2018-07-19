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
    public partial class Form7 : Form
    {
        Form2 conn = new Form2();

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            
            groupBox1.Text = "CUSTOMER INFORMATION";
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select CID from Customer ", conn.oleDbConnection1);
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
            if (dr.Read())
            {
                textBox1.Text = dr["CName"].ToString();
                textBox2.Text = dr["CAddress"].ToString();
                textBox3.Text = dr["City"].ToString();
                textBox4.Text = dr["PH1"].ToString();
                textBox5.Text = dr["PH2"].ToString();
                textBox6.Text = dr["ContactPerson"].ToString();
                textBox7.Text = dr["CPPH"].ToString();
                textBox8.Text = dr["CEmail"].ToString();
                textBox9.Text = dr["CreditLimit"].ToString();
                textBox10.Text = dr["CStatus"].ToString();
                textBox11.Text = dr["CGroup"].ToString();


            }

            conn.oleDbConnection1.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
