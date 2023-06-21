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
    public partial class EditMenu : Form
    {
        string img1 = null;
        public EditMenu()
        {
            InitializeComponent();
        }

        private void EditMenu_Load(object sender, EventArgs e)
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
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbRest.Text = "";
                cmbLoc.Text = "";
                cmbFood.Text = "";
                txtPrice.Text = "";
                txtType.Text = "";
                pictureBox1.Image = null;
                cmbRest.Items.Clear();
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
                cmbFood.Text = "";
                txtPrice.Text = "";
                txtType.Text = "";
                pictureBox1.Image = null;
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

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFood.Text = "";
                txtPrice.Text = "";
                txtType.Text = "";
                pictureBox1.Image = null;
                cmbFood.Items.Clear();
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text == item.RName
                        && cmbLoc.Text == item.Branch)
                    {
                        txtType.Text = item.RType;
                    }
                }
                //Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                //var joindata = from a in ctx.Restaurants.ToList()
                //               join b in ctx.FoodItems.ToList()
                //               on a.RName equals b.Rname
                //               where (a.City == b.City && a.Branch == b.Branch)
                //               select new
                //               {
                //                   a.RName,
                //                   a.City,
                //                   a.Branch,
                //                   b.Fooditem1,
                //                   b.Price,
                //                   b.Img
                //               };
                //foreach (var item in joindata.ToList())
                foreach (var item in ctx.FoodItems)
                {
                    if (cmbCity.Text == item.City && cmbRest.Text == item.Rname
                        && cmbLoc.Text == item.Branch)
                    {
                        cmbFood.Items.Add(item.Fooditem1);
                    }
                }
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
                Image img2 = pictureBox1.Image;
                byte[] byt;
                ImageConverter convert = new ImageConverter();
                byt = (byte[])convert.ConvertTo(img2, typeof(byte[]));
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                FoodItem f1 = new FoodItem()
                {
                    Rname = cmbRest.Text,
                    City = cmbCity.Text,
                    Branch = cmbLoc.Text,
                    Fooditem1 = cmbFood.Text,
                    Price = int.Parse(txtPrice.Text),
                    Img = byt
                };
                ctx.FoodItems.Add(f1);
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                cmbFood.Text = "";
                txtPrice.Text = "";
                txtType.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Record Has Been Added Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        img1 = ofd.FileName;
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
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
                Image img2 = pictureBox1.Image;
                byte[] byt;
                ImageConverter convert = new ImageConverter();
                byt = (byte[])convert.ConvertTo(img2, typeof(byte[]));
                foreach (var item in ctx.FoodItems.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text ==
                        item.Rname && cmbLoc.Text == item.Branch && cmbFood.Text == item.Fooditem1)
                    {
                        item.Price = int.Parse(txtPrice.Text);
                        item.Img = byt;
                        ctx.SaveChanges();
                    }
                }
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                cmbFood.Text = "";
                txtPrice.Text = "";
                txtType.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Branch Has Been Updated Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                foreach (var item in ctx.FoodItems.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text ==
                        item.Rname && cmbLoc.Text == item.Branch
                        && item.Fooditem1 == cmbFood.Text)
                    {
                        txtPrice.Text = item.Price.ToString();
                        Image img;
                        MemoryStream ms = new MemoryStream(item.Img, 0, item.Img.Length);
                        ms.Write(item.Img, 0, item.Img.Length);
                        img = Image.FromStream(ms, true);
                        pictureBox1.Image = img;
                    }
                }
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
                FoodItem r1 = ctx.FoodItems.ToList().
                        FirstOrDefault(i => i.City == cmbCity.Text && i.Rname
                                     == cmbRest.Text && i.Branch == cmbLoc.Text &&
                                     i.Fooditem1 == cmbFood.Text);
                ctx.FoodItems.Remove(r1);
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                txtType.Text = "";
                cmbFood.Text = "";
                txtPrice.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Branch Has Been Deleted Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
