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
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            conn.ConnectionString = "Data Source=(localdb)\\v11.0;Initial Catalog=projectdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();

            DataSet datalarim = new DataSet();
            SqlDataAdapter  DSQL = new SqlDataAdapter("select * from Dersler", conn);
            DSQL.Fill(datalarim, "Dersler");

            SqlDataAdapter OgretmenSQL = new SqlDataAdapter("select Did, concat(Dad, ' - ', Dunvan) as adveunvan  from dbo.Ogretmen", conn);
            OgretmenSQL.Fill(datalarim, "Ogretmen");




            bsDers.DataSource = datalarim;
            bsDers.DataMember = "Dersler";

            bsOgretmen.DataSource = datalarim;
            bsOgretmen.DataMember = "Ogretmen";



            bindingNavigator1.BindingSource = bsDers;
            

            textBox1.DataBindings.Add(new Binding("Text", bsDers, "Dkod"));
            

            textBox2.DataBindings.Add(new Binding("Text", bsDers, "Dadi"));
     
            radioButton1.DataBindings.Add(new Binding("checked", bsDers, "Ddonem"));
            

            comboBox1.DataBindings.Add(new Binding("SelectedValue", bsDers, "Dogr"));
            
            comboBox1.DataSource = bsOgretmen;
            comboBox1.ValueMember = "Did";
            comboBox1.DisplayMember = "adveunvan";


            dateTimePicker1.DataBindings.Add(new Binding("Text", bsDers, "Dvize"));
            dateTimePicker2.DataBindings.Add(new Binding("Text", bsDers, "Dfinal"));



            DataRowView row = (bsDers.Current as DataRowView);


            SqlDataAdapter OgrenciSQL = new SqlDataAdapter("select * from Ogrenci where ONo in (select OId from DersOgrenci where DId = "+ row.Row[0].ToString()   + " )", conn);
            OgrenciSQL.Fill(datalarim, "Ogrenci");

            bsOgrenci.DataSource = datalarim;
            bsOgrenci.DataMember = "Ogrenci";

            dataGridView1.DataSource = bsOgrenci;

        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bsOad_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            radioButton2.Checked = !(sender as RadioButton).Checked;
        }

        private void bsDers_CurrentChanged(object sender, EventArgs e)
        {
            DataSet datalarim = new DataSet();
            DataRowView row = (bsDers.Current as DataRowView);

            if (row != null)
            {
                SqlDataAdapter OgrenciSQL = new SqlDataAdapter("select * from Ogrenci where ONo in (select OId from DersOgrenci where DId = " + row.Row[0].ToString() + " )", conn);
                OgrenciSQL.Fill(datalarim, "Ogrenci");

                bsOgrenci.DataSource = datalarim;
                bsOgrenci.DataMember = "Ogrenci";

                dataGridView1.DataSource = bsOgrenci;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bsOgretmen_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}