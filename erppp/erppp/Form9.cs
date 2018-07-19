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
    public partial class Form9 : Form
    {
        Form2 conn = new Form2();
        public Form9()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox4.Text = "GRN-0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
           
           
             OleDbCommand cmd1 = new OleDbCommand("Select POID from PO where Status = 'OPEN' ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                //comboBox1.Items.Clear();
                comboBox1.Items.Add(dr1["POID"]).ToString();
            }

            conn.oleDbConnection1.Close();
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.oleDbConnection1.Open(); 
            OleDbCommand cmd = new OleDbCommand("Select *from PO where POID ='" + comboBox1.Text + "' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr["VID"].ToString();
                textBox2.Text = dr["VName"].ToString();
                textBox3.Text = dr["DDate"].ToString();
               
             }
           
            OleDbDataAdapter da = new OleDbDataAdapter("Select  *from POProducts where POID ='" + comboBox1.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.oleDbConnection1.Close();
        }
        //GRN CREATION BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            //int i;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into GRN(GRNID,POID,Status,VName,GRDate,DDate,VID) values(@GRNID,@POID,@Status,@VName,@GRDate,@DDate,@VID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", textBox4.Text);
            cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Status", "OPEN");
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@GRDate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@DDate", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.ExecuteNonQuery();
           
           
           OleDbCommand cmd1 = new OleDbCommand("Update PO set Status= 'CLOSE'  where POID ='" + comboBox1.Text + "'", conn.oleDbConnection1);
            cmd1.ExecuteNonQuery();  

             conn.oleDbConnection1.Close();
             MessageBox.Show("GRN CREATED", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
