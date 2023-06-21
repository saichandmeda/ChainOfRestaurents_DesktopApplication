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
    public partial class MyCart : Form
    {
        public MyCart()
        {
            InitializeComponent();
        }

        private void MyCart_Load(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                dataGridView1.DataSource = ctx.Carts.ToList();
                Program.Total = 0;
                foreach (var item in ctx.Carts)
                {
                    Program.Total = Program.Total + (int)item.Price;
                }
                txtTotal.Text = Program.Total.ToString();
                List<string> Rest = new List<string>();
                foreach (var item in ctx.Carts.ToList())
                {
                    Rest.Add(item.Restaurant);
                }
                List<string> dist = Rest.Distinct().ToList();
                cmbRest.Items.Clear();
                foreach (string item in dist.ToList())
                {
                    cmbRest.Items.Add(item);
                }
                List<string> Loc = new List<string>();
                foreach (var item in ctx.Carts.ToList())
                {
                    Loc.Add(item.Branch);
                }
                List<string> dist2 = Loc.Distinct().ToList();
                cmbLoc.Items.Clear();
                foreach (string item in dist2.ToList())
                {
                    cmbLoc.Items.Add(item);
                }
                List<string> Food = new List<string>();
                foreach (var item in ctx.Carts.ToList())
                {
                    Food.Add(item.FoodItem);
                }
                List<string> dist3 = Food.Distinct().ToList();
                cmbFood.Items.Clear();
                foreach (string item in dist3.ToList())
                {
                    cmbFood.Items.Add(item);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Order Placed and It'll Reach You Soon");
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                foreach (var item in ctx.Carts)
                {
                    History h1 = new History()
                    {
                        UserId = Program.UserId,
                        Restaurant = item.Restaurant,
                        Branch = item.Branch,
                        FoodItem =item.FoodItem,
                        Price=item.Price,
                        DaTi= DateTime.Now
                    };
                    ctx.Histories.Add(h1);
                }
                ctx.SaveChanges();
                var rows = from a in ctx.Carts
                           select a;
                foreach (var row in rows)
                {
                    ctx.Carts.Remove(row);
                }
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbLoc.Text = "";
                cmbFood.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                var rows = from a in ctx.Carts
                           select a;
                foreach (var row in rows)
                {
                    ctx.Carts.Remove(row);
                }
                ctx.SaveChanges();
                MessageBox.Show("Cart Cleared, Please Refresh The Page");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                Cart r1 = ctx.Carts.ToList().
                           FirstOrDefault(i => i.Restaurant == cmbRest.Text && i.Branch
                                        == cmbLoc.Text && i.FoodItem == cmbFood.Text);
                ctx.Carts.Remove(r1);
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbFood.Text = "";
                cmbLoc.Text = "";
                MessageBox.Show("Item Has Been Removed From The Cart, Please Refresh The Page");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
