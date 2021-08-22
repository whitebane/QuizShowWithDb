using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Quiz_Show
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0RV7KDT\SQLEXPRESS;Initial Catalog=QuizShow;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

            lblTrue.Visible = false;
            lblTick.Visible = false;
        }

        int tick = 0;
        int point = 0;
        int time = 20;

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            time = 20;
            button1.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button4.Enabled = true;
            btnStart.Enabled = false;
            btnStart.Text = "Next";
            tick++;
            lblTick.Text = tick.ToString();
            lblTick.Visible = true;
            button1.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;

            if (tick==1)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Quest1 order by NEWID()", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    button1.Text = (rdr["a"].ToString());
                    button5.Text = (rdr["b"].ToString());
                    button4.Text = (rdr["c"].ToString());
                    button3.Text = (rdr["d"].ToString());
                    textBox1.Text = (rdr["Quest"].ToString());
                    lblTrue.Text = (rdr["true"].ToString());
                }

                conn.Close();
            }

            if (tick==2)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Quest2 order by NEWID()", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    button1.Text = (rdr["a"].ToString());
                    button5.Text = (rdr["b"].ToString());
                    button4.Text = (rdr["c"].ToString());
                    button3.Text = (rdr["d"].ToString());
                    textBox1.Text = (rdr["Quest"].ToString());
                    lblTrue.Text = (rdr["true"].ToString());
                }

                conn.Close();
            }

            if (tick==3)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * from Quest3 order by NEWID()", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    button1.Text = (rdr["a"].ToString());
                    button5.Text = (rdr["b"].ToString());
                    button4.Text = (rdr["c"].ToString());
                    button3.Text = (rdr["d"].ToString());
                    textBox1.Text = (rdr["Quest"].ToString());
                    lblTrue.Text = (rdr["true"].ToString());
                }

                btnStart.Text = "Game Over";

                conn.Close();
            }


            if (tick==4)
            {
                btnStart.Text = "Game Over";
                button4.Text = "";
                button1.Text = "";
                button5.Text = "";
                button3.Text = "";
                textBox1.Text = "";
                button4.Enabled=false;
                button5.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            button3.Enabled = false;
            button5.Enabled = false;
            button4.Enabled = false;
            if (button1.Text==lblTrue.Text)
            {
                point = point + 10;
                lblPoint.Text = point.ToString();
                button1.BackColor = Color.Green;
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (true)
            {
                btnStart.Enabled = true;
                button3.Enabled = false;
                button1.Enabled = false;
                button4.Enabled = false;
                if (button5.Text == lblTrue.Text)
                {
                    point = point + 10;
                    lblPoint.Text = point.ToString();
                    button5.BackColor = Color.Green;
                }
                else
                {
                    button5.BackColor = Color.Red;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == lblTrue.Text)
            {
                point = point + 10;
                lblPoint.Text = point.ToString();
                button4.BackColor = Color.Green;
            }
            else
            {
                button4.BackColor = Color.Red;
            }
            
            btnStart.Enabled = true;
            button3.Enabled = false;
            button5.Enabled = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == lblTrue.Text)
            {
                point = point + 10;
                lblPoint.Text = point.ToString();
                button3.BackColor = Color.Green;
            }

            else
            {
                button3.BackColor = Color.Red;
            }
            btnStart.Enabled = true;
            button1.Enabled = false;
            button5.Enabled = false;
            button4.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            time = time - 1;
            label3.Text = time.ToString();

            if (time==0)
            {
                MessageBox.Show("Time is over");
                button1.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                textBox1.Text = "";
                btnStart.Enabled = true;

            }
        }
    }
}
