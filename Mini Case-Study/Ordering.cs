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
    public partial class Ordering : Form
    {
        public Ordering()
        {
            InitializeComponent();
        }

        private void Ordering_Load(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                List<string> locations = new List<string>();
                foreach (var item in ctx.Restaurants)
                {
                    if (item.City == Program.City && item.RName == Program.Restaurant)
                    {
                        locations.Add(item.Branch);
                    }
                }
                //List<string> dist = locations.Distinct().ToList();
                var bindableNames = from name in locations
                                    select new { Locations = name };
                dataGridView1.DataSource = bindableNames.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Locations"].
                                                            FormattedValue);
                //MessageBox.Show(name);
                //var data = from a in ctx.Restaurants.ToList() where a.RName == name select a;
                Program.Location = name;
                var data = from a in ctx.FoodItems.ToList()
                           where (a.City == Program.City && a.Branch == Program.Location
                                                   && a.Rname == Program.Restaurant)
                           select new
                           {
                               a.Fooditem1,
                               a.Price,
                               a.Img
                           };
                dataGridView2.DataSource = data.ToList();
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView2.Columns[2];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                string name = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["Fooditem1"].
                                                            FormattedValue);
                label1.Text = name;
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
                Program.FoodItem = label1.Text;
                foreach (var item in ctx.FoodItems)
                {
                    if (item.City==Program.City && item.Rname==Program.Restaurant &&
                          item.Branch==Program.Location && item.Fooditem1==Program.FoodItem)
                    {
                        Cart c1 = new Cart()
                        {
                            FoodItem=item.Fooditem1,
                            Price=item.Price,
                            Restaurant=item.Rname,
                            Branch=item.Branch
                        };
                        ctx.Carts.Add(c1);
                    }
                }
                ctx.SaveChanges();
                label1.Text = "FoodItem";
                MessageBox.Show("Item Has Been Succesfully Added To The Cart");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
