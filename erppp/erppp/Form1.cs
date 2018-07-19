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
    public partial class Form1 : Form
    {
        Form2 conn = new Form2();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            //textBox1.Text = "ram";
            //textBox2.Text = "123";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Login where LOGID = '" + textBox1.Text + "' and LOGPAS='"+textBox2.Text+"' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
           
            if (dr.Read())
            {
                MessageBox.Show("WELCOME TO KUMAR ENTERPRISE ","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
            else if(textBox1.Text == "" & textBox2.Text == "")
            {
                MessageBox.Show("PLEASE ENTER LOGIN ID AND PASSWORD","",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
            else 
            {
                MessageBox.Show("PASSWORD IS NOT CORRECT","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            conn.oleDbConnection1.Close();
            
            
            
            
            /* cmd.Parameters.AddWithValue("@LIGID", textBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
           string LOGPAS = dr[0].ToString();
           if (LOGPAS == textBox2.Text)
           {
            //   Form3 f3 = new Form3();
               
              
           }
           MessageBox.Show("Pass correct");
            conn.oleDbConnection1.Close();*/
           



            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
