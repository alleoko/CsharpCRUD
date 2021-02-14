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

namespace CSharpCRUDMsSQL
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9F5QGN0\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True");

        private void btn_Add_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO StudentTBL (STUD_ID, NAME, SCHOOL, COURSE) VALUES (@STUD_ID, @NAME, @SCHOOL, @COURSE)",con);
            cmd.Parameters.AddWithValue("@STUD_ID", txtID.Text);
            cmd.Parameters.AddWithValue("@NAME",txtName.Text);
            cmd.Parameters.AddWithValue("@SCHOOL", txtSchool.Text);
            cmd.Parameters.AddWithValue("@COURSE", txtCourse.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            txtID.Text = "";
            txtName.Text = "";
            txtSchool.Text = "";
            txtCourse.Text = "";

            MessageBox.Show("DATA SAVED");
            this.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM StudentTBL WHERE @STUD_ID = STUD_ID", con);
            cmd.Parameters.AddWithValue("@STUD_ID", txtID.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            txtID.Text = "";
            txtName.Text = "";
            txtSchool.Text = "";
            txtCourse.Text = "";

            MessageBox.Show("DATA DELETED");

        }

   

        private void Form1_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentTBL", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE StudentTBL set  NAME=@NAME, SCHOOL=@SCHOOL, COURSE=@COURSE WHERE STUD_ID=@STUD_ID ", con);
            cmd.Parameters.AddWithValue("@STUD_ID", txtID.Text);
            cmd.Parameters.AddWithValue("@NAME", txtName.Text);
            cmd.Parameters.AddWithValue("@SCHOOL", txtSchool.Text);
            cmd.Parameters.AddWithValue("@COURSE", txtCourse.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            txtID.Text = "";
            txtName.Text = "";
            txtSchool.Text = "";
            txtCourse.Text = "";

            MessageBox.Show("DATA UPDATED");
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentTBL WHERE STUD_ID=@STUD_ID", con);
            cmd.Parameters.AddWithValue("@STUD_ID", txtID.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

     
    }
}
