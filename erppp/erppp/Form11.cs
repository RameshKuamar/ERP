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
    public partial class Form11 : Form
    {
        Form2 conn = new Form2();
        public Form11()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            textBox11.ReadOnly = true;
            textBox11.Text = "SFA";
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(CID) from Customer ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "C-0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
            conn.oleDbConnection1.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            

           
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Customer (CID,Cname,CAddress,City,PH1,PH2,ContactPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@ContactPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", conn.oleDbConnection1);
            //,Cname,CAddress,City,PH1,PH2,ContactPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup

            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@City", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox6.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox8.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox9.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox10.Text);
            cmd.Parameters.AddWithValue("@CStatus", textBox11.Text);
            cmd.Parameters.AddWithValue("@CGroup", textBox12.Text);

            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show(" Sent for Approval","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f7 = new Form12();
            f7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
