using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Case_Study
{
    public partial class UserMaster : Form
    {
        public UserMaster()
        {
            InitializeComponent();
        }

        private void UserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = Program.City;
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                var rows = from a in ctx.Carts
                           select a;
                foreach (var row in rows)
                {
                    ctx.Carts.Remove(row);
                }
                ctx.SaveChanges();
                List<string> rest = new List<string>();
                foreach (var item in ctx.Restaurants)
                {
                    if (item.City == Program.City)
                    {

                        rest.Add(item.RName);
                    }
                }
                List<string> dist = rest.Distinct().ToList();
                var bindableNames = from name in dist
                                    select new { Restaurants = name };
                dataGridView1.DataSource = bindableNames.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
                button1.Text = "";
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                string name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Restaurants"].
                                                            FormattedValue);
                //MessageBox.Show(name);
                //var data = from a in ctx.Restaurants.ToList() where a.RName == name select a;
                foreach (var item in ctx.Restaurants)
                {
                    if (item.RName == name)
                    {
                        Image img;
                        MemoryStream ms = new MemoryStream(item.Picture, 0, item.Picture.Length);
                        ms.Write(item.Picture, 0, item.Picture.Length);
                        img = Image.FromStream(ms, true);
                        pictureBox1.Image = img;
                        break;
                    }
                }
                button1.Text = name;
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
                Program.Restaurant = button1.Text;
                Ordering obj = new Ordering();
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MyCart obj = new MyCart();
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MyHistory obj = new MyHistory();
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
