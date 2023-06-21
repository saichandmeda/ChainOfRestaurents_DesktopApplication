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
    public partial class UpdateRestaurant : Form
    {
        string img1;
        public UpdateRestaurant()
        {
            InitializeComponent();
        }

        private void UpdateRestaurant_Load(object sender, EventArgs e)
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
                string[] type = { "Veg", "Veg&Nonveg" };
                foreach (string item in type)
                {
                    cmbType.Items.Add(item);
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
                cmbType.Text = "";
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
                cmbType.Text = "";
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
                foreach (var item in ctx.Restaurants.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text == item.RName
                        && cmbLoc.Text == item.Branch)
                    {
                        item.RType = cmbType.Text;
                        Image img2 = pictureBox1.Image;
                        byte[] byt;
                        ImageConverter convert = new ImageConverter();
                        byt = (byte[])convert.ConvertTo(img2, typeof(byte[]));
                        item.Picture = byt;
                    }
                }
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                cmbType.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Branch Has Been Updated Succesfully");
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
                Chain_Of_RestaurantsEntities ctx = new Chain_Of_RestaurantsEntities();
                foreach (var item in ctx.Restaurants.ToList())
                {
                    if (cmbCity.Text == item.City && cmbRest.Text == item.RName
                        && cmbLoc.Text == item.Branch)
                    {
                        cmbType.Text = item.RType;
                        Image img;
                        MemoryStream ms = new MemoryStream(item.Picture, 0, item.Picture.
                                                      Length);
                        ms.Write(item.Picture, 0, item.Picture.Length);
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
                foreach (var item in ctx.FoodItems)
                {
                    if (item.City == cmbCity.Text && item.Rname
                                     == cmbRest.Text && item.Branch == cmbLoc.Text)
                    {
                        ctx.FoodItems.Remove(item);
                    }
                }
                Restaurant r1 = ctx.Restaurants.ToList().
                        FirstOrDefault(i => i.City == cmbCity.Text && i.RName
                                     == cmbRest.Text && i.Branch == cmbLoc.Text);
                ctx.Restaurants.Remove(r1);
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                cmbType.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Branch Has Been Deleted Succesfully");
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
                Image img2 = pictureBox1.Image;
                byte[] byt;
                ImageConverter convert = new ImageConverter();
                byt = (byte[])convert.ConvertTo(img2, typeof(byte[]));
                Restaurant r1 = new Restaurant()
                {
                    RName = cmbRest.Text,
                    City = cmbCity.Text,
                    Branch = cmbLoc.Text,
                    RType = cmbType.Text,
                    Picture = byt
            };
                ctx.Restaurants.Add(r1);
                ctx.SaveChanges();
                cmbRest.Text = "";
                cmbCity.Text = "";
                cmbLoc.Text = "";
                cmbType.Text = "";
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
    }
}
