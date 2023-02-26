using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace crud1
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

       
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getdata();
        }
        private void getdata()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";

            MySqlCommand cmd = new MySqlCommand("select * from student", conn);

            DataTable dt = new DataTable();
            conn.Open();

            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
     
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            if(Isvalid())
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";
                MySqlCommand cmd = new MySqlCommand(" INSERT INTO student VALUES(@rid, @name, @mark, @class, @percentage)",conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rid", rid.Text);
                cmd.Parameters.AddWithValue("@name", sname.Text);
                cmd.Parameters.AddWithValue("@mark", smarks.Text);
                cmd.Parameters.AddWithValue("@class", sclass.Text);
                cmd.Parameters.AddWithValue("@percentage", per.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("new student sucessfully saved database","saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getdata();
                clear1();
            }
            
        }
        private bool Isvalid()
        {
            if(sname.Text==string.Empty)
            {
                MessageBox.Show("Student name is required","failed" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            sname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            smarks.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            sclass.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            per.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();


        }

        private void update_Click(object sender, EventArgs e)
        {
            
            
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";
                MySqlCommand cmd = new MySqlCommand(" UPDATE student SET rid= @rid, name= @name, mark = @mark, class = @class, percentage = @percentage WHERE rid=@rid", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rid", rid.Text);
                cmd.Parameters.AddWithValue("@name", sname.Text);
                cmd.Parameters.AddWithValue("@mark", smarks.Text);
                cmd.Parameters.AddWithValue("@class", sclass.Text);
                cmd.Parameters.AddWithValue("@percentage", per.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update sucessfully saved database", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getdata();
                clear1();
            
            


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";
                MySqlCommand cmd = new MySqlCommand(" DELETE FROM student WHERE rid=@rid", conn);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rid", rid.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("delete sucessfully saved database", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getdata();
                clear1();
            
           

        }

        private void clear_Click(object sender, EventArgs e)
        {
            clear1();


        }
        private void clear1()
        {
            rid.Clear();
            sname.Clear();
            smarks.Clear();
            sclass.Clear();
            per.Clear();
        }

        private void sname_TextChanged(object sender, EventArgs e)
        {
             
        }
    }
    }

