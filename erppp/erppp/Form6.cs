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
    public partial class Form6 : Form
    {
        Form2 conn = new Form2();
        public Form6()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
           
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select VID from Vendor ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["VID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus;
            
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Vendor where VID = '" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VName"].ToString();
                textBox3.Text = dr["VCity"].ToString();
                textBox2.Text = dr["PH1"].ToString();
                textBox12.Text = dr["PH2"].ToString();
                textBox11.Text = dr["VAddress"].ToString();
                textBox5.Text = dr["CPName"].ToString();
                textBox10.Text = dr["CPPH"].ToString();

                textBox9.Text = dr["VEmail"].ToString();
                textBox8.Text = dr["VFax"].ToString();
                textBox7.Text = dr["VGroup"].ToString();
                textBox4.Text = dr["VStatus"].ToString();

            }

            conn.oleDbConnection1.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
