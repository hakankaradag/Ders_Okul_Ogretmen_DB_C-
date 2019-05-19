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


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {

        SqlConnection conn = new SqlConnection();

        public Form2()
        {
            InitializeComponent();

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            conn.ConnectionString = "Data Source=(localdb)\\v11.0;Initial Catalog=projectdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();

            DataSet sonucUnvanListesi = new DataSet();
            SqlDataAdapter sqlUnvan = new SqlDataAdapter("select * from dbo.Unvan", conn);
            sqlUnvan.Fill(sonucUnvanListesi, "unvanlar");

            bsUnvanlar.DataSource = sonucUnvanListesi;
            bsUnvanlar.DataMember = "unvanlar";


            comboBox1.DataSource = bsUnvanlar;
            comboBox1.DisplayMember = "Unvan_Ad";
            comboBox1.ValueMember = "Id";







        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataSet datalarim = new DataSet();
            SqlDataAdapter DSQL = new SqlDataAdapter("select * from Ogretmen where DUnvan=@UNVAN and Dad like @AD ", conn);
            DSQL.SelectCommand.Parameters.AddWithValue("@UNVAN",  comboBox1.SelectedValue.ToString()  );   
            DSQL.SelectCommand.Parameters.AddWithValue("@AD", "%"+   textBox1.Text  +"%");

            DSQL.Fill(datalarim, "SorguSonucu");



            bsSorguSonucu.DataSource = datalarim;
            bsSorguSonucu.DataMember = "SorguSonucu";

            dataGridView1.DataSource = bsSorguSonucu;
        }
    }
}
