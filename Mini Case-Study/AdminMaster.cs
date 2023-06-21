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
    public partial class AdminMaster : Form
    {
        public AdminMaster()
        {
            InitializeComponent();
        }

        private void addRestaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddRestaurant obj = new AddRestaurant();
                obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void deleteRestaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateRestaurant obj = new UpdateRestaurant();
                obj.MdiParent = this;
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

        private void deleteRestaurantToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                EditMenu obj = new EditMenu();
                obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Display obj = new Display();
                obj.MdiParent = this;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
