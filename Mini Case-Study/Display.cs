using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Case_Study
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                List<string> City = new List<string>();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    City.Add(item.City);
                }
                List<string> Distinct = City.Distinct().ToList();
                cmbCity.Items.Clear();
                foreach (string item in Distinct.ToList())
                {
                    cmbCity.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbRest.Text = "";
                cmbLoc.Text = "";
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                List<string> Rest = new List<string>();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    if (cmbCity.Text == item.City)
                    {
                        Rest.Add(item.RName);
                    }
                }
                List<string> Distinct = Rest.Distinct().ToList();
                cmbRest.Items.Clear();
                foreach (string item in Distinct.ToList())
                {
                    cmbRest.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbLoc.Text = "";
                cmbLoc.Items.Clear();
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text == item.RName)
                    {
                        cmbLoc.Items.Add(item.Branch);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                var data = from a in ctx.FoodItems.ToList()
                           where (a.City == cmbCity.Text && a.Branch == cmbLoc.Text
                                                   && a.Rname == cmbRest.Text)
                           select new
                           {
                               a.Fooditem1,
                               a.Price,
                               a.Img
                           };
                //dataGridView1.DataSource = null;
                dataGridView1.DataSource = data.ToList();
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView1.RowTemplate.Height = 250;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
