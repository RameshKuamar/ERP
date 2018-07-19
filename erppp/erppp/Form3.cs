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
    public partial class Form3 : Form
    {
        Form2 conn = new Form2();
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.button2.ForeColor = Color.Goldenrod;
          this.groupBox2.Visible = true;
            groupBox2.Show();
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.button1.ForeColor = Color.Goldenrod;
            this.Hide();
            Form11 f11 = new Form11();
            f11.Show();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            textBox6.ReadOnly = true;
            this.textBox6.Text = "SFA";
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(VID) from Vendor ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox1.Text = "V-00" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
           
            OleDbCommand cmd1 = new OleDbCommand("Select deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["deptname"]).ToString();
            }
            conn.oleDbConnection1.Close();



        }

        private void button8_Click(object sender, EventArgs e)
        {
            //PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus;
            conn.oleDbConnection1.Open();
           string s = "insert into Vendor(VID,VName,VCity,PH1,PH2,VAddress,CPName,CPPH,VEmail,VFax,VGroup,VStatus) values(@VID,@VName,@VCity,@PH1,@PH2,@VAddress,@CPName,@CPPH,@VEmail,@VFax,@VGroup,@VStatus)";

            OleDbCommand cmd = new OleDbCommand(s, conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCity", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox4.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox12.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox11.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox5.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox10.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox9.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox8.Text);
            cmd.Parameters.AddWithValue("@VGroup", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VStatus", textBox6.Text);

            
           
            cmd.ExecuteNonQuery();
            
            conn.oleDbConnection1.Close();
            MessageBox.Show("Vendor has been sent for Approval", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();    
            Form4 f4 = new Form4();
            f4.Show();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       
       

        private void button9_Click_1(object sender, EventArgs e)
        {
            groupBox1.Show();
            //this.groupBox1.Visible = true;
           this.groupBox2.Visible = false;

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f8 = new Form4();
            f8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            invoice vc = new invoice();
            vc.Show();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 f16 = new Form16();
            f16.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_CursorChanged(object sender, EventArgs e)
        {
            button7.BackColor = Color.SteelBlue;
        }
    }
}
