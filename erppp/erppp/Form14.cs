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
    public partial class Form14 : Form
    {
        string[] pid = new string[50];
        int[] qty = new int[50];
        int[] productprice = new int[50];
        //int[] pprice = new int[50];//ptprice= product total price
        int counter = 0;

        Form2 conn = new Form2();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox9.ReadOnly = true;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //comboBox1.Items.Clear();
                comboBox1.Items.Add(dr["Deptname"]).ToString();
            }


            OleDbCommand cmdd = new OleDbCommand("Select CID from Customer where CStatus = 'ACTIVE' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
               // comboBox2.Items.Clear();
                comboBox2.Items.Add(drr["CID"]).ToString();
            }


            OleDbCommand cd = new OleDbCommand("Select Pid from Products ", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();
            while (dnr.Read())
            {
                //comboBox3.Items.Clear();
                comboBox3.Items.Add(dnr["Pid"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.oleDbConnection1.Open();

            OleDbCommand cmdd = new OleDbCommand("select count(SOID) from SO ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();
            if (drr.Read())
            {
                c = Convert.ToInt32(drr[0]);
                c++;
            }

            textBox1.Text = comboBox1.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;

            conn.oleDbConnection1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Customer where CID = '" + comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr["Cname"].ToString();
                textBox10.Text = dr["PH1"].ToString();
                textBox3.Text = dr["CGroup"].ToString();
                textBox4.Text = dr["CPPH"].ToString();
 
            }

            conn.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox11.Clear();
            conn.oleDbConnection1.Open();
            OleDbCommand cd = new OleDbCommand("Select *from Products where Pid = '" + comboBox3.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dnr = cd.ExecuteReader();

            if (dnr.Read())
            {

                textBox5.Text = dnr["ProductModel"].ToString();
                textBox6.Text = dnr["PName"].ToString();
                textBox7.Text = dnr["BasePrice"].ToString();

            }

            conn.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tp;
            int p = Convert.ToInt32(textBox7.Text.ToString());
            int q = Convert.ToInt32(textBox8.Text.ToString());

            tp = q * p;
            textBox11.Text = tp.ToString();

            textBox9.Text +=  label8.Text + " : " +comboBox3.Text+Environment.NewLine;
            textBox9.Text += label11.Text + " : " + textBox5.Text + Environment.NewLine;
            textBox9.Text += label13.Text + " : " + textBox6.Text + Environment.NewLine;
            textBox9.Text += label12.Text + " : " + textBox7.Text + Environment.NewLine;
            textBox9.Text += label10.Text + " : " + textBox8.Text + Environment.NewLine;
            textBox9.Text += label19.Text + " : " + textBox11.Text + Environment.NewLine;

            pid[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox8.Text);
            productprice[counter] = Convert.ToInt32(textBox11.Text);
            
            counter++;
            
            MessageBox.Show("ProductsAre Added","",MessageBoxButtons.OK,MessageBoxIcon.Information);

         }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //CREATE SO
           // int s;// = 0;
            int s = 0;
            foreach (int p in productprice)
            {
                s = p + s;
            
            }

            

            conn.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,SODate,DDate,Status,Approve,CDept,CName,CID,CCPPH,PRICE) values(@SOID,@SODate,@DDate,@Status,@Approve,@CDept,@CName,@CID,@CCPPH,@PRICE)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@SOID", textBox1.Text);
            cmd.Parameters.AddWithValue("@SODate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@DDate", dateTimePicker2);
            //DDate

            cmd.Parameters.AddWithValue("@Status", "OPEN");
            cmd.Parameters.AddWithValue("@Approve", "APPROVED");
            cmd.Parameters.AddWithValue("@CDept", textBox3.Text);
            cmd.Parameters.AddWithValue("@CName", textBox2.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CCPPH", textBox4.Text);
            cmd.Parameters.AddWithValue("@PRICE", s);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < counter; i++)
            {
               
               OleDbCommand cmd1 = new OleDbCommand("insert into SOProducts(SOID,Pid,PQty,TPPRICE) values(@SOID,@Pid,@PQty,@TPPRICE)", conn.oleDbConnection1);
               // OleDbCommand cmd1 = new OleDbCommand("insert into SOProducts(PQty,TPPRICE) values(@PQty,@TPPRICE)", conn.oleDbConnection1);

               cmd1.Parameters.AddWithValue("@SOID", textBox1.Text);
               //cmd1.Parameters.AddWithValue("@Pid", pid[counter]);
               //cmd1.Parameters.AddWithValue("@PQty", qty[counter]);
               //cmd1.Parameters.AddWithValue("@TPPRICE", pprice[counter]);
               cmd1.Parameters.AddWithValue("@Pid", pid[i]);
               cmd1.Parameters.AddWithValue("@PQty", qty[i]);
               cmd1.Parameters.AddWithValue("@TPPRICE",productprice[i]);
               cmd1.ExecuteNonQuery();
                   
               // counter++;
            }

            conn.oleDbConnection1.Close();
            MessageBox.Show("TRANSACTION COMPLETE !","",MessageBoxButtons.OK, MessageBoxIcon.Information);
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

    
    }
}
