using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["WindowsFormsApplication6.Properties.Settings.conn"].ConnectionString);
            SqlCommand cm = new SqlCommand("select nombre from provincia", cn);

            try
            {

                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                comboBox1.Items.Clear();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }

            }
            catch (SqlException et)
            {
                MessageBox.Show(et.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["WindowsFormsApplication6.Properties.Settings.conn"].ConnectionString);
            SqlCommand cm = new SqlCommand("select a.nombre from localidad a inner join provincia b on a.idprovincia = b.id where b.nombre = '" +  comboBox1.Text + "' order by 1 " , cn);

            try
            {

                cn.Open();
                SqlDataReader dr = cm.ExecuteReader();
                comboBox2.Items.Clear();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                }

            }
            catch (SqlException et)
            {
                MessageBox.Show(et.Message);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                cn.Close();
            }

        }
    }
}
