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
    public partial class AddRestaurant : Form
    {
        string img1;
        public AddRestaurant()
        {
            InitializeComponent();
        }

        private void AddRestaurant_Load(object sender, EventArgs e)
        {
            try
            {
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

        private void button1_Click(object sender, EventArgs e)
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
                    RName = txtName.Text,
                    City = txtCity.Text,
                    Branch = txtLoc.Text,
                    RType = cmbType.Text,
                    Picture=byt
                };
                ctx.Restaurants.Add(r1);
                ctx.SaveChanges();
                txtName.Text = "";
                txtCity.Text = "";
                txtLoc.Text = "";
                cmbType.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Record Has Been Added Succesfully");
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
