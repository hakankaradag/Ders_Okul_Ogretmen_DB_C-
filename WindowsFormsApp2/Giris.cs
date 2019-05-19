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
    public partial class Giris : Form
    {

        SqlConnection conn = new SqlConnection();

        public Giris()
        {
            
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Giris_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=(localdb)\\v11.0;Initial Catalog=projectdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();

            DataSet datalarim = new DataSet();
            SqlDataAdapter OgretmenSQL = new SqlDataAdapter("select Dad from dbo.Ogretmen", conn);
            OgretmenSQL.Fill(datalarim, "Ogretmen");

            bs.DataSource = datalarim;
            bs.DataMember = "Ogretmen";


            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "Dad";





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }
    }
}
